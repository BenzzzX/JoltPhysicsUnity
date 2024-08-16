using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_ShapeSettings"), GenerateBindings("JPH_ConvexShapeSettings"), GenerateBindings("JPH_SphereShapeSettings")]
    public readonly partial struct SphereShapeSettings : IConvexShapeSettings
    {
        internal readonly NativeHandle<JPH_SphereShapeSettings> Handle;

        internal SphereShapeSettings(NativeHandle<JPH_SphereShapeSettings> handle)
        {
            Handle = handle;
        }
    }
}
