using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace Jolt
{
    public interface IObjectLayerFilter
    {
        public bool ShouldCollide(ObjectLayer layerA);
    }
    [GenerateHandle, GenerateBindings("JPH_ObjectLayerFilter")]
    public readonly unsafe partial struct ObjectLayerFilter : IDisposable
    {
        internal readonly NativeHandle<JPH_ObjectLayerFilter> Handle;
        
        private delegate NativeBool ShouldCollide(IntPtr userData, ObjectLayer layer);
        
        private static NativeBool ShouldCollideCallback(IntPtr userData, ObjectLayer layer)
        {
            GCHandle gcHandle = GCHandle.FromIntPtr(userData);
            IObjectLayerFilter listener = (IObjectLayerFilter)gcHandle.Target;
            return listener.ShouldCollide(layer);
        }
        
        private static readonly JPH_ObjectLayerFilter_Procs sProcs = new JPH_ObjectLayerFilter_Procs
        {
            ShouldCollide = Marshal.GetFunctionPointerForDelegate((ShouldCollide)ShouldCollideCallback)
        };

        internal ObjectLayerFilter(NativeHandle<JPH_ObjectLayerFilter> handle)
        {
            Handle = handle;
        }
        
        [OverrideBinding("JPH_ObjectLayerFilter_SetProcs")]
        public void SetProcs(IObjectLayerFilter listener)
        {
            //pin the listener so it doesn't get garbage collected
            GCHandle gcHandle = GCHandle.Alloc(listener);
            IntPtr gcHandlePtr = GCHandle.ToIntPtr(gcHandle);
            Bindings.JPH_ObjectLayerFilter_SetProcs(Handle.Reinterpret<JPH_ObjectLayerFilter>(), sProcs, (void*)gcHandlePtr);
        }

        public void Dispose()
        {
            //TODO: release the GCHandle
            Destroy();
        }
    }
}