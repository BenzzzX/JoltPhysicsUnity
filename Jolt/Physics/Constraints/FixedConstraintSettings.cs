using System;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_FixedConstraintSettings"), GenerateBindings("JPH_ConstraintSettings")]
    public readonly partial struct FixedConstraintSettings : IDisposable
    {
        internal readonly NativeHandle<JPH_FixedConstraintSettings> Handle;

        internal FixedConstraintSettings(NativeHandle<JPH_FixedConstraintSettings> handle)
        {
            Handle = handle;
        }

        [OverrideBinding("JPH_FixedConstraintSettings_Create")]
        public static FixedConstraintSettings Create()
        {
            return new FixedConstraintSettings(Bindings.JPH_FixedConstraintSettings_Create());
        }

        void IDisposable.Dispose()
        {
            Destroy();
        }
    }
}
