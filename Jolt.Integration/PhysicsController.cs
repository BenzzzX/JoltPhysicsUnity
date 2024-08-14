using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;

namespace Jolt.Integration
{
    public enum PhysicsSamplesLayers : ushort
    {
        Static = 0,
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
        
        private const float MaxAngularVelocity = 100.0f * math.PI;

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
        
        private static PhysicsController _instance;

        public static PhysicsController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Object.FindFirstObjectByType<PhysicsController>();
                }
                return _instance;
            }
        }

        private const int CollisionSteps = 1;

        private PhysicsSystem system;
        private BodyInterface bodies;
        private BodyInterface bodiesNoLock;
        private BodyLockInterface bodyLockNoLock;
        private NarrowPhaseQuery narrowPhaseQuery;
        private BroadPhaseQuery broadPhaseQuery;
        private NarrowPhaseQuery narrowPhaseQueryNoLock;
        
        public PhysicsSystem System => system;
        public BodyInterface Bodies => bodies;
        public BodyInterface BodiesNoLock => bodiesNoLock;
        public BodyLockInterface BodyLockNoLock => bodyLockNoLock;
        public NarrowPhaseQuery NarrowPhaseQuery => narrowPhaseQuery;
        public BroadPhaseQuery BroadPhaseQuery => broadPhaseQuery;
        public NarrowPhaseQuery NarrowPhaseQueryNoLock => narrowPhaseQueryNoLock;
        
        private BroadPhaseLayerFilter defaultBroadPhaseLayerFilter;
        private ObjectLayerFilter defaultObjectLayerPairFilter;
        private BodyFilter defaultBodyFilter;
        
        public BroadPhaseLayerFilter DefaultBroadPhaseLayerFilter => defaultBroadPhaseLayerFilter;
        public ObjectLayerFilter DefaultObjectLayerPairFilter => defaultObjectLayerPairFilter;
        public BodyFilter DefaultBodyFilter => defaultBodyFilter;

        private List<PhysicsBody> managedGameObjects;
        private NativeList<BodyID> bodyIds;
        private TransformAccessArray transforms;
        private Dictionary<BodyID, PhysicsBody> bodyIDToPhysicsBody;
        
        private List<PhysicsBody> pendingSpawn = new List<PhysicsBody>();
        private List<BodyID> pendingDestroy = new List<BodyID>();
        
        public void Awake()
        {
            _instance = this;
        }
        
        public void Start()
        {
            Initialize();
        }
        
        public void FixedUpdate()
        {
            Tick(Time.fixedDeltaTime);
        }
        
        public void RegisterSpawn(PhysicsBody gobj)
        {
            pendingSpawn.Add(gobj);
        }
        
        public void RegisterDestroy(BodyID bodyID)
        {
            pendingDestroy.Add(bodyID);
        }
        
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

            var layer = body.motionType == MotionType.Static
                ? (ushort)PhysicsSamplesLayers.Static
                : (ushort)PhysicsSamplesLayers.Moving;

            var activation = body.motionType == MotionType.Static
                ? Activation.DontActivate
                : Activation.Activate;

            var settings = BodyCreationSettings.FromShapeSettings(
                shape, pos, rot, body.motionType, layer
            );
            settings.SetAllowedDOFs(body.allowedDoFs);
            settings.SetAllowDynamicOrKinematic(body.allowDynamicOrKinematic);
            settings.SetIsSensor(body.isSensor);
            settings.SetCollideKinematicVsNonDynamic(body.collideKinematicVsNonDynamic);
            settings.SetUseManifoldReduction(body.useManifoldReduction);
            settings.SetApplyGyroscopicForce(body.applyGyroscopicForce);
            settings.SetMotionQuality(body.motionQuality);
            settings.SetEnhancedInternalEdgeRemoval(body.enhancedInternalEdgeRemoval);
            settings.SetAllowSleeping(body.allowSleeping);
            settings.SetFriction(body.friction);
            settings.SetRestitution(body.restitution);
            settings.SetLinearDamping(body.linearDamping);
            settings.SetAngularDamping(body.angularDamping);
            settings.SetMaxLinearVelocity(body.maxLinearVelocity);
            settings.SetMaxAngularVelocity(body.maxAngularVelocity);
            settings.SetGravityFactor(body.gravityFactor);;
            settings.SetNumVelocityStepsOverride(body.numVelocityStepsOverride);
            settings.SetNumPositionStepsOverride(body.numPositionStepsOverride);
            settings.SetOverrideMassProperties(body.overrideMassProperties);
            settings.SetInertiaMultiplier(body.inertiaMultiplier);
            settings.SetMassPropertiesOverride(body.massPropertiesOverride);
            var bodyId = bodies.CreateAndAddBody(settings, activation);
            return bodyId;
        }

        public void Initialize()
        {
            managedGameObjects = new();
            bodyIds = new NativeList<BodyID>();
            transforms = new TransformAccessArray();
            bodyIDToPhysicsBody = new Dictionary<BodyID, PhysicsBody>();
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
            bodiesNoLock = system.GetBodyInterfaceNoLock();
            bodyLockNoLock = system.GetBodyLockInterfaceNoLock();
            narrowPhaseQuery = system.GetNarrowPhaseQuery();
            broadPhaseQuery = system.GetBroadPhaseQuery();
            narrowPhaseQueryNoLock = system.GetNarrowPhaseQueryNoLock();

            defaultBroadPhaseLayerFilter = BroadPhaseLayerFilter.Create();
            defaultObjectLayerPairFilter = ObjectLayerFilter.Create();
            defaultBodyFilter = BodyFilter.Create();

            foreach (var addon in GetComponents<IPhysicsSystemAddon>())
            {
                addon.Initialize(system); // initialize any adjacent addons
            }

            HandleDestroryAndSpawn();
        }
        
        public PhysicsBody GetPhysicsBody(BodyID bodyID)
        {
            // if (bodyIDToPhysicsBody.TryGetValue(bodyID, out var physicsBody))
            // {
            //     return physicsBody;
            // }
            // return null;
            return managedGameObjects[(int) bodiesNoLock.GetUserData(bodyID)];
        }
        
        private void HandleDestroryAndSpawn()
        {
            bool any = pendingDestroy.Count > 0 || pendingSpawn.Count > 0;
            if(!any)
                return;
            foreach (var bodyID in pendingDestroy)
            {
                bodiesNoLock.RemoveBody(bodyID);
                bodiesNoLock.DestroyBody(bodyID);
                int id = bodyIds.IndexOf(bodyID);
                if (id != -1)
                {
                    bodyIds.RemoveAtSwapBack(id);
                    transforms.RemoveAtSwapBack(id);
                    managedGameObjects.RemoveAtSwapBack(id);
                    bodyIDToPhysicsBody.Remove(bodyID);
                    if(id < bodyIds.Length)
                        bodiesNoLock.SetUserData(bodyIds[id], (ulong)id);
                }
                else
                {
                    Debug.LogError("Destroying a body that is not in the list.");
                }
            }
            pendingDestroy.Clear();

            if (!bodyIds.IsCreated)
            {
                bodyIds = new NativeList<BodyID>(pendingSpawn.Count, Allocator.Persistent);
                managedGameObjects.Capacity = pendingSpawn.Count;
                transforms = new TransformAccessArray(pendingSpawn.Count);
            }
            else if(!bodyIds.IsCreated || bodyIds.Capacity < bodyIds.Length + pendingSpawn.Count)
            {
                bodyIds.SetCapacity(bodyIds.Length + pendingSpawn.Count);
                managedGameObjects.Capacity = bodyIds.Length + pendingSpawn.Count;
                transforms.capacity = bodyIds.Length + pendingSpawn.Count;
            }
            foreach (var gobj in pendingSpawn)
            {
                var localId = bodyIds.Length;
                managedGameObjects.Add(gobj);
                gobj.BodyID = CreateBodyFromGameObject(bodiesNoLock, gobj.gameObject);
                transforms.Add(gobj.transform);
                bodyIds.Add(gobj.BodyID.Value);
                bodiesNoLock.SetUserData(gobj.BodyID.Value, (ulong)localId);
                bodyIDToPhysicsBody.Add(gobj.BodyID.Value, gobj);
            }
            foreach (var gobj in pendingSpawn)
            {
                IPhysicsConstraintComponent[] constraints = gobj.GetComponents<IPhysicsConstraintComponent>();
                foreach(var constraint in constraints)
                {
                    constraint.CreateConstraint(system);
                }
            }

            foreach (var gobj in pendingSpawn)
            {
                IPhysicsBody[] physicsBodies = gobj.GetComponents<IPhysicsBody>();
                foreach(var physicsBody in physicsBodies)
                {
                    physicsBody.OnBodyCreated(gobj.BodyID.Value);
                }
            }
            pendingSpawn.Clear();
            
            system.OptimizeBroadPhase();
        }

        public void Tick(float deltaTime)
        {
            HandleDestroryAndSpawn();
            if (system.Step(deltaTime, CollisionSteps, out var error))
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
            job.bodyLock = bodyLockNoLock;
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
