using Unity.Mathematics;
using UnityEngine;

namespace Jolt.Integration
{
    [RequireComponent(typeof(PhysicsBody))]
    public class PhysicsConstraintFixed : MonoBehaviour, IPhysicsConstraintComponent
    {
        public PhysicsBody ConnectedBody;
        public ConstraintSpace Space = ConstraintSpace.WorldSpace;
        public float3 Point1 = new float3(0, 0, 0);
        public float3 AxisX1 = new float3(0, 1, 0);
        public float3 AxisY1 = new float3(0, 0, 1);
        
        public float3 Point2 = new float3(0, 0, 0);
        public float3 AxisX2 = new float3(0, 1, 0);
        public float3 AxisY2 = new float3(0, 0, 1);

        private FixedConstraint? constraint;
        public FixedConstraint Constraint => constraint.Value;
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
            
            var settings = FixedConstraintSettings.Create();
            settings.SetSpace(Space);
            settings.SetPoint1(Point1);
            settings.SetPoint2(Point2);
            settings.SetAxisX1(AxisX1);
            settings.SetAxisX2(AxisX2);
            settings.SetAxisY1(AxisY1);
            settings.SetAxisY2(AxisY2);
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