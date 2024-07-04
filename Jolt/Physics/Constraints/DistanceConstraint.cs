namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_DistanceConstraint")]
    public readonly partial struct DistanceConstraint : IConstraint
    {
        internal readonly NativeHandle<JPH_DistanceConstraint> Handle;
        NativeHandle<uint> IConstraint.Handle => Handle.Reinterpret<uint>();


        internal DistanceConstraint(NativeHandle<JPH_DistanceConstraint> handle)
        {
            Handle = handle;
        }

    }
}
