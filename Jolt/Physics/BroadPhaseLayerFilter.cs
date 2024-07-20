using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace Jolt
{
    public interface IBroadPhaseLayerFilter
    {
        public bool ShouldCollide(BroadPhaseLayer layer);
    }
    [GenerateHandle, GenerateBindings("JPH_BroadPhaseLayerFilter")]
    public readonly unsafe partial struct BroadPhaseLayerFilter : IDisposable
    {
        internal readonly NativeHandle<JPH_BroadPhaseLayerFilter> Handle;
        
        private delegate NativeBool ShouldCollide(IntPtr userData, BroadPhaseLayer layer);
        
        private static NativeBool ShouldCollideCallback(IntPtr userData, BroadPhaseLayer layer)
        {
            GCHandle gcHandle = GCHandle.FromIntPtr(userData);
            IBroadPhaseLayerFilter listener = (IBroadPhaseLayerFilter)gcHandle.Target;
            return listener.ShouldCollide(layer);
        }
        
        private static readonly JPH_BroadPhaseLayerFilter_Procs sProcs = new JPH_BroadPhaseLayerFilter_Procs
        {
            ShouldCollide = Marshal.GetFunctionPointerForDelegate((ShouldCollide)ShouldCollideCallback)
        };

        internal BroadPhaseLayerFilter(NativeHandle<JPH_BroadPhaseLayerFilter> handle)
        {
            Handle = handle;
        }
        
        [OverrideBinding("JPH_BroadPhaseLayerFilter_SetProcs")]
        public void SetProcs(IBroadPhaseLayerFilter listener)
        {
            //pin the listener so it doesn't get garbage collected
            GCHandle gcHandle = GCHandle.Alloc(listener);
            IntPtr gcHandlePtr = GCHandle.ToIntPtr(gcHandle);
            Bindings.JPH_BroadPhaseLayerFilter_SetProcs(Handle.Reinterpret<JPH_BroadPhaseLayerFilter>(), sProcs, (void*)gcHandlePtr);
        }

        public void Dispose()
        {
            //TODO: release the GCHandle
            Destroy();
        }
    }
}