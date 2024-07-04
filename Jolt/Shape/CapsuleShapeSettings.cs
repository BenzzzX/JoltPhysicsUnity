using System;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_ShapeSettings"), GenerateBindings("JPH_ConvexShapeSettings"), GenerateBindings("JPH_CapsuleShapeSettings")]
    public readonly partial struct CapsuleShapeSettings : IConvexShapeSettings, IDisposable
    {
        internal readonly NativeHandle<JPH_CapsuleShapeSettings> Handle;

        internal CapsuleShapeSettings(NativeHandle<JPH_CapsuleShapeSettings> handle)
        {
            Handle = handle;
        }

        [OverrideBinding("JPH_CapsuleShapeSettings_Create")]
        public static CapsuleShapeSettings Create(float halfHeightOfCylinder, float radius)
        {
            return new CapsuleShapeSettings(JPH_CapsuleShapeSettings_Create(halfHeightOfCylinder, radius));
        }
        
        void IDisposable.Dispose()
        {
            Destroy();
        }
    }
}
