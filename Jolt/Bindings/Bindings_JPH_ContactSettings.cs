using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_ContactSettings_SetRelativeLinearSurfaceVelocity(NativeHandle<JPH_ContactSettings> settings, float3 velocity)
        {
            UnsafeBindings.JPH_ContactSettings_SetRelativeLinearSurfaceVelocity(settings, &velocity);
        }
        public static void JPH_ContactSettings_SetRelativeAngularSurfaceVelocity(NativeHandle<JPH_ContactSettings> settings, float3 velocity)
        {
            UnsafeBindings.JPH_ContactSettings_SetRelativeAngularSurfaceVelocity(settings, &velocity);
        }
    }
}