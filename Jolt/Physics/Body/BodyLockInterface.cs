using System;

namespace Jolt
{
    public struct BodyLockRead : IDisposable
    {
        JPH_BodyLockRead mLock;
        
        internal BodyLockRead(JPH_BodyLockRead lockRead)
        {
            mLock = lockRead;
        }
        
        unsafe 
        public Body Body => new (new NativeHandle<JPH_Body>(mLock.body));

        unsafe void Release()
        {
            fixed (JPH_BodyLockRead* pLock = &mLock)
            {
                UnsafeBindings.JPH_BodyLockInterface_UnlockRead(mLock.lockInterface, pLock);
            }
        }
        
        public void Dispose()
        {
            Release();
        }
    }
    
    public struct BodyLockWrite
    {
        JPH_BodyLockWrite mLock;
        
        unsafe 
        public Body Body => new Body(new NativeHandle<JPH_Body>(mLock.body));
        
        internal BodyLockWrite(JPH_BodyLockWrite lockWrite)
        {
            mLock = lockWrite;
        }

        unsafe void Release()
        {
            fixed (JPH_BodyLockWrite* pLock = &mLock)
            {
                UnsafeBindings.JPH_BodyLockInterface_UnlockWrite(mLock.lockInterface, pLock);
            }
        }
        
        public void Dispose()
        {
            Release();
        }
    }
    
    [GenerateHandle]
    public readonly partial struct BodyLockInterface
    {
        internal readonly NativeHandle<JPH_BodyLockInterface> Handle;

        internal BodyLockInterface(NativeHandle<JPH_BodyLockInterface> handle)
        {
            Handle = handle;
        }
        
        public BodyLockRead LockRead(BodyID bodyID)
        {
            return new BodyLockRead(Bindings.JPH_BodyLockInterface_LockRead(Handle, bodyID));
        }
        
        public BodyLockWrite LockWrite(BodyID bodyID)
        {
            return new BodyLockWrite(Bindings.JPH_BodyLockInterface_LockWrite(Handle, bodyID));
        }
    }
}
