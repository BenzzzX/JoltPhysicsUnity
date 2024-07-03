namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_ContactSettings")]
    public readonly partial struct ContactSettings 
    {
        internal readonly NativeHandle<JPH_ContactSettings> Handle;

        internal ContactSettings(NativeHandle<JPH_ContactSettings> handle)
        {
            Handle = handle;
        }
    }
}