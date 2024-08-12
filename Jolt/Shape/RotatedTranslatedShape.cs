namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_Shape"), GenerateBindings("JPH_RotatedTranslatedShape")]
    public readonly partial struct RotatedTranslatedShape: IShape
    {
        internal readonly NativeHandle<JPH_RotatedTranslatedShape> Handle;

        internal RotatedTranslatedShape(NativeHandle<JPH_RotatedTranslatedShape> handle)
        {
            Handle = handle;
        }
    }
}
