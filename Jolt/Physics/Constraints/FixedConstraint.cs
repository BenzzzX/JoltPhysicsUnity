namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_FixedConstraint")]
    public readonly partial struct FixedConstraint : IConstraint
    {
        internal readonly NativeHandle<JPH_FixedConstraint> Handle;
        NativeHandle<uint> IConstraint.Handle => Handle.Reinterpret<uint>();


        internal FixedConstraint(NativeHandle<JPH_FixedConstraint> handle)
        {
            Handle = handle;
        }

    }
}
