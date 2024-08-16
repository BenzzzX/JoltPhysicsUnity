using System;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_ShapeSettings"), GenerateBindings("JPH_ConvexShapeSettings"), GenerateBindings("JPH_TaperedCapsuleShapeSettings")]
    public readonly partial struct TaperedCapsuleShapeSettings : IConvexShapeSettings
    {
        internal readonly NativeHandle<JPH_TaperedCapsuleShapeSettings> Handle;

        internal TaperedCapsuleShapeSettings(NativeHandle<JPH_TaperedCapsuleShapeSettings> handle)
        {
            Handle = handle;
        }
    }
}
