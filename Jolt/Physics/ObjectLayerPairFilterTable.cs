using System;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_ObjectLayerPairFilterTable")]
    public readonly partial struct ObjectLayerPairFilterTable
    {
        internal readonly NativeHandle<JPH_ObjectLayerPairFilter> Handle;

        internal ObjectLayerPairFilterTable(NativeHandle<JPH_ObjectLayerPairFilter> handle)
        {
            Handle = handle;
        }
        
        [OverrideBinding("JPH_ObjectLayerPairFilterTable_Create")]
        public static ObjectLayerPairFilterTable Create(uint numLayers)
        {
            return new ObjectLayerPairFilterTable(JPH_ObjectLayerPairFilterTable_Create(numLayers));
        }

        /// <summary>
        /// Implicit reinterpret cast as a base ObjectLayerPairFilter.
        /// </summary>
        public static implicit operator ObjectLayerPairFilter(ObjectLayerPairFilterTable table)
        {
            return new ObjectLayerPairFilter(table.Handle);
        }
    }
}
