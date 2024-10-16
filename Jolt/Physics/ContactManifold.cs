namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_ContactManifold")]
    public readonly partial struct ContactManifold
    {
        internal readonly NativeHandle<JPH_ContactManifold> Handle;

        internal ContactManifold(NativeHandle<JPH_ContactManifold> handle)
        {
            Handle = handle;
        }
    }
}