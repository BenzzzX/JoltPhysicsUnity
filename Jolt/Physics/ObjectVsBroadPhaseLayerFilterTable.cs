using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_ObjectVsBroadPhaseLayerFilterTable")]
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
    }
}
