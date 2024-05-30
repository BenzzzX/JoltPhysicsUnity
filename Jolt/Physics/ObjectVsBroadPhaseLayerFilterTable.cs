﻿using static Jolt.SafeBindings;

namespace Jolt
{
    [GenerateHandle]
    public readonly partial struct ObjectVsBroadPhaseLayerFilterTable
    {
        internal readonly NativeHandle<JPH_ObjectVsBroadPhaseLayerFilter> Handle;

        internal ObjectVsBroadPhaseLayerFilterTable(NativeHandle<JPH_ObjectVsBroadPhaseLayerFilter> handle)
        {
            Handle = handle;
        }

        /// <summary>
        /// Implicit reinterpret cast as a base ObjectVsBroadPhaseLayerFilter.
        /// </summary>
        public static implicit operator ObjectVsBroadPhaseLayerFilter(ObjectVsBroadPhaseLayerFilterTable table)
        {
            return new ObjectVsBroadPhaseLayerFilter(table.Handle);
        }

        #region JPH_ObjectVsBroadPhaseLayerFilterTable

        public static ObjectVsBroadPhaseLayerFilterTable Create(BroadPhaseLayerInterface @interface, uint numBroadPhaseLayers, ObjectLayerPairFilter filter, uint numObjectLayers)
        {
            return new ObjectVsBroadPhaseLayerFilterTable(JPH_ObjectVsBroadPhaseLayerFilterTable_Create(@interface.Handle, numBroadPhaseLayers, filter.Handle, numObjectLayers));
        }

        #endregion
    }
}
