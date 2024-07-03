using System;
using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_HingeConstraintSettings> JPH_HingeConstraint_GetSettings(NativeHandle<JPH_HingeConstraint> constraint)
        {
            return CreateOwnedHandle(constraint, UnsafeBindings.JPH_HingeConstraint_GetSettings(constraint));
        }
        
        public static float JPH_HingeConstraint_GetCurrentAngle(NativeHandle<JPH_HingeConstraint> constraint)
        {
            return UnsafeBindings.JPH_HingeConstraint_GetCurrentAngle(constraint);
        }
        
        public static void JPH_HingeConstraint_SetMaxFrictionTorque(NativeHandle<JPH_HingeConstraint> constraint, float maxFrictionTorque)
        {
            UnsafeBindings.JPH_HingeConstraint_SetMaxFrictionTorque(constraint, maxFrictionTorque);
        }
        
        public static float JPH_HingeConstraint_GetMaxFrictionTorque(NativeHandle<JPH_HingeConstraint> constraint)
        {
            return UnsafeBindings.JPH_HingeConstraint_GetMaxFrictionTorque(constraint);
        }
        
        public static void JPH_HingeConstraint_SetMotorSettings(NativeHandle<JPH_HingeConstraint> constraint, JPH_MotorSettings motorSettings)
        {
            UnsafeBindings.JPH_HingeConstraint_SetMotorSettings(constraint, &motorSettings);
        }
        
        public static JPH_MotorSettings JPH_HingeConstraint_GetMotorSettings(NativeHandle<JPH_HingeConstraint> constraint)
        {
            JPH_MotorSettings motorSettings;
            UnsafeBindings.JPH_HingeConstraint_GetMotorSettings(constraint, &motorSettings);
            return motorSettings;
        }
        
        public static void JPH_HingeConstraint_SetMotorState(NativeHandle<JPH_HingeConstraint> constraint, MotorState motorState)
        {
            UnsafeBindings.JPH_HingeConstraint_SetMotorState(constraint, motorState);
        }
        
        public static MotorState JPH_HingeConstraint_GetMotorState(NativeHandle<JPH_HingeConstraint> constraint)
        {
            return UnsafeBindings.JPH_HingeConstraint_GetMotorState(constraint);
        }
        
        public static void JPH_HingeConstraint_SetTargetAngularVelocity(NativeHandle<JPH_HingeConstraint> constraint, float targetAngularVelocity)
        {
            UnsafeBindings.JPH_HingeConstraint_SetTargetAngularVelocity(constraint, targetAngularVelocity);
        }
        
        public static float JPH_HingeConstraint_GetTargetAngularVelocity(NativeHandle<JPH_HingeConstraint> constraint)
        {
            return UnsafeBindings.JPH_HingeConstraint_GetTargetAngularVelocity(constraint);
        }
        
        public static void JPH_HingeConstraint_SetTargetAngle(NativeHandle<JPH_HingeConstraint> constraint, float targetAngle)
        {
            UnsafeBindings.JPH_HingeConstraint_SetTargetAngle(constraint, targetAngle);
        }
        
        public static float JPH_HingeConstraint_GetTargetAngle(NativeHandle<JPH_HingeConstraint> constraint)
        {
            return UnsafeBindings.JPH_HingeConstraint_GetTargetAngle(constraint);
        }
        
        public static void JPH_HingeConstraint_SetLimits(NativeHandle<JPH_HingeConstraint> constraint, float minAngle, float maxAngle)
        {
            UnsafeBindings.JPH_HingeConstraint_SetLimits(constraint, minAngle, maxAngle);
        }
        
        public static float JPH_HingeConstraint_GetLimitsMin(NativeHandle<JPH_HingeConstraint> constraint)
        {
            return UnsafeBindings.JPH_HingeConstraint_GetLimitsMin(constraint);
        }
        
        public static float JPH_HingeConstraint_GetLimitsMax(NativeHandle<JPH_HingeConstraint> constraint)
        {
            return UnsafeBindings.JPH_HingeConstraint_GetLimitsMax(constraint);
        }
        
        public static bool JPH_HingeConstraint_HasLimits(NativeHandle<JPH_HingeConstraint> constraint)
        {
            return UnsafeBindings.JPH_HingeConstraint_HasLimits(constraint);
        }
        
        public static void JPH_HingeConstraint_SetLimitsSpringSettings(NativeHandle<JPH_HingeConstraint> constraint, JPH_SpringSettings springSettings)
        {
            UnsafeBindings.JPH_HingeConstraint_SetLimitsSpringSettings(constraint, &springSettings);
        }
        
        public static JPH_SpringSettings JPH_HingeConstraint_GetLimitsSpringSettings(NativeHandle<JPH_HingeConstraint> constraint)
        {
            JPH_SpringSettings springSettings;
            UnsafeBindings.JPH_HingeConstraint_GetLimitsSpringSettings(constraint, &springSettings);
            return springSettings;
        }
        
        public static float3 JPH_HingeConstraint_GetTotalLambdaPosition(NativeHandle<JPH_HingeConstraint> constraint)
        {
            float3 result;
            UnsafeBindings.JPH_HingeConstraint_GetTotalLambdaPosition(constraint, &result);
            return result;
        }
        
        public static void JPH_HingeConstraint_GetTotalLambdaRotation(NativeHandle<JPH_HingeConstraint> constraint, out float x, out float y)
        {
            float x1;
            float y1;
            UnsafeBindings.JPH_HingeConstraint_GetTotalLambdaRotation(constraint, &x1, &y1);
            x = x1;
            y = y1;
        }
        
        public static float JPH_HingeConstraint_GetTotalLambdaRotationLimits(NativeHandle<JPH_HingeConstraint> constraint)
        {
            return UnsafeBindings.JPH_HingeConstraint_GetTotalLambdaRotationLimits(constraint);
        }
        
        public static float JPH_HingeConstraint_GetTotalLambdaMotor(NativeHandle<JPH_HingeConstraint> constraint)
        {
            return UnsafeBindings.JPH_HingeConstraint_GetTotalLambdaMotor(constraint);
        }
    }
}
