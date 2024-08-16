using Unity.Mathematics;

using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_ShapeSettings"), GenerateBindings("JPH_ConvexShapeSettings"), GenerateBindings("JPH_BoxShapeSettings")]
    public readonly partial struct BoxShapeSettings : IConvexShapeSettings
    {
        internal readonly NativeHandle<JPH_BoxShapeSettings> Handle;

        internal BoxShapeSettings(NativeHandle<JPH_BoxShapeSettings> handle)
        {
            Handle = handle;
        }
    }
}
