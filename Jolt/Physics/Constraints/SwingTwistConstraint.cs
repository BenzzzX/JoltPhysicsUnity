namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_SwingTwistConstraint")]
    public readonly partial struct SwingTwistConstraint : IConstraint
    {
        internal readonly NativeHandle<JPH_SwingTwistConstraint> Handle;
        NativeHandle<uint> IConstraint.Handle => Handle.Reinterpret<uint>();


        internal SwingTwistConstraint(NativeHandle<JPH_SwingTwistConstraint> handle)
        {
            Handle = handle;
        }

    }
}
