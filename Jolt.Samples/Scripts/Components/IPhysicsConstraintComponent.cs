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
        public SpringMode Mode;
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
    
    public interface IPhysicsConstraintComponent 
    {
        public void CreateConstraint(PhysicsSystem system);
    }
}