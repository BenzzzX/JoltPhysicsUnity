using System;
using System.Runtime.CompilerServices;

namespace Jolt
{
    internal unsafe struct NativeHandle<T> : IDisposable, IEquatable<NativeHandle<T>> where T : unmanaged
    {

        private T* ptr;
        
        public static NativeHandle<T> CreateOwnedHandle(T* ptr) 
        {
            return new NativeHandle<T> { ptr = ptr };
        }
        
        public static NativeHandle<T> CreateObserveHandle(T* ptr)
        {
            return new NativeHandle<T> { ptr = ptr };
        }

        /// <summary>
        /// Create a NativeHandle to a new pointer with the same safety handle as this handle. If this handle is disposed of, the owned handle will throw if it is dereferenced.
        /// </summary>
        public NativeHandle<U> CreateSharedHandle<U>(U* ptr) where U : unmanaged
        {
            return new NativeHandle<U> { ptr = ptr };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly NativeHandle<U> Reinterpret<U>() where U : unmanaged
        {
            return new NativeHandle<U> { ptr = (U*) ptr };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly T* IntoPointer()
        {
            return ptr;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator T* (NativeHandle<T> handle)
        {
            return handle.IntoPointer();
        }

        #region IDisposable

        public void Dispose()
        {
            ptr = null;
        }

        #endregion

        #region IEquatable

        public bool Equals(NativeHandle<T> other)
        {
            return ptr == other.ptr;
        }

        public override bool Equals(object obj)
        {
            return obj is NativeHandle<T> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((nint) ptr);
        }

        public static bool operator ==(NativeHandle<T> lhs, NativeHandle<T> rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(NativeHandle<T> lhs, NativeHandle<T> rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion
    }
}
