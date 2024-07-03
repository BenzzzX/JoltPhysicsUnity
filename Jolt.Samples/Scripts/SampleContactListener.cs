using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Jolt.Samples
{
    public class SampleContactListener : MonoBehaviour, IPhysicsSystemAddon, IContactListener
    {
        [SerializeField]
        private List<GameObject> belts = new();
        private List<BodyID> beltBodyIDs = new();
        private BodyInterface bodies;
        
        public void Initialize(PhysicsSystem system)
        {
            beltBodyIDs = new();
            system.SetContactListener(this);
            bodies = system.GetBodyInterface();
        }
        
        public void Update()
        {
            beltBodyIDs.Clear();
            foreach (var belt in belts)
            {
                var  beltBodyID = GetComponent<PhysicsController>().GetBodyID(belt);
                if (beltBodyID.HasValue)
                {
                    bodies.SetFriction(beltBodyID.Value, 1f);
                    beltBodyIDs.Add(beltBodyID.Value);
                }
            }
        }

        public ValidateResult OnContactValidate()
        {
            Debug.Log("OnContactValidate");

            return ValidateResult.AcceptAllContactsForThisBodyPair;
        }

        void TryAddVelocity(Body bodyA, Body bodyB, ContactSettings settings)
        {
            if (beltBodyIDs.Count == 0)
                return;
            float3 localSpaceVelocity = new float3(0, 0, -10f);
            bool bodyALinearBelt = beltBodyIDs.Contains(bodyA.GetID());
            bool bodyBLinearBelt = beltBodyIDs.Contains(bodyB.GetID());
            if(bodyALinearBelt || bodyBLinearBelt)
            {
                float3 bodyALinearSurfaceVelocity = bodyALinearBelt ? math.mul(bodyA.GetRotation(), localSpaceVelocity) : float3.zero;
                float3 bodyBLinearSurfaceVelocity = bodyBLinearBelt ? math.mul(bodyB.GetRotation(), localSpaceVelocity) : float3.zero;
                settings.SetRelativeLinearSurfaceVelocity(bodyALinearSurfaceVelocity - bodyBLinearSurfaceVelocity);
            }
        }

        void IContactListener.OnContactAdded(Body bodyA, Body bodyB, ContactSettings settings)
        {
            TryAddVelocity(bodyA, bodyB, settings);
        }

        public void OnContactPersisted(Body bodyA, Body bodyB, ContactSettings settings)
        {
            TryAddVelocity(bodyA, bodyB, settings);
        }

        public void OnContactRemoved()
        {
            Debug.Log("OnContactRemoved");
        }
    }
}
