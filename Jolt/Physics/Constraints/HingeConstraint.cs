namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_HingeConstraint")]
    public readonly partial struct HingeConstraint : IConstraint
    {
        internal readonly NativeHandle<JPH_HingeConstraint> Handle;
        NativeHandle<uint> IConstraint.Handle => Handle.Reinterpret<uint>();


        internal HingeConstraint(NativeHandle<JPH_HingeConstraint> handle)
        {
            Handle = handle;
        }

    }
}
