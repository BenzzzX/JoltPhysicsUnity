using System;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_DistanceConstraintSettings"), GenerateBindings("JPH_ConstraintSettings")]
    public readonly partial struct DistanceConstraintSettings : IDisposable
    {
        internal readonly NativeHandle<JPH_DistanceConstraintSettings> Handle;

        internal DistanceConstraintSettings(NativeHandle<JPH_DistanceConstraintSettings> handle)
        {
            Handle = handle;
        }

        [OverrideBinding("JPH_DistanceConstraintSettings_Create")]
        public static DistanceConstraintSettings Create()
        {
            return new DistanceConstraintSettings(Bindings.JPH_DistanceConstraintSettings_Create());
        }

        void IDisposable.Dispose()
        {
            Destroy();
        }
    }
}
