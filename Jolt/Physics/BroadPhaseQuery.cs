using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_BroadPhaseQuery")]
    public readonly unsafe partial struct BroadPhaseQuery
    {
        internal readonly NativeHandle<JPH_BroadPhaseQuery> Handle;

        internal BroadPhaseQuery(NativeHandle<JPH_BroadPhaseQuery> handle)
        {
            Handle = handle;
        }
        private delegate void RayCastBodyCollector(IntPtr context, JPH_BroadPhaseCastResult* result);
        public delegate void RayCastBodyCollectorManaged(JPH_BroadPhaseCastResult result);
        private delegate void CollideShapeBodyCollector(IntPtr context, BodyID result);
        public delegate void CollideShapeBodyCollectorManaged(BodyID result);
        private static void RayCastBodyCollectorCallback(IntPtr context, JPH_BroadPhaseCastResult* result)
        {
            //convert context to Action
            var callback = Marshal.GetDelegateForFunctionPointer<RayCastBodyCollectorManaged>(context);
            callback(*result);
        }
        private static void CollideShapeBodyCollectorCallback(IntPtr context, BodyID result)
        {
            //convert context to Action
            var callback = Marshal.GetDelegateForFunctionPointer<CollideShapeBodyCollectorManaged>(context);
            callback(result);
        }
        
        [OverrideBinding("JPH_BroadPhaseQuery_CastRay")]
        public bool CastRay(float3 origin, float3 direction, RayCastBodyCollectorManaged callback, BroadPhaseLayerFilter broadPhaseLayerFilter, ObjectLayerFilter objectLayerFilter)
        {
            IntPtr userData = callback != null ? Marshal.GetFunctionPointerForDelegate(callback) : IntPtr.Zero;
            IntPtr callbackPtr = Marshal.GetFunctionPointerForDelegate((RayCastBodyCollector)RayCastBodyCollectorCallback);
            bool result = Bindings.JPH_BroadPhaseQuery_CastRay(Handle.Reinterpret<JPH_BroadPhaseQuery>(), origin, direction, callbackPtr, (void*)userData, broadPhaseLayerFilter.Handle, objectLayerFilter.Handle);
            return result;
        }
        
        [OverrideBinding("JPH_BroadPhaseQuery_CollideAABox")]
        public bool CollideAABox(AABox box, CollideShapeBodyCollectorManaged callback, BroadPhaseLayerFilter broadPhaseLayerFilter, ObjectLayerFilter objectLayerFilter)
        {
            IntPtr userData = callback != null ? Marshal.GetFunctionPointerForDelegate(callback) : IntPtr.Zero;
            IntPtr callbackPtr = Marshal.GetFunctionPointerForDelegate((CollideShapeBodyCollector)CollideShapeBodyCollectorCallback);
            bool result = Bindings.JPH_BroadPhaseQuery_CollideAABox(Handle.Reinterpret<JPH_BroadPhaseQuery>(), box, callbackPtr, (void*)userData, broadPhaseLayerFilter.Handle, objectLayerFilter.Handle);
            return result;
        }
        
        [OverrideBinding("JPH_BroadPhaseQuery_CollideSphere")]
        public bool CollideSphere(float3 center, float radius, CollideShapeBodyCollectorManaged callback, BroadPhaseLayerFilter broadPhaseLayerFilter, ObjectLayerFilter objectLayerFilter)
        {
            IntPtr userData = callback != null ? Marshal.GetFunctionPointerForDelegate(callback) : IntPtr.Zero;
            IntPtr callbackPtr = Marshal.GetFunctionPointerForDelegate((CollideShapeBodyCollector)CollideShapeBodyCollectorCallback);
            bool result = Bindings.JPH_BroadPhaseQuery_CollideSphere(Handle.Reinterpret<JPH_BroadPhaseQuery>(), center, radius, callbackPtr, (void*)userData, broadPhaseLayerFilter.Handle, objectLayerFilter.Handle);
            return result;
        }
        
        [OverrideBinding("JPH_BroadPhaseQuery_CollidePoint")]
        public bool CollidePoint(float3 point, CollideShapeBodyCollectorManaged callback, BroadPhaseLayerFilter broadPhaseLayerFilter, ObjectLayerFilter objectLayerFilter)
        {
            IntPtr userData = callback != null ? Marshal.GetFunctionPointerForDelegate(callback) : IntPtr.Zero;
            IntPtr callbackPtr = Marshal.GetFunctionPointerForDelegate((CollideShapeBodyCollector)CollideShapeBodyCollectorCallback);
            bool result = Bindings.JPH_BroadPhaseQuery_CollidePoint(Handle.Reinterpret<JPH_BroadPhaseQuery>(), point, callbackPtr, (void*)userData, broadPhaseLayerFilter.Handle, objectLayerFilter.Handle);
            return result;
        }
    }
}