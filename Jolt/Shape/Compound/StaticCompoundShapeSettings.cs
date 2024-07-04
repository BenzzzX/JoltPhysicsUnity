using Unity.Mathematics;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_ShapeSettings"), GenerateBindings("JPH_CompoundShapeSettings"), GenerateBindings("JPH_StaticCompoundShapeSettings")]
    public readonly partial struct StaticCompoundShapeSettings : IShapeSettings
    {
        internal readonly NativeHandle<JPH_StaticCompoundShapeSettings> Handle;

        internal StaticCompoundShapeSettings(NativeHandle<JPH_StaticCompoundShapeSettings> handle)
        {
            Handle = handle;
        }
    }
}
