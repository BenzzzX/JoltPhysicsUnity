using Unity.Mathematics;
using UnityEngine;

namespace Jolt.Integration
{
    [RequireComponent(typeof(PhysicsBody))]
    public class PhysicsConstraintHinge : MonoBehaviour, IPhysicsConstraintComponent
    {
        public PhysicsBody ConnectedBody;
        public ConstraintSpace Space = ConstraintSpace.WorldSpace;
        public float3 Point1 = new float3(0, 0, 0);
        public float3 HingeAxis1 = new float3(0, 1, 0);
        public float3 NormalAxis1 = new float3(0, 0, 1);
        
        public float3 Point2 = new float3(0, 0, 0);
        public float3 HingeAxis2 = new float3(0, 1, 0);
        public float3 NormalAxis2 = new float3(0, 0, 1);

        public float LimitsMin = -360;
        public float LimitsMax = 360;
        public SpringSettings LimitsSpringSettings = SpringSettings.Default;
        public float MaxFrictionTorque = 0;
        public MotorSettings MotorSettings = MotorSettings.Default;
        
        private HingeConstraint? constraint;
        public HingeConstraint Constraint => constraint.Value;
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
            
            var settings = HingeConstraintSettings.Create();
            settings.SetSpace(Space);
            settings.SetPoint1(Point1);
            settings.SetPoint2(Point2);
            settings.SetHingeAxis1(HingeAxis1);
            settings.SetHingeAxis2(HingeAxis2);
            settings.SetNormalAxis1(NormalAxis1);
            settings.SetLimits(math.radians(LimitsMin), math.radians(LimitsMax));
            settings.SetLimitsSpringSettings(LimitsSpringSettings);
            settings.SetMaxFrictionTorque(MaxFrictionTorque);
            settings.SetMotorSettings(MotorSettings);
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