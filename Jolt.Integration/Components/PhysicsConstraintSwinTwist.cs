using System;
using Unity.Mathematics;
using UnityEngine;

namespace Jolt.Integration
{
    [RequireComponent(typeof(PhysicsBody))]
    public class PhysicsConstraintSwingTwist : MonoBehaviour, IPhysicsConstraintComponent
    {
        public PhysicsBody ConnectedBody;
        public ConstraintSpace Space = ConstraintSpace.WorldSpace;
        [Tooltip("Position of the Connected Body in world space or the connected body in local space.")]
        public float3 Position1 = new float3(0, 0, 0);
        public float3 TwistAxis1 = new float3(0, 1, 0);
        public float3 PlaneAxis1 = new float3(0, 0, 1);
        [Tooltip("Position of the Self Body in world space or the connected body in local space.")]
        public float3 Position2 = new float3(0, 0, 0);
        public float3 TwistAxis2 = new float3(0, 1, 0);
        public float3 PlaneAxis2 = new float3(0, 0, 1);

        public JPH_SwingType SwingType = JPH_SwingType.JPH_SwingType_Cone;
        
        public float NormalHalfConeAngle = 0;
        public float PlaneHalfConeAngle = 0;

        public float TwistMinAngle = 0;
        public float TwistMaxAngle = 0;
        
        public float MaxFrictionTorque = 0;
        public MotorSettings SwingMotorSettings = MotorSettings.Default;
        public MotorSettings TwistMotorSettings = MotorSettings.Default;
        
        private SwingTwistConstraint? constraint;
        public SwingTwistConstraint Constraint => constraint.Value;
        public bool IsCreated => constraint.HasValue;

        private void OnValidate()
        {
            NormalHalfConeAngle = math.clamp(NormalHalfConeAngle, -180, 180);
            PlaneHalfConeAngle = math.clamp(PlaneHalfConeAngle, -180, 180);
        }

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
                var name = ConnectedBody.gameObject.name;
                Debug.LogError($"ConnectedBody {name} does not have a BodyID");
                return;
            }
            
            var settings = SwingTwistConstraintSettings.Create();
            settings.SetSpace(Space);
            settings.SetPosition1(Position1);
            settings.SetPosition2(Position2);
            settings.SetTwistAxis1(TwistAxis1);
            settings.SetTwistAxis2(TwistAxis2);
            settings.SetPlaneAxis1(PlaneAxis1);
            settings.SetPlaneAxis2(PlaneAxis2);
            settings.SetSwingType(SwingType);
            settings.SetNormalHalfConeAngle(math.radians(NormalHalfConeAngle));
            settings.SetPlaneHalfConeAngle(math.radians(PlaneHalfConeAngle));
            settings.SetTwistMinAngle(math.radians(TwistMinAngle));
            settings.SetTwistMaxAngle(math.radians(TwistMaxAngle));
            settings.SetMaxFrictionTorque(MaxFrictionTorque);
            settings.SetSwingMotorSettings(SwingMotorSettings);
            settings.SetTwistMotorSettings(TwistMotorSettings);
            var locker = system.GetBodyLockInterfaceNoLock();
            using var lockB = locker.LockRead(connectedBodyID.Value);
            System.Diagnostics.Debug.Assert(bodyID != null, nameof(bodyID) + " != null");
            using var lockA = locker.LockRead(bodyID.Value);
            constraint = settings.CreateConstraint(lockB.Body, lockA.Body);
            system.AddConstraint(constraint.Value);
        }
    }
}