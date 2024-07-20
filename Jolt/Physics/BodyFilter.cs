using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace Jolt
{
    public interface IBodyFilter
    {
        public bool ShouldCollide(BodyID bodyID);
        public bool ShouldCollideLocked(Body body);
    }
    [GenerateHandle, GenerateBindings("JPH_BodyFilter")]
    public readonly unsafe partial struct BodyFilter : IDisposable
    {
        internal readonly NativeHandle<JPH_BodyFilter> Handle;
        
        private delegate NativeBool ShouldCollide(IntPtr userData, BodyID bodyID);
        
        private static NativeBool ShouldCollideCallback(IntPtr userData, BodyID bodyID)
        {
            GCHandle gcHandle = GCHandle.FromIntPtr(userData);
            IBodyFilter listener = (IBodyFilter)gcHandle.Target;
            return listener.ShouldCollide(bodyID);
        }
        
        private delegate NativeBool ShouldCollideLocked(IntPtr userData, JPH_Body* body);
        
        private static NativeBool ShouldCollideLockedCallback(IntPtr userData, JPH_Body* body)
        {
            GCHandle gcHandle = GCHandle.FromIntPtr(userData);
            IBodyFilter listener = (IBodyFilter)gcHandle.Target;
            return listener.ShouldCollideLocked(new Body(NativeHandle<JPH_Body>.CreateObserveHandle(body)));
        }
        
        private static readonly JPH_BodyFilter_Procs sProcs = new JPH_BodyFilter_Procs
        {
            ShouldCollide = Marshal.GetFunctionPointerForDelegate((ShouldCollide)ShouldCollideCallback),
            ShouldCollideLocked = Marshal.GetFunctionPointerForDelegate((ShouldCollideLocked)ShouldCollideLockedCallback)
        };

        internal BodyFilter(NativeHandle<JPH_BodyFilter> handle)
        {
            Handle = handle;
        }
        
        [OverrideBinding("JPH_BodyFilter_SetProcs")]
        public void SetProcs(IBodyFilter listener)
        {
            //pin the listener so it doesn't get garbage collected
            GCHandle gcHandle = GCHandle.Alloc(listener);
            IntPtr gcHandlePtr = GCHandle.ToIntPtr(gcHandle);
            Bindings.JPH_BodyFilter_SetProcs(Handle.Reinterpret<JPH_BodyFilter>(), sProcs, (void*)gcHandlePtr);
        }

        public void Dispose()
        {
            //TODO: release the GCHandle
            Destroy();
        }
    }
}