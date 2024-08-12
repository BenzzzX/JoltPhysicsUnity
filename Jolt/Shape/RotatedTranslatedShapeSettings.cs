using Unity.Mathematics;
using static Jolt.Bindings;

namespace Jolt
{
    /// <summary>
    /// A widened CompoundShapeSettings instance handle.
    /// </summary>
    [GenerateHandle, GenerateBindings("JPH_ShapeSettings"), GenerateBindings("JPH_RotatedTranslatedShapeSettings")]
    public readonly partial struct RotatedTranslatedShapeSettings : IShapeSettings
    {
        internal readonly NativeHandle<JPH_RotatedTranslatedShapeSettings> Handle;

        internal RotatedTranslatedShapeSettings(NativeHandle<JPH_RotatedTranslatedShapeSettings> handle)
        {
            Handle = handle;
        }
    }
}
