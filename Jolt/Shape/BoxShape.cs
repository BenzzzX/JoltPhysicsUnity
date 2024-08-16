using Unity.Mathematics;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_Shape"), GenerateBindings("JPH_ConvexShape"), GenerateBindings("JPH_BoxShape")]
    public readonly partial struct BoxShape : IConvexShape
    {
        internal readonly NativeHandle<JPH_BoxShape> Handle;

        internal BoxShape(NativeHandle<JPH_BoxShape> handle)
        {
            Handle = handle;
        }

        [OverrideBinding("JPH_Shape_GetVolume"), OverrideBinding("JPH_BoxShape_GetVolume")]
        public float GetVolume()
        {
            return JPH_BoxShape_GetVolume(Handle); // defined in both JPH_Shape and JPH_BoxShape, explicitly use JPH_BoxShape impl
        }
    }
}
