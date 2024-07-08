using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;

namespace Jolt.Samples
{
    public enum PhysicsSamplesLayers : ushort
    {
        Static = 1,
        Moving = 1,
    }
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

        List<PhysicsBody> managedGameObjects;
        NativeList<BodyID> bodyIds;
        TransformAccessArray transforms;
        
        
        public static BodyID CreateBodyFromGameObject(BodyInterface bodies, GameObject gobj)
        {
            var body = gobj.GetComponent<PhysicsBody>();

            Debug.Assert(body != null, "The GameObject must have a PhysicsBody component.");

            gobj.TryGetComponent(out IPhysicsShapeComponent shapeComponent);
            if(shapeComponent == null)
            {
                shapeComponent = gobj.AddComponent<PhysicsShapeCompound>();
            }

            var shape = shapeComponent.ShapeSettings;

            var pos = (float3) body.transform.position;
            var rot = (quaternion) body.transform.rotation;

            var layer = body.MotionType == MotionType.Static
                ? (ushort)PhysicsSamplesLayers.Static
                : (ushort)PhysicsSamplesLayers.Moving;

            var activation = body.MotionType == MotionType.Static
                ? Activation.DontActivate
                : Activation.Activate;

            var settings = BodyCreationSettings.FromShapeSettings(
                shape, pos, rot, body.MotionType, layer
            );

            return bodies.CreateAndAddBody(settings, activation);
        }

        private void Start()
        {
            managedGameObjects = new();
            bodyIds = new NativeList<BodyID>();
            transforms = new TransformAccessArray();
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

            managedGameObjects.AddRange(FindObjectsByType<PhysicsBody>(FindObjectsSortMode.None));
            transforms = new TransformAccessArray(managedGameObjects.Count);
            bodyIds = new NativeList<BodyID>(managedGameObjects.Count, Allocator.Persistent);
            foreach (var authoring in managedGameObjects)
            {
                authoring.BodyID = CreateBodyFromGameObject(bodies, authoring.gameObject);
                transforms.Add(authoring.transform);
                bodyIds.Add(authoring.BodyID.Value);
            }

            foreach (var authoring in managedGameObjects)
            {
                IPhysicsConstraintComponent[] constraints = authoring.gameObject.GetComponents<IPhysicsConstraintComponent>();
                foreach(var constraint in constraints)
                {
                    CreateConstraint(constraint);
                }
            }
            

            system.OptimizeBroadPhase();
        }

        private void CreateConstraint(IPhysicsConstraintComponent c)
        {
            c.CreateConstraint(system);
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

        [BurstCompile]
        struct UpdateManagedTransformsJob : IJobParallelForTransform
        {
            public NativeArray<BodyID> BodyIds;
            [NativeDisableUnsafePtrRestriction]
            public BodyLockInterface bodyLock;
            public void Execute(int index, TransformAccess transform)
            {
                using (var l = bodyLock.LockRead(BodyIds[index]))
                {
                    var physicsTransform = l.Body.GetWorldTransform();
                    transform.position = physicsTransform.c3.xyz;
                    transform.rotation = new quaternion(physicsTransform);
                }
            }
        }

        private void UpdateManagedTransforms()
        {
            UpdateManagedTransformsJob job = new UpdateManagedTransformsJob();
            job.BodyIds = bodyIds.AsArray();
            job.bodyLock = bodyLock;
            job.Schedule(transforms).Complete();
        }

        private void OnDestroy()
        {
            transforms.Dispose();
            bodyIds.Dispose();
            system.Dispose();
        }
    }
}
