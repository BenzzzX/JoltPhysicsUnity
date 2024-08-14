using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace Jolt.Integration
{
    public interface IPhysicsBody
    {
        void OnBodyCreated(BodyID bodyID);
    }

    public class PhysicsBody : MonoBehaviour
    {
        public BodyID? BodyID;

        [Tooltip( "World space linear velocity of the center of mass (m/s)" )]
        public float3 linearVelocity;
        [Tooltip( "World space angular velocity (rad/s)" )]
        public float3 angularVelocity;
        
        [Tooltip( "The collision layer this body belongs to (determines if two objects can collide)" )]
        public ObjectLayer Layer;
        [FormerlySerializedAs("MotionType")] 
        public MotionType motionType;
        [Tooltip( "Which degrees of freedom this body has (can be used to limit simulation to 2D" )]
        public AllowedDOFs allowedDoFs = AllowedDOFs.All;
        [Tooltip( "When this body is created as static, this setting tells the system to create a MotionProperties object so that the object can be switched to kinematic or dynamic" )]
        public bool allowDynamicOrKinematic = false;
        [Tooltip("If this body is a sensor. " +
                 "A sensor will receive collision callbacks, but will not cause any collision responses and can be used as a trigger volume. " +
                 "See description at Body::SetIsSensor.")]
        public bool isSensor = false;
        [Tooltip("If kinematic objects can generate contact points against other kinematic or static objects. " +
                 "See description at Body::SetCollideKinematicVsNonDynamic.")]
        public bool collideKinematicVsNonDynamic = false;
        [Tooltip("If this body should use manifold reduction (see description at Body::SetUseManifoldReduction)")]
        public bool useManifoldReduction = true;
        [Tooltip("Set to indicate that the gyroscopic force should be applied to this body (aka Dzhanibekov effect, see https://en.wikipedia.org/wiki/Tennis_racket_theorem)")]
        public bool applyGyroscopicForce = false;
        [Tooltip("Motion quality, or how well it detects collisions when it has a high velocity")]
        public MotionQuality motionQuality = MotionQuality.Discrete;
        [Tooltip("Set to indicate that extra effort should be made to try to remove ghost contacts (collisions with internal edges of a mesh). " +
                 "This is more expensive but makes bodies move smoother over a mesh with convex edges.")]
        public bool enhancedInternalEdgeRemoval = false;
        [Tooltip("If this body can go to sleep or not")]
        public bool allowSleeping = true;
        [Tooltip( "Friction of the body (dimensionless number, usually between 0 and 1, " +
                  "0 = no friction, 1 = friction force equals force that presses the two bodies together). " +
                  "Note that bodies can have negative friction but the combined friction (see PhysicsSystem::SetCombineFriction) should never go below zero." )]
        public float friction = 0.5f;
        [Tooltip("Restitution of body (dimensionless number, usually between 0 and 1, " +
                 "0 = completely inelastic collision response, " +
                 "1 = completely elastic collision response). " +
                 "Note that bodies can have negative restitution but the combined restitution (see PhysicsSystem::SetCombineRestitution) should never go below zero." )]
        public float restitution = 0.5f;
        [Tooltip("Linear damping: dv/dt = -c * v. c must be between 0 and 1 but is usually close to 0.")]
        public float linearDamping = 0.05f;
        [Tooltip("Angular damping: dw/dt = -c * w. c must be between 0 and 1 but is usually close to 0.")]
        public float angularDamping = 0.05f;
        [Tooltip("Maximum linear velocity that this body can reach (m/s)")]
        public float maxLinearVelocity = 500.0f;
        [Tooltip("Maximum angular velocity that this body can reach (rad/s)")]
        public float maxAngularVelocity = 0.25f * math.PI * 60.0f;
        [Tooltip("Value to multiply gravity with for this body")]
        public float gravityFactor = 1.0f;
        [Tooltip("Used only when this body is dynamic and colliding. " +
                 "Override for the number of solver velocity iterations to run, 0 means use the default in PhysicsSettings::mNumVelocitySteps. " +
                 "The number of iterations to use is the max of all contacts and constraints in the island.")]
        public uint numVelocityStepsOverride = 0;
        [Tooltip("Used only when this body is dynamic and colliding. " +
                 "Override for the number of solver position iterations to run, 0 means use the default in PhysicsSettings::mNumPositionSteps. " +
                 "The number of iterations to use is the max of all contacts and constraints in the island.")]
        public uint numPositionStepsOverride = 0;
        [Tooltip("Determines how mMassPropertiesOverride will be used")]
        public OverrideMassProperties overrideMassProperties = OverrideMassProperties.CalculateMassAndInertia;
        [Tooltip("When calculating the inertia (not when it is provided) the calculated inertia will be multiplied by this value")]
        public float inertiaMultiplier = 1.0f;
        [Tooltip("Contains replacement mass settings which override the automatically calculated values")]
        public MassProperties massPropertiesOverride;

        private void Awake()
        {
            if(PhysicsController.Instance != null)
                PhysicsController.Instance.RegisterSpawn(this);
        }
        
        private void OnDestroy()
        {
            if(PhysicsController.Instance != null && BodyID.HasValue)
                PhysicsController.Instance.RegisterDestroy(BodyID.Value);
        }
    }
}