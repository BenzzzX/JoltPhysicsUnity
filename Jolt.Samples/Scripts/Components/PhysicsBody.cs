using UnityEngine;
using UnityEngine.Serialization;

namespace Jolt.Samples
{
    public class PhysicsBody : MonoBehaviour
    {
        public MotionType MotionType;
        public BodyID? BodyID;
        
        [Tooltip("Restitution of body (dimensionless number, usually between 0 and 1, " +
                 "0 = completely inelastic collision response, " +
                 "1 = completely elastic collision response). " +
                 "Note that bodies can have negative restitution but the combined restitution (see PhysicsSystem::SetCombineRestitution) should never go below zero." )]
        public float restitution = 0.5f;
        [Tooltip( "Friction of the body (dimensionless number, usually between 0 and 1, " +
                  "0 = no friction, 1 = friction force equals force that presses the two bodies together). " +
                  "Note that bodies can have negative friction but the combined friction (see PhysicsSystem::SetCombineFriction) should never go below zero." )]
        public float friction = 0.5f;
        
        public float mass = 1f;
        [Tooltip( "Which degrees of freedom this body has (can be used to limit simulation to 2D" )]
        public AllowedDOFs allowedDoFs = AllowedDOFs.All;
    }
}