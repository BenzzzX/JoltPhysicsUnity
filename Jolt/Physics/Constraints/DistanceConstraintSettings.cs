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

        void IDisposable.Dispose()
        {
            Destroy();
        }
    }
}
