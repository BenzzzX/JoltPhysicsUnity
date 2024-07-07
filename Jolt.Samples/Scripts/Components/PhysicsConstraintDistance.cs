using Unity.Mathematics;
using UnityEngine;

namespace Jolt.Samples
{
    [RequireComponent(typeof(PhysicsBody))]
    public class PhysicsConstraintDistance : MonoBehaviour, IPhysicsConstraintComponent
    {
        public PhysicsBody ConnectedBody;
        public ConstraintSpace Space = ConstraintSpace.WorldSpace;
        public float3 Point1 = new float3(0, 0, 0);
        public float3 Point2 = new float3(0, 0, 0);
        public float MinDistance = 0;
        public float MaxDistance = 0;
        public SpringSettings LimitsSpringSettings = SpringSettings.Default;

        private DistanceConstraint? constraint;
        public DistanceConstraint Constraint => constraint.Value;
        public bool IsCreated => constraint.HasValue;
        
        public void CreateConstraint(PhysicsSystem system)
        {
            var bodyID = GetComponent<PhysicsBody>().BodyID;
            if (ConnectedBody == null)
            {
                Debug.LogError("ConnectedBody is null");
                return;
            }
            var connectedBodyID = ConnectedBody.BodyID;
            if (!connectedBodyID.HasValue)
            {
                Debug.LogError("ConnectedBody does not have a BodyID");
                return;
            }
            
            var settings = DistanceConstraintSettings.Create();
            settings.SetSpace(Space);
            settings.SetPoint1(Point1);
            settings.SetPoint2(Point2);
            settings.SetMinDistance(MinDistance);
            settings.SetMaxDistance(MaxDistance);
            settings.SetLimitsSpringSettings(LimitsSpringSettings);
            var locker = system.GetBodyLockInterfaceNoLock();
            using (var lockA = locker.LockRead(bodyID.Value))
            using (var lockB = locker.LockRead(connectedBodyID.Value))
            {
                constraint = settings.CreateConstraint(lockA.Body, lockB.Body);
                system.AddConstraint(constraint.Value);
            }
        }
    }
}