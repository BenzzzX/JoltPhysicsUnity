using System.Runtime.CompilerServices;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static NativeHandle<T> CreateHandle<T>(T* ptr) where T : unmanaged
        {
            return NativeHandle<T>.CreateOwnedHandle(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static NativeHandle<U> CreateSharedHandle<T, U>(NativeHandle<T> owner, U* ptr) where T : unmanaged where U : unmanaged
        {
            return owner.CreateSharedHandle(ptr);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static NativeHandle<T> CreateObserveHandle<T>(T* ptr) where T : unmanaged
        {
            return NativeHandle<T>.CreateObserveHandle(ptr);
        }
    }
}
