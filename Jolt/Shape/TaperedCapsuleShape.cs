namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_Shape"), GenerateBindings("JPH_ConvexShape"), GenerateBindings("JPH_TaperedCapsuleShape")]
    public readonly partial struct TaperedCapsuleShape : IConvexShape
    {
        internal readonly NativeHandle<JPH_TaperedCapsuleShape> Handle;

        internal TaperedCapsuleShape(NativeHandle<JPH_TaperedCapsuleShape> handle)
        {
            Handle = handle;
        }

        // TODO no JPH_TaperedCapsuleShape_Create binding?
    }
}
