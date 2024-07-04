using Unity.Mathematics;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_ShapeSettings"), GenerateBindings("JPH_CompoundShapeSettings"), GenerateBindings("JPH_MutableCompoundShapeSettings")]
    public readonly partial struct MutableCompoundShapeSettings : IShapeSettings
    {
        internal readonly NativeHandle<JPH_MutableCompoundShapeSettings> Handle;

        internal MutableCompoundShapeSettings(NativeHandle<JPH_MutableCompoundShapeSettings> handle)
        {
            Handle = handle;
        }
    }
}
