using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_NarrowPhaseQuery")]
    public readonly unsafe partial struct NarrowPhaseQuery
    {
        internal readonly NativeHandle<JPH_NarrowPhaseQuery> Handle;

        internal NarrowPhaseQuery(NativeHandle<JPH_NarrowPhaseQuery> handle)
        {
            Handle = handle;
        }
        private delegate void CastRayCollector(IntPtr context, JPH_RayCastResult* result);
        public delegate void CastRayCollectorManaged(JPH_RayCastResult result);
        private static void CastRayCollectorCallback(IntPtr context, JPH_RayCastResult* result)
        {
            //convert context to Action
            var callback = Marshal.GetDelegateForFunctionPointer<CastRayCollectorManaged>(context);
            callback(*result);
        }
        private delegate void CollidePointCollector(IntPtr context, JPH_CollidePointResult* result);
        public delegate void CollidePointCollectorManaged(JPH_CollidePointResult result);
        private static void CollidePointCollectorCallback(IntPtr context, JPH_CollidePointResult* result)
        {
            //convert context to Action
            var callback = Marshal.GetDelegateForFunctionPointer<CollidePointCollectorManaged>(context);
            callback(*result);
        }
        private delegate void CollideShapeCollector(IntPtr context, JPH_CollideShapeResult* result);
        public delegate void CollideShapeCollectorManaged(JPH_CollideShapeResult result);
        private static void CollideShapeCollectorCallback(IntPtr context, JPH_CollideShapeResult* result)
        {
            //convert context to Action
            var callback = Marshal.GetDelegateForFunctionPointer<CollideShapeCollectorManaged>(context);
            callback(*result);
        }
        private delegate void CastShapeCollector(IntPtr context, JPH_ShapeCastResult* result);
        public delegate void CastShapeCollectorManaged(JPH_ShapeCastResult result);
        private static void CastShapeCollectorCallback(IntPtr context, JPH_ShapeCastResult* result)
        {
            //convert context to Action
            var callback = Marshal.GetDelegateForFunctionPointer<CastShapeCollectorManaged>(context);
            callback(*result);
        }
        
        [OverrideBinding("JPH_NarrowPhaseQuery_CastRay2")]
        public bool CastRay2(float3 origin, float3 direction, CastRayCollectorManaged callback, BroadPhaseLayerFilter broadPhaseLayerFilter, ObjectLayerFilter objectLayerFilter, BodyFilter bodyFilter)
        {
            IntPtr userData = callback != null ? Marshal.GetFunctionPointerForDelegate(callback) : IntPtr.Zero;
            IntPtr callbackPtr = Marshal.GetFunctionPointerForDelegate((CastRayCollector)CastRayCollectorCallback);
            bool result = Bindings.JPH_NarrowPhaseQuery_CastRay2(Handle.Reinterpret<JPH_NarrowPhaseQuery>(), origin, direction, callbackPtr, (void*)userData, broadPhaseLayerFilter.Handle, objectLayerFilter.Handle, bodyFilter.Handle);
            return result;
        }
        
        [OverrideBinding("JPH_NarrowPhaseQuery_CollidePoint")]
        public bool CollidePoint(float3 point, CollidePointCollectorManaged callback, BroadPhaseLayerFilter broadPhaseLayerFilter, ObjectLayerFilter objectLayerFilter, BodyFilter bodyFilter)
        {
            IntPtr userData = callback != null ? Marshal.GetFunctionPointerForDelegate(callback) : IntPtr.Zero;
            IntPtr callbackPtr = Marshal.GetFunctionPointerForDelegate((CollidePointCollector)CollidePointCollectorCallback);
            bool result = Bindings.JPH_NarrowPhaseQuery_CollidePoint(Handle.Reinterpret<JPH_NarrowPhaseQuery>(), point, callbackPtr, (void*)userData, broadPhaseLayerFilter.Handle, objectLayerFilter.Handle, bodyFilter.Handle);
            return result;
        }
        
        [OverrideBinding("JPH_NarrowPhaseQuery_CollideShape")]
        public bool CollideShape(Shape shape, float3 shapeScale, float4x4 centerOfMassTransform, CollideShapeSettings collideShapeSettings, float3 baseOffset, CollideShapeCollectorManaged callback, BroadPhaseLayerFilter broadPhaseLayerFilter, ObjectLayerFilter objectLayerFilter, BodyFilter bodyFilter)
        {
            IntPtr userData = callback != null ? Marshal.GetFunctionPointerForDelegate(callback) : IntPtr.Zero;
            IntPtr callbackPtr = Marshal.GetFunctionPointerForDelegate((CollideShapeCollector)CollideShapeCollectorCallback);
            bool result = Bindings.JPH_NarrowPhaseQuery_CollideShape(Handle.Reinterpret<JPH_NarrowPhaseQuery>(), shape.Handle, shapeScale, centerOfMassTransform, collideShapeSettings, baseOffset, callbackPtr, (void*)userData, broadPhaseLayerFilter.Handle, objectLayerFilter.Handle, bodyFilter.Handle);
            return result;
        }
        
        [OverrideBinding("JPH_NarrowPhaseQuery_CastShape")]
        public bool CastShape(Shape shape, float4x4 centerOfMassTransform, float3 direction, ShapeCastSettings shapeCastSettings, float3 baseOffset, CastShapeCollectorManaged callback, BroadPhaseLayerFilter broadPhaseLayerFilter, ObjectLayerFilter objectLayerFilter, BodyFilter bodyFilter)
        {
            IntPtr userData = callback != null ? Marshal.GetFunctionPointerForDelegate(callback) : IntPtr.Zero;
            IntPtr callbackPtr = Marshal.GetFunctionPointerForDelegate((CastShapeCollector)CastShapeCollectorCallback);
            bool result = Bindings.JPH_NarrowPhaseQuery_CastShape(Handle.Reinterpret<JPH_NarrowPhaseQuery>(), shape.Handle, centerOfMassTransform, direction, shapeCastSettings, baseOffset, callbackPtr, (void*)userData, broadPhaseLayerFilter.Handle, objectLayerFilter.Handle, bodyFilter.Handle);
            return result;
        }
    }
}