using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Jolt.SourceGenerators;

[Generator]
internal class JoltSourceGenerator : ISourceGenerator
{
    static string[] ValueTypeNames = new[] { "float3", "rvec3", "float", "rmatrix4x4", "float4x4", "quaternion", "BodyID", "float4", "AABox", "NativeBool", "MassProperties", "Triangle",
        "ValidateResult", "JPH_SpringSettings", "JPH_MotorSettings", "JPH_SubShapeIDPair", "JPH_BroadPhaseCastResult",
        "JPH_RayCastResult", "JPH_CollidePointResult", "JPH_CollideShapeResult", "JPH_ShapeCastResult", "JPH_BodyLockRead", "JPH_BodyLockWrite",
        "JPH_ExtendedUpdateSettings", "JPH_PhysicsSystemSettings", "JPH_PhysicsSettings",
        "JPH_BroadPhaseLayerFilter_Procs", "JPH_ObjectLayerFilter_Procs", "JPH_BodyFilter_Procs", "JPH_ContactListener_Procs",
        "JPH_BodyActivationListener_Procs", "JPH_CharacterContactListener_Procs",
        "ShapeCastSettings", "CollideShapeSettings"};
    static INamedTypeSymbol NativeTypeAttributeSymbol;

    public void Initialize(GeneratorInitializationContext ctx)
    {
        ctx.RegisterForSyntaxNotifications(() => new JoltSyntaxReceiver());
    }

    public void Execute(GeneratorExecutionContext ctx)
    {
        if (ctx.SyntaxReceiver is not JoltSyntaxReceiver recv) return;

        NativeTypeAttributeSymbol = ctx.Compilation.GetTypeByMetadataName("Jolt.NativeTypeNameAttribute");
        var bindings = IngestNativeBindings(recv);
        var wrappers = CreateNativeTypeWrapperList(recv, ctx);

        foreach (var wrapper in wrappers)
        {
            try
            {
                var filename = $"{wrapper.TypeName}.g.cs";
                var filetext = GenerateNativeTypeWrapper(ctx, wrapper, bindings);

                ctx.AddSource(filename, filetext);
            }
            catch
            {
                continue; // TODO surface error
            }
        }
    }

    /// <summary>
    /// Construct an optimized map of native extern functions from the syntax receiver pass.
    /// </summary>
    private static JoltNativeBindings IngestNativeBindings(JoltSyntaxReceiver recv)
    {
        var bindings = new JoltNativeBindings();

        foreach (var decl in recv.UnsafeBindings)
        {
            var parts = decl.Identifier.ValueText.Split('_');

            if (parts.Length < 3) continue; // we are only interested in JPH_SomeType_MethodFoo bindings

            var prefix = $"{parts[0]}_{parts[1]}";
            var method = parts[2];

            var details = new JoltNativeBindingDetails(prefix, method, decl);

            if (bindings.BindingsByNativeType.TryGetValue(prefix, out var value))
            {
                value.Add(details);
            }
            else
            {
                bindings.BindingsByNativeType.Add(prefix, [details]);
            }
        }

        return bindings;
    }

    /// <summary>
    /// Construct a list of native type wrapper metadata from the syntax receiver pass.
    /// </summary>
    private static List<JoltNativeTypeWrapper> CreateNativeTypeWrapperList(JoltSyntaxReceiver recv, GeneratorExecutionContext ctx)
    {
        var result = new List<JoltNativeTypeWrapper>();

        foreach (var decl in recv.Wrappers)
        {
            result.Add(CreateNativeTypeWrapper(ctx, decl));
        }

        return result;
    }

    private static JoltNativeTypeWrapper CreateNativeTypeWrapper(GeneratorExecutionContext ctx, StructDeclarationSyntax decl)
    {
        var generateBindingsAttributeSymbol = ctx.Compilation.GetTypeByMetadataName("Jolt.GenerateBindingsAttribute");
        var overrideBindingAttributeSymbol = ctx.Compilation.GetTypeByMetadataName("Jolt.OverrideBindingAttribute");

        Debug.Assert(generateBindingsAttributeSymbol != null);

        var symbol = ctx.Compilation.GetSemanticModel(decl.SyntaxTree).GetDeclaredSymbol(decl);
        var result = new JoltNativeTypeWrapper(decl.Identifier.ValueText);

        Debug.Assert(symbol != null);

        foreach (var attr in symbol.GetAttributes())
        {
            if (!generateBindingsAttributeSymbol.Equals(attr.AttributeClass, SymbolEqualityComparer.Default))
            {
                continue;
            }

            if (attr.ConstructorArguments.IsEmpty)
            {
                continue;
            }

            var prefix = attr.ConstructorArguments[0].Value?.ToString();

            result.NativeTypePrefixes.Add(prefix);
        }

        foreach (var member in symbol.GetMembers())
        {
            if (member is IMethodSymbol { DeclaredAccessibility: Accessibility.Public } method)
            {
                foreach (var attr in method.GetAttributes())
                {
                    if (!overrideBindingAttributeSymbol.Equals(attr.AttributeClass, SymbolEqualityComparer.Default))
                    {
                        continue;
                    }

                    if (attr.ConstructorArguments.IsEmpty)
                    {
                        continue;
                    }

                    var excluded = attr.ConstructorArguments[0].Value?.ToString();

                    result.ExcludedBindings.Add(excluded);
                }
            }
        }

        return result;
    }

    private static string GenerateNativeTypeWrapper(GeneratorExecutionContext ctx, JoltNativeTypeWrapper target, JoltNativeBindings bindings)
    {
        var writer = new IndentedTextWriter(new StringWriter());

        writer.WriteLine("using System;");
        writer.WriteLine("using Jolt;");
        writer.WriteLine("using Unity.Mathematics;");
        writer.WriteLine();

        StartBlock(writer, "namespace Jolt");

        foreach (var prefix in target.NativeTypePrefixes)
        {
            GenerateSafeBindingsWithPrefix(ctx, writer, target, bindings, prefix);
        }

        StartBlock(writer, $"public partial struct {target.TypeName} : IEquatable<{target.TypeName}>");

        GenerateEquatableInterface(writer, target.TypeName);

        foreach (var prefix in target.NativeTypePrefixes)
        {
            GenerateBindingsWithPrefix(writer, target, bindings, prefix);
        }

        CloseBlock(writer);
        CloseBlock(writer);

        Debug.Assert(writer.Indent == 0);

        return writer.InnerWriter.ToString();
    }

    private static void GenerateEquatableInterface(IndentedTextWriter writer, string type)
    {
        WritePaddedLine(writer, "#region IEquatable");

        WritePaddedLine(writer, $"public bool Equals({type} other) => Handle.Equals(other.Handle);");

        WritePaddedLine(writer, $"public override bool Equals(object obj) => obj is {type} other && Equals(other);");

        WritePaddedLine(writer, "public override int GetHashCode() => Handle.GetHashCode();");

        WritePaddedLine(writer, $"public static bool operator ==({type} lhs, {type} rhs) => lhs.Equals(rhs);");

        WritePaddedLine(writer, $"public static bool operator !=({type} lhs, {type} rhs) => !lhs.Equals(rhs);");

        WritePaddedLine(writer, "#endregion");
    }

    private static void GenerateSafeBindingsWithPrefix(GeneratorExecutionContext ctx, IndentedTextWriter writer, JoltNativeTypeWrapper target, JoltNativeBindings bindings, string prefix)
    {
        if(bindings.wrappedBindings.ContainsKey(prefix))
        {
            return;
        }
        if (!bindings.BindingsByNativeType.TryGetValue(prefix, out var bindingsWithPrefix))
        {
            return;
        }
        bindings.wrappedBindings.Add(prefix, true);
        StartBlock(writer, "internal static unsafe partial class Bindings");
        foreach (var b in bindingsWithPrefix)
        {
            var parameters = new List<string>();
            var temps = new List<string>();
            var detemps = new List<string>();
            string returnType = "void";
            var arguments = new List<string>();
            bool returnStruct = false;
            bool createHandle = false;
            var proxyParams = new List<string>();
            var proxyArgs = new List<string>();
            string proxyReturn = "";
            int outParamCount = 0;
            bool isStatic = true;
            ParameterSyntax outParameter = null;

            for (int i = 0; i < b.BindingDeclaration.ParameterList.Parameters.Count; i++)
            {
                var p = b.BindingDeclaration.ParameterList.Parameters[i];
                Debug.Assert(p.Type != null);
                //get attribute datas
                var symbol = ctx.Compilation.GetSemanticModel(p.SyntaxTree).GetDeclaredSymbol(p);
                var attrs = symbol.GetAttributes();
                string nativeTypeName = string.Empty;
                foreach (var attr in attrs)
                {
                    if (!attr.AttributeClass.Equals(NativeTypeAttributeSymbol, SymbolEqualityComparer.Default))
                    {
                        continue;
                    }

                    if (attr.ConstructorArguments.IsEmpty)
                    {
                        continue;
                    }

                    nativeTypeName = attr.ConstructorArguments[0].Value?.ToString();
                }
                var isArrayPointer = nativeTypeName.EndsWith("[]");
                var type = p.Type.ToString();
                var name = p.Identifier.ValueText;
                var isPointer = p.Type.IsKind(SyntaxKind.PointerType) && !isArrayPointer;
                var isValueType = isPointer ? ValueTypeNames.Contains(type.Substring(0, type.Length - 1)) : ValueTypeNames.Contains(type);
                bool isSelf = false;
                if (i == 0 && isPointer && !isValueType)
                {
                    var depointer = type.Substring(0, type.Length - 1);
                    if(b.BindingDeclaration.Identifier.Text.StartsWith(depointer))
                    {
                        proxyArgs.Add($"Handle.Reinterpret<{depointer}>()");
                        isStatic = false;
                        isSelf = true;
                    }
                }
                if (type == "void*")
                {
                    parameters.Add($"void* {name}");
                    arguments.Add($"{name}");
                    if (!isSelf)
                    {
                        proxyParams.Add($"void* {name}");
                        proxyArgs.Add($"{name}");
                    }
                }
                else if (isPointer && !isValueType)
                {
                    var depointer = type.Substring(0, type.Length - 1);

                    parameters.Add($"NativeHandle<{depointer}> {name}");
                    arguments.Add($"{name}");

                    if (!isSelf)
                    {
                        var publicWrapperType = depointer.Substring("JPH_".Length);
                        proxyParams.Add($"{publicWrapperType} {name}");
                        proxyArgs.Add($"{name}.Handle");
                    }
                }
                else if (isPointer && isValueType)
                {
                    if (nativeTypeName.StartsWith("const"))
                    {
                        var depointer = type.Substring(0, type.Length - 1);
                        arguments.Add($"&{name}");
                        parameters.Add($"{depointer} {name}");
                        if (!isSelf)
                        {
                            proxyParams.Add($"{depointer} {name}");
                            proxyArgs.Add($"{name}");
                        }
                    }
                    else
                    {
                        outParamCount++;
                        outParameter = p;
                        var depointer = type.Substring(0, type.Length - 1);
                        temps.Add($"{depointer} tmp{name};");
                        detemps.Add($"{name} = tmp{name};");
                        arguments.Add($"&tmp{name}");
                        parameters.Add($"out {depointer} {name}");

                        if (!isSelf)
                        {
                            proxyParams.Add($"out {depointer} {name}");
                            proxyArgs.Add($"out {name}");
                        }
                    }
                }
                else
                {
                    arguments.Add($"{name}");
                    parameters.Add($"{type} {name}");
                    if (!isSelf)
                    {
                        proxyParams.Add($"{type} {name}");
                        proxyArgs.Add($"{name}");
                    }
                }
            }
            //transform single out parameter to return value
            if (outParamCount == 1 && b.BindingDeclaration.ReturnType.ToString() == "void")
            {
                temps.Clear();
                detemps.Clear();
                var type = outParameter.Type.ToString();
                var name = outParameter.Identifier.ValueText;
                var depointer = type.Substring(0, type.Length - 1);
                temps.Add($"{depointer} result;");
                for(int i = 0; i < arguments.Count; i++)
                {
                    if (arguments[i] == $"&tmp{name}")
                    {
                        arguments[i] = $"&result";
                        break;
                    }
                }
                parameters.Remove($"out {depointer} {name}");
                proxyArgs.Remove($"out {name}");
                proxyParams.Remove($"out {depointer} {name}");
                returnType = depointer;
                returnStruct = true;
                proxyReturn = depointer;
            }
            if (!returnStruct)
            {
                var t = b.BindingDeclaration.ReturnType;

                var type = t.ToString();
                if (type == "NativeBool")
                    type = "bool";
                var isPointer = t.IsKind(SyntaxKind.PointerType);
                var isValueType = ValueTypeNames.Contains(type);
                if (isPointer && !isValueType)
                {
                    var depointer = type.Substring(0, type.Length - 1);
                    returnType = $"NativeHandle<{depointer}>";
                    createHandle = true;

                    var publicWrapperType = depointer.Substring("JPH_".Length);
                    proxyReturn = publicWrapperType;
                }
                else if (isPointer && isValueType)
                {
                    var depointer = type.Substring(0, type.Length - 1);
                    returnType = depointer;
                    proxyReturn = depointer;
                }
                else
                {
                    returnType = type;
                    proxyReturn = type;
                }
            }
            var modifier = isStatic ? "static " : "";
            if(b.BindingMethodName == "GetType")
            {
                modifier = "new " + modifier;
            }
            var argsString = string.Join(", ", arguments);
            var paramsString = string.Join(", ", parameters);
            var declaration = $"public static {returnType} {b.BindingDeclaration.Identifier.Text}({paramsString})";
            var proxyDeclaration = $"{modifier}{proxyReturn} {b.BindingMethodName}({string.Join(", ", proxyParams)})";
            var proxyCall = $"Bindings.{b.BindingDeclaration.Identifier.Text}({string.Join(", ", proxyArgs)})";
            if(createHandle)
                proxyCall = $"new {proxyReturn}({proxyCall})";
            b.WrapperImpl = $"{proxyDeclaration} => {proxyCall};";
            StartBlock(writer, declaration);
            foreach (var temp in temps)
            {
                WritePaddedLine(writer, temp);
            }
            if (returnType == "void")
            {
                WritePaddedLine(writer, $"UnsafeBindings.{b.BindingDeclaration.Identifier.Text}({argsString});");
                foreach (var detemp in detemps)
                {
                    WritePaddedLine(writer, detemp);
                }
            }
            else
            {
                if (createHandle)
                {
                    writer.WriteLine($"return CreateHandle(UnsafeBindings.{b.BindingDeclaration.Identifier.Text}({argsString}));");
                }
                else
                {
                    if (!returnStruct)
                    {
                        WritePaddedLine(writer, $"{returnType} result = UnsafeBindings.{b.BindingDeclaration.Identifier.Text}({argsString});");
                    }
                    else
                    {
                        WritePaddedLine(writer, $"UnsafeBindings.{b.BindingDeclaration.Identifier.Text}({argsString});");
                    }
                    foreach (var detemp in detemps)
                    {
                        WritePaddedLine(writer, detemp);
                    }
                    WritePaddedLine(writer, "return result;");
                }
            }
            CloseBlock(writer);
        }
        CloseBlock(writer);
    }

    private static void GenerateBindingsWithPrefix(IndentedTextWriter writer, JoltNativeTypeWrapper target, JoltNativeBindings bindings, string prefix)
    {
        if (!bindings.BindingsByNativeType.TryGetValue(prefix, out var bindingsWithPrefix))
        {
            WritePaddedLine(writer, $"#region {prefix}");
            WritePaddedLine(writer, "#endregion");
            return; // no bindings exist for this prefix
        }

        WritePaddedLine(writer, $"#region {prefix}");

        foreach (var b in bindingsWithPrefix)
        {

            if (target.ExcludedBindings.Contains(b.BindingDeclaration.Identifier.ValueText))
            {
                continue; // target has explicitly excluded this binding
            }

            WritePaddedLine(writer, $"public {b.WrapperImpl}");
        }

        WritePaddedLine(writer, "#endregion");
    }

    private static string ExtractGenericHandleType(string type)
    {
        var lbracket = type.IndexOf('<');
        var rbracket = type.IndexOf('>');
        return type.Substring(lbracket + 1, rbracket - lbracket - 1);
    }

    private static void StartBlock(IndentedTextWriter writer, string line)
    {
        writer.WriteLine(line);
        writer.WriteLine("{");

        writer.Indent++;
    }

    private static void CloseBlock(IndentedTextWriter writer)
    {
        writer.Indent--;

        writer.WriteLine("}");
    }

    private static void WritePaddedLine(IndentedTextWriter writer, string line)
    {
        writer.WriteLine(line);
    }

    private static void Log(string message)
    {
        try
        {
            File.AppendAllText(Path.Combine(@"C:\Users\Chris", "JoltSourceGenerator.log"), $"{message}{Environment.NewLine}");
        }
        catch
        {
            // ignore
        }
    }
}

/// <summary>
/// An optimized lookup of native extern functions.
/// </summary>
internal class JoltNativeBindings
{
    public readonly Dictionary<string, List<JoltNativeBindingDetails>> BindingsByNativeType = new ();
    public Dictionary<string, bool> wrappedBindings = new();
}

/// <summary>
/// Metadata about an individual native extern function we will proxy.
/// </summary>
internal class JoltNativeBindingDetails(string type, string method, MethodDeclarationSyntax decl)
{
    public readonly string NativeTypeName = type;

    public readonly string BindingMethodName = method;

    public readonly MethodDeclarationSyntax BindingDeclaration = decl;

    public string WrapperImpl;
}

/// <summary>
/// Metadata about a native type wrapper we will generate.
/// </summary>
internal class JoltNativeTypeWrapper(string type)
{
    public readonly string TypeName = type;

    public readonly HashSet<string> NativeTypePrefixes = [];

    public readonly HashSet<string> ExcludedBindings = [];
}
