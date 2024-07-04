using System;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_HingeConstraintSettings"), GenerateBindings("JPH_ConstraintSettings")]
    public readonly partial struct HingeConstraintSettings : IDisposable
    {
        internal readonly NativeHandle<JPH_HingeConstraintSettings> Handle;

        internal HingeConstraintSettings(NativeHandle<JPH_HingeConstraintSettings> handle)
        {
            Handle = handle;
        }
        
        public static implicit operator ConstraintSettings(HingeConstraintSettings settings)
        {
            return new ConstraintSettings(settings.Handle.Reinterpret<JPH_ConstraintSettings>());
        }

        [OverrideBinding("JPH_HingeConstraintSettings_Create")]
        public static HingeConstraintSettings Create()
        {
            return new HingeConstraintSettings(Bindings.JPH_HingeConstraintSettings_Create());
        }

        void IDisposable.Dispose()
        {
            Destroy();
        }
    }
}
