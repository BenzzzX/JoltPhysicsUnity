using System.Collections.Generic;
using UnityEngine;

namespace Jolt.Samples
{
    public class PhysicsController : MonoBehaviour
    {
        /// <summary>
        /// The max amount of rigid bodies that can be added to the physics system. Adding more will raise a native exception.
        /// </summary>
        /// <remarks>
        /// This is intentionally low for the samples. For a real project, use something in the order of 65536.
        /// </remarks>
        private const uint MaxBodies = 1024;

        /// <summary>
        /// The max amount of body pairs that can be queued at any time. If this is too small, the queue will fill up and the broad phase jobs will start to do narrow phase work. This is slightly less efficient.
        /// </summary>
        /// <remarks>
        /// This is intentionally low for the samples. For a real project, use something in the order of 65536.
        /// </remarks>
        private const uint MaxBodyPairs = 1024;

        /// <summary>
        /// The maximum size of the contact constraint buffer. If more contacts are detected, these contacts will be ignored and bodies will start interpenetrating / fall through the world.
        /// </summary>
        /// <remarks>
        /// This is intentionally low for the samples. For a real project, use something in the order of 10240.
        /// </remarks>
        private const uint MaxContactConstraints = 1024;

        private static class ObjectLayers
        {
            public static readonly ObjectLayer Static = 0;
            public static readonly ObjectLayer Moving = 1;
            public const uint NumLayers = 2;
        }

        private static class BroadPhaseLayers
        {
            public static readonly BroadPhaseLayer Static = 0;
            public static readonly BroadPhaseLayer Moving = 1;
            public const uint NumLayers = 2;
        }

        private const int CollisionSteps = 1;

        private PhysicsSystem system;
        private BodyInterface bodies;
        private BodyLockInterface bodyLock;

        private List<(BodyID, GameObject)> managedGameObjects = new();

        public BodyID? GetBodyID(GameObject gobj)
        {
            foreach (var (bodyID, gameObject) in managedGameObjects)
            {
                if (gameObject == gobj)
                {
                    return bodyID;
                }
            }

            return null;
        }

        private void Start()
        {
            var objectLayerPairFilter = ObjectLayerPairFilterTable.Create(ObjectLayers.NumLayers);

            objectLayerPairFilter.EnableCollision(ObjectLayers.Static, ObjectLayers.Moving);
            objectLayerPairFilter.EnableCollision(ObjectLayers.Moving, ObjectLayers.Moving);

            var broadPhaseLayerInterface = BroadPhaseLayerInterfaceTable.Create(ObjectLayers.NumLayers, BroadPhaseLayers.NumLayers);

            broadPhaseLayerInterface.MapObjectToBroadPhaseLayer(ObjectLayers.Static, BroadPhaseLayers.Static);
            broadPhaseLayerInterface.MapObjectToBroadPhaseLayer(ObjectLayers.Moving, BroadPhaseLayers.Moving);

            var objectVsBroadPhaseLayerFilter = ObjectVsBroadPhaseLayerFilterTable.Create(broadPhaseLayerInterface, BroadPhaseLayers.NumLayers, objectLayerPairFilter, ObjectLayers.NumLayers);

            var settings = new PhysicsSystemSettings
            {
                MaxBodies = MaxBodies,
                MaxBodyPairs = MaxBodyPairs,
                MaxContactConstraints = MaxContactConstraints,
                ObjectLayerPairFilter = objectLayerPairFilter,
                BroadPhaseLayerInterface = broadPhaseLayerInterface,
                ObjectVsBroadPhaseLayerFilter = objectVsBroadPhaseLayerFilter,
            };

            system = new PhysicsSystem(settings);
            bodies = system.GetBodyInterface();
            bodyLock = system.GetBodyLockInterfaceNoLock();

            foreach (var addon in GetComponents<IPhysicsSystemAddon>())
            {
                addon.Initialize(system); // initialize any adjacent addons
            }

            var authorings = FindObjectsByType<PhysicsBody>(FindObjectsSortMode.None);
            foreach (var authoring in authorings)
            {
                var bodyID = PhysicsHelpers.CreateBodyFromGameObject(bodies, authoring.gameObject);
                managedGameObjects.Add((bodyID, authoring.gameObject));
            }

            foreach (var authoring in authorings)
            {
                IPhysicsConstraintComponent constraint = authoring.gameObject.GetComponent<IPhysicsConstraintComponent>();
                if (constraint != null)
                {
                    CreateConstraint(constraint);
                }
            }
            

            system.OptimizeBroadPhase();
        }

        private void CreateConstraint(IPhysicsConstraintComponent c)
        {
            if (c is PhysicsHingeConstraint hinge)
            {
                var settings = HingeConstraintSettings.Create();
                settings.SetPoint1(hinge.Point1);
                settings.SetPoint2(hinge.Point2);
                settings.SetHingeAxis1(hinge.HingeAxis1);
                settings.SetHingeAxis2(hinge.HingeAxis2);
                settings.SetNormalAxis1(hinge.NormalAxis1);
                var bodyAID = GetBodyID(hinge.gameObject);
                var bodyBID = GetBodyID(hinge.ConnectedBody.gameObject);
                HingeConstraint constraint;
                using(var lockA = bodyLock.LockRead(bodyAID.Value))
                using(var lockB = bodyLock.LockRead(bodyBID.Value))
                {
                    constraint = settings.CreateConstraint(lockA.Body, lockB.Body);
                }
                constraint.SetLimits(hinge.LimitsMin, hinge.LimitsMax);
                constraint.SetLimitsSpringSettings(hinge.LimitsSpringSettings);
                constraint.SetMaxFrictionTorque(hinge.MaxFrictionTorque);
                constraint.SetMotorSettings(hinge.MotorSettings);
                system.AddConstraint(constraint);
            }
        }

        private void FixedUpdate()
        {
            if (system.Step(Time.fixedDeltaTime, CollisionSteps, out var error))
            {
                UpdateManagedTransforms();
            }
            else
            {
                Debug.LogError(error);
            }
        }

        private void UpdateManagedTransforms()
        {
            foreach (var (bodyID, gobj) in managedGameObjects)
            {
                PhysicsHelpers.ApplyTransform(bodies, bodyID, gobj.transform);
            }
        }

        private void OnDestroy()
        {
            system.Dispose();
        }
    }
}
