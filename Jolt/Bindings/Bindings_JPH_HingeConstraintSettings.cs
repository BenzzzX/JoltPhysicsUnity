using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_HingeConstraintSettings> JPH_HingeConstraintSettings_Create()
        {
            return CreateHandle(UnsafeBindings.JPH_HingeConstraintSettings_Create());
        }
        
        public static rvec3 JPH_HingeConstraintSettings_GetPoint1(NativeHandle<JPH_HingeConstraintSettings> settings)
        {
            rvec3 point;
            UnsafeBindings.JPH_HingeConstraintSettings_GetPoint1(settings, &point);
            return point;
        }
        
        public static void JPH_HingeConstraintSettings_SetPoint1(NativeHandle<JPH_HingeConstraintSettings> settings, rvec3 point)
        {
            UnsafeBindings.JPH_HingeConstraintSettings_SetPoint1(settings, &point);
        }
        
        public static rvec3 JPH_HingeConstraintSettings_GetPoint2(NativeHandle<JPH_HingeConstraintSettings> settings)
        {
            rvec3 point;
            UnsafeBindings.JPH_HingeConstraintSettings_GetPoint2(settings, &point);
            return point;
        }
        
        public static void JPH_HingeConstraintSettings_SetPoint2(NativeHandle<JPH_HingeConstraintSettings> settings, rvec3 point)
        {
            UnsafeBindings.JPH_HingeConstraintSettings_SetPoint2(settings, &point);
        }
        
        public static rvec3 JPH_HingeConstraintSettings_SetHingeAxis1(NativeHandle<JPH_HingeConstraintSettings> settings)
        {
            float3 axis;
            UnsafeBindings.JPH_HingeConstraintSettings_SetHingeAxis1(settings, &axis);
            return axis;
        }
        
        public static void JPH_HingeConstraintSettings_SetHingeAxis1(NativeHandle<JPH_HingeConstraintSettings> settings, float3 axis)
        {
            UnsafeBindings.JPH_HingeConstraintSettings_SetHingeAxis1(settings, &axis);
        }
        
        public static rvec3 JPH_HingeConstraintSettings_GetHingeAxis2(NativeHandle<JPH_HingeConstraintSettings> settings)
        {
            float3 axis;
            UnsafeBindings.JPH_HingeConstraintSettings_GetHingeAxis2(settings, &axis);
            return axis;
        }
        
        public static void JPH_HingeConstraintSettings_SetHingeAxis2(NativeHandle<JPH_HingeConstraintSettings> settings, float3 axis)
        {
            UnsafeBindings.JPH_HingeConstraintSettings_SetHingeAxis2(settings, &axis);
        }
        
        public static float3 JPH_HingeConstraintSettings_GetNormalAxis1(NativeHandle<JPH_HingeConstraintSettings> settings)
        {
            float3 axis;
            UnsafeBindings.JPH_HingeConstraintSettings_GetNormalAxis1(settings, &axis);
            return axis;
        }
        
        public static void JPH_HingeConstraintSettings_SetNormalAxis1(NativeHandle<JPH_HingeConstraintSettings> settings, float3 axis)
        {
            UnsafeBindings.JPH_HingeConstraintSettings_SetNormalAxis1(settings, &axis);
        }
        
        public static float3 JPH_HingeConstraintSettings_GetNormalAxis2(NativeHandle<JPH_HingeConstraintSettings> settings)
        {
            float3 axis;
            UnsafeBindings.JPH_HingeConstraintSettings_GetNormalAxis2(settings, &axis);
            return axis;
        }
        
        public static void JPH_HingeConstraintSettings_SetNormalAxis2(NativeHandle<JPH_HingeConstraintSettings> settings, float3 axis)
        {
            UnsafeBindings.JPH_HingeConstraintSettings_SetNormalAxis2(settings, &axis);
        }
        
        public static NativeHandle<JPH_HingeConstraint> JPH_HingeConstraintSettings_CreateConstraint(NativeHandle<JPH_HingeConstraintSettings> settings, NativeHandle<JPH_Body> body1, NativeHandle<JPH_Body> body2)
        {
            return CreateHandle(UnsafeBindings.JPH_HingeConstraintSettings_CreateConstraint(settings, body1, body2));
        }
    }
}