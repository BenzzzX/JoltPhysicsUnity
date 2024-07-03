using System;
using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static JPH_BodyLockRead JPH_BodyLockInterface_LockRead(NativeHandle<JPH_BodyLockInterface> lockInterface, BodyID bodyID)
        {
            JPH_BodyLockRead lockRead;
            UnsafeBindings.JPH_BodyLockInterface_LockRead(lockInterface, bodyID, &lockRead);
            return lockRead;
        }
        
        public static JPH_BodyLockWrite JPH_BodyLockInterface_LockWrite(NativeHandle<JPH_BodyLockInterface> lockInterface, BodyID bodyID)
        {
            JPH_BodyLockWrite lockWrite;
            UnsafeBindings.JPH_BodyLockInterface_LockWrite(lockInterface, bodyID, &lockWrite);
            return lockWrite;
        }
        
        public static JPH_BodyLockRead JPH_BodyLockInterface_UnlockRead(NativeHandle<JPH_BodyLockInterface> lockInterface, JPH_BodyLockRead lockRead)
        {
            UnsafeBindings.JPH_BodyLockInterface_UnlockRead(lockInterface, &lockRead);
            return lockRead;
        }
        
        public static JPH_BodyLockWrite JPH_BodyLockInterface_UnlockWrite(NativeHandle<JPH_BodyLockInterface> lockInterface, JPH_BodyLockWrite lockWrite)
        {
            UnsafeBindings.JPH_BodyLockInterface_UnlockWrite(lockInterface, &lockWrite);
            return lockWrite;
        }
    }
}
