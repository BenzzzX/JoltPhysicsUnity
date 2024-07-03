namespace Jolt
{
    public interface IConstraint
    {
        internal NativeHandle<uint> Handle { get; }
    }
}