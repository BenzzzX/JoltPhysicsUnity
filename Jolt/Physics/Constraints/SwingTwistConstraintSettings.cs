using System;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_SwingTwistConstraintSettings"), GenerateBindings("JPH_ConstraintSettings")]
    public readonly partial struct SwingTwistConstraintSettings : IDisposable
    {
        internal readonly NativeHandle<JPH_SwingTwistConstraintSettings> Handle;

        internal SwingTwistConstraintSettings(NativeHandle<JPH_SwingTwistConstraintSettings> handle)
        {
            Handle = handle;
        }

        [OverrideBinding("JPH_SwingTwistConstraintSettings_Create")]
        public static SwingTwistConstraintSettings Create()
        {
            return new SwingTwistConstraintSettings(Bindings.JPH_SwingTwistConstraintSettings_Create());
        }

        void IDisposable.Dispose()
        {
            Destroy();
        }
    }
}
