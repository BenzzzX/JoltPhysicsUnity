using Unity.Mathematics;
using UnityEngine;

namespace Jolt.Samples
{
    public enum SpringMode
    {
        FrequencyAndDamping,
        StiffnessAndDamping
    }
    [System.Serializable]
    public struct SpringSettings
    {
        SpringMode Mode;
        public float FrequencyOrStiffness;
        public float Damping;
        public static SpringSettings Default => new SpringSettings { Mode = SpringMode.FrequencyAndDamping, FrequencyOrStiffness = 0, Damping = 0 };
        
        public static implicit operator JPH_SpringSettings(SpringSettings settings)
        {
            return new JPH_SpringSettings
            {
                mode = settings.Mode == SpringMode.FrequencyAndDamping ? JPH_SpringMode.JPH_SpringMode_FrequencyAndDamping : JPH_SpringMode.JPH_SpringMode_StiffnessAndDamping,
                frequencyOrStiffness = settings.FrequencyOrStiffness,
                damping = settings.Damping
            };
        }
    }
    [System.Serializable]
    public struct MotorSettings
    {
        public SpringSettings SpringSettings;
        public float MinForceLimit;
        public float MaxForceLimit;
        public float MinTorqueLimit;
        public float MaxTorqueLimit;
        public static MotorSettings Default => new MotorSettings
        {
            SpringSettings = new SpringSettings { FrequencyOrStiffness = 2, Damping = 1 },
            MinForceLimit = -math.INFINITY,
            MaxForceLimit = math.INFINITY,
            MinTorqueLimit = -math.INFINITY,
            MaxTorqueLimit = math.INFINITY
        };
        
        public static implicit operator JPH_MotorSettings(MotorSettings settings)
        {
            return new JPH_MotorSettings
            {
                springSettings = settings.SpringSettings,
                minForceLimit = settings.MinForceLimit,
                maxForceLimit = settings.MaxForceLimit,
                minTorqueLimit = settings.MinTorqueLimit,
                maxTorqueLimit = settings.MaxTorqueLimit
            };
        }
    }
    public class PhysicsHingeConstraint : MonoBehaviour, IPhysicsConstraintComponent
    {
        public PhysicsBody ConnectedBody;
        public ConstraintSpace Space = ConstraintSpace.WorldSpace;
        public float3 Point1 = new float3(0, 0, 0);
        public float3 HingeAxis1 = new float3(0, 1, 0);
        public float3 NormalAxis1 = new float3(0, 0, 1);
        
        public float3 Point2 = new float3(0, 0, 0);
        public float3 HingeAxis2 = new float3(0, 1, 0);
        public float3 NormalAxis2 = new float3(0, 0, 1);

        public float LimitsMin = -math.PI;
        public float LimitsMax = math.PI;
        public SpringSettings LimitsSpringSettings = SpringSettings.Default;
        public float MaxFrictionTorque = 0;
        public MotorSettings MotorSettings = MotorSettings.Default;
    }
}