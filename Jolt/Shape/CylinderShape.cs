using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_Shape"), GenerateBindings("JPH_ConvexShape"), GenerateBindings("JPH_CylinderShape")]
    public readonly partial struct CylinderShape: IConvexShape
    {
        internal readonly NativeHandle<JPH_CylinderShape> Handle;

        internal CylinderShape(NativeHandle<JPH_CylinderShape> handle)
        {
            Handle = handle;
        }
    }
}
