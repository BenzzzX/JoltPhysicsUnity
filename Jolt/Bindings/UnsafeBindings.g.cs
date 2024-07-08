using System;
using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace Jolt
{
    public enum JPH_SwingType
    {
        JPH_SwingType_Cone = 0,
        JPH_SwingType_Pyramid = 1,
        _JPH_SwingType_Count,
        _JPH_SwingType_Force32 = 0x7fffffff,
    }

    public enum JPH_SpringMode
    {
        JPH_SpringMode_FrequencyAndDamping = 0,
        JPH_SpringMode_StiffnessAndDamping = 1,
        _JPH_SpringMode_Count,
        _JPH_SpringMode_Force32 = 0x7FFFFFFF,
    }

    public partial struct JPH_SpringSettings
    {
        public JPH_SpringMode mode;

        public float frequencyOrStiffness;

        public float damping;
    }

    public partial struct JPH_MotorSettings
    {
        public JPH_SpringSettings springSettings;

        public float minForceLimit;

        public float maxForceLimit;

        public float minTorqueLimit;

        public float maxTorqueLimit;
    }

    public partial struct JPH_SubShapeIDPair
    {
        [NativeTypeName("JPH_BodyID")]
        public BodyID Body1ID;

        [NativeTypeName("JPH_SubShapeID")]
        public uint subShapeID1;

        [NativeTypeName("JPH_BodyID")]
        public BodyID Body2ID;

        [NativeTypeName("JPH_SubShapeID")]
        public uint subShapeID2;
    }

    public partial struct JPH_BroadPhaseCastResult
    {
        [NativeTypeName("JPH_BodyID")]
        public BodyID bodyID;

        public float fraction;
    }

    public partial struct JPH_RayCastResult
    {
        [NativeTypeName("JPH_BodyID")]
        public BodyID bodyID;

        public float fraction;

        [NativeTypeName("JPH_SubShapeID")]
        public uint subShapeID2;
    }

    public partial struct JPH_CollidePointResult
    {
        [NativeTypeName("JPH_BodyID")]
        public BodyID bodyID;

        [NativeTypeName("JPH_SubShapeID")]
        public uint subShapeID2;
    }

    public partial struct JPH_CollideShapeResult
    {
        [NativeTypeName("JPH_Vec3")]
        public float3 contactPointOn1;

        [NativeTypeName("JPH_Vec3")]
        public float3 contactPointOn2;

        [NativeTypeName("JPH_Vec3")]
        public float3 penetrationAxis;

        public float penetrationDepth;

        [NativeTypeName("JPH_SubShapeID")]
        public uint subShapeID1;

        [NativeTypeName("JPH_SubShapeID")]
        public uint subShapeID2;

        [NativeTypeName("JPH_BodyID")]
        public BodyID bodyID2;
    }

    public partial struct JPH_ShapeCastResult
    {
        [NativeTypeName("JPH_Vec3")]
        public float3 contactPointOn1;

        [NativeTypeName("JPH_Vec3")]
        public float3 contactPointOn2;

        [NativeTypeName("JPH_Vec3")]
        public float3 penetrationAxis;

        public float penetrationDepth;

        [NativeTypeName("JPH_SubShapeID")]
        public uint subShapeID1;

        [NativeTypeName("JPH_SubShapeID")]
        public uint subShapeID2;

        [NativeTypeName("JPH_BodyID")]
        public BodyID bodyID2;

        public float fraction;

        public NativeBool isBackFaceHit;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate float JPH_RayCastBodyCollector(void* context, JPH_BroadPhaseCastResult* result);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void JPH_CollideShapeBodyCollector(void* context, [NativeTypeName("JPH_BodyID")] BodyID result);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate float JPH_CastRayCollector(void* context, JPH_RayCastResult* result);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate float JPH_CollidePointCollector(void* context, JPH_CollidePointResult* result);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate float JPH_CollideShapeCollector(void* context, JPH_CollideShapeResult* result);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate float JPH_CastShapeCollector(void* context, JPH_ShapeCastResult* result);

    public partial struct JPH_BroadPhaseLayerInterface
    {
    }

    public partial struct JPH_ObjectVsBroadPhaseLayerFilter
    {
    }

    public partial struct JPH_ObjectLayerPairFilter
    {
    }

    public partial struct JPH_BroadPhaseLayerFilter
    {
    }

    public partial struct JPH_ObjectLayerFilter
    {
    }

    public partial struct JPH_BodyFilter
    {
    }

    public partial struct JPH_PhysicsSystem
    {
    }

    public partial struct JPH_PhysicsMaterial
    {
    }

    public partial struct JPH_ShapeSettings
    {
    }

    public partial struct JPH_ConvexShapeSettings
    {
    }

    public partial struct JPH_SphereShapeSettings
    {
    }

    public partial struct JPH_BoxShapeSettings
    {
    }

    public partial struct JPH_TriangleShapeSettings
    {
    }

    public partial struct JPH_CapsuleShapeSettings
    {
    }

    public partial struct JPH_TaperedCapsuleShapeSettings
    {
    }

    public partial struct JPH_CylinderShapeSettings
    {
    }

    public partial struct JPH_ConvexHullShapeSettings
    {
    }

    public partial struct JPH_CompoundShapeSettings
    {
    }

    public partial struct JPH_StaticCompoundShapeSettings
    {
    }

    public partial struct JPH_MutableCompoundShapeSettings
    {
    }

    public partial struct JPH_MeshShapeSettings
    {
    }

    public partial struct JPH_HeightFieldShapeSettings
    {
    }

    public partial struct JPH_RotatedTranslatedShapeSettings
    {
    }

    public partial struct JPH_OffsetCenterOfMassShapeSettings
    {
    }

    public partial struct JPH_Shape
    {
    }

    public partial struct JPH_ConvexShape
    {
    }

    public partial struct JPH_SphereShape
    {
    }

    public partial struct JPH_BoxShape
    {
    }

    public partial struct JPH_CapsuleShape
    {
    }

    public partial struct JPH_CylinderShape
    {
    }

    public partial struct JPH_ConvexHullShape
    {
    }

    public partial struct JPH_CompoundShape
    {
    }

    public partial struct JPH_StaticCompoundShape
    {
    }

    public partial struct JPH_MutableCompoundShape
    {
    }

    public partial struct JPH_MeshShape
    {
    }

    public partial struct JPH_HeightFieldShape
    {
    }

    public partial struct JPH_DecoratedShape
    {
    }

    public partial struct JPH_RotatedTranslatedShape
    {
    }

    public partial struct JPH_OffsetCenterOfMassShape
    {
    }

    public partial struct JPH_BodyCreationSettings
    {
    }

    public partial struct JPH_SoftBodyCreationSettings
    {
    }

    public partial struct JPH_BodyInterface
    {
    }

    public partial struct JPH_BodyLockInterface
    {
    }

    public partial struct JPH_BroadPhaseQuery
    {
    }

    public partial struct JPH_NarrowPhaseQuery
    {
    }

    public partial struct JPH_MotionProperties
    {
    }

    public partial struct JPH_Body
    {
    }

    public partial struct JPH_ConstraintSettings
    {
    }

    public partial struct JPH_FixedConstraintSettings
    {
    }

    public partial struct JPH_TwoBodyConstraintSettings
    {
    }

    public partial struct JPH_DistanceConstraintSettings
    {
    }

    public partial struct JPH_HingeConstraintSettings
    {
    }

    public partial struct JPH_SliderConstraintSettings
    {
    }

    public partial struct JPH_PointConstraintSettings
    {
    }

    public partial struct JPH_ConeConstraintSettings
    {
    }

    public partial struct JPH_SwingTwistConstraintSettings
    {
    }

    public partial struct JPH_SixDOFConstraintSettings
    {
    }

    public partial struct JPH_Constraint
    {
    }

    public partial struct JPH_TwoBodyConstraint
    {
    }

    public partial struct JPH_FixedConstraint
    {
    }

    public partial struct JPH_DistanceConstraint
    {
    }

    public partial struct JPH_PointConstraint
    {
    }

    public partial struct JPH_HingeConstraint
    {
    }

    public partial struct JPH_SliderConstraint
    {
    }

    public partial struct JPH_ConeConstraint
    {
    }

    public partial struct JPH_SwingTwistConstraint
    {
    }

    public partial struct JPH_SixDOFConstraint
    {
    }

    public partial struct JPH_AllHit_CastRayCollector
    {
    }

    public partial struct JPH_AllHit_CastShapeCollector
    {
    }

    public partial struct JPH_ShapeCastSettings
    {
    }

    public partial struct JPH_ContactListener
    {
    }

    public partial struct JPH_ContactManifold
    {
    }

    public partial struct JPH_ContactSettings
    {
    }

    public partial struct JPH_BodyActivationListener
    {
    }

    public partial struct JPH_SharedMutex
    {
    }

    public unsafe partial struct JPH_BodyLockRead
    {
        [NativeTypeName("const JPH_BodyLockInterface *")]
        public JPH_BodyLockInterface* lockInterface;

        public JPH_SharedMutex* mutex;

        [NativeTypeName("const JPH_Body *")]
        public JPH_Body* body;
    }

    public unsafe partial struct JPH_BodyLockWrite
    {
        [NativeTypeName("const JPH_BodyLockInterface *")]
        public JPH_BodyLockInterface* lockInterface;

        public JPH_SharedMutex* mutex;

        public JPH_Body* body;
    }

    public partial struct JPH_ExtendedUpdateSettings
    {
        [NativeTypeName("JPH_Vec3")]
        public float3 stickToFloorStepDown;

        [NativeTypeName("JPH_Vec3")]
        public float3 walkStairsStepUp;

        public float walkStairsMinStepForward;

        public float walkStairsStepForwardTest;

        public float walkStairsCosAngleForwardContact;

        [NativeTypeName("JPH_Vec3")]
        public float3 walkStairsStepDownExtra;
    }

    public partial struct JPH_CharacterBaseSettings
    {
    }

    public partial struct JPH_CharacterBase
    {
    }

    public partial struct JPH_CharacterContactListener
    {
    }

    public partial struct JPH_CharacterVirtualSettings
    {
    }

    public partial struct JPH_CharacterVirtual
    {
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate NativeBool JPH_AssertFailureFunc([NativeTypeName("const char *")] sbyte* expression, [NativeTypeName("const char *")] sbyte* mssage, [NativeTypeName("const char *")] sbyte* file, uint line);

    public unsafe partial struct JPH_PhysicsSystemSettings
    {
        public uint maxBodies;

        public uint maxBodyPairs;

        public uint maxContactConstraints;

        public uint _padding;

        public JPH_BroadPhaseLayerInterface* broadPhaseLayerInterface;

        public JPH_ObjectLayerPairFilter* objectLayerPairFilter;

        public JPH_ObjectVsBroadPhaseLayerFilter* objectVsBroadPhaseLayerFilter;
    }

    public partial struct JPH_PhysicsSettings
    {
        public int maxInFlightBodyPairs;

        public int stepListenersBatchSize;

        public int stepListenerBatchesPerJob;

        public float baumgarte;

        public float speculativeContactDistance;

        public float penetrationSlop;

        public float linearCastThreshold;

        public float linearCastMaxPenetration;

        public float manifoldToleranceSq;

        public float maxPenetrationDistance;

        public float bodyPairCacheMaxDeltaPositionSq;

        public float bodyPairCacheCosMaxDeltaRotationDiv2;

        public float contactNormalCosMaxDeltaRotation;

        public float contactPointPreserveLambdaMaxDistSq;

        public uint numVelocitySteps;

        public uint numPositionSteps;

        public float minVelocityForRestitution;

        public float timeBeforeSleep;

        public float pointVelocitySleepThreshold;

        public NativeBool deterministicSimulation;

        public NativeBool constraintWarmStart;

        public NativeBool useBodyPairContactCache;

        public NativeBool useManifoldReduction;

        public NativeBool useLargeIslandSplitter;

        public NativeBool allowSleeping;

        public NativeBool checkActiveEdges;
    }

    public partial struct JPH_BroadPhaseLayerFilter_Procs
    {
        [NativeTypeName(" (*)(void *, JPH_BroadPhaseLayer) __attribute__((cdecl))")]
        public IntPtr ShouldCollide;
    }

    public partial struct JPH_ObjectLayerFilter_Procs
    {
        [NativeTypeName(" (*)(void *, JPH_ObjectLayer) __attribute__((cdecl))")]
        public IntPtr ShouldCollide;
    }

    public partial struct JPH_BodyFilter_Procs
    {
        [NativeTypeName(" (*)(void *, JPH_BodyID) __attribute__((cdecl))")]
        public IntPtr ShouldCollide;

        [NativeTypeName(" (*)(void *, const JPH_Body *) __attribute__((cdecl))")]
        public IntPtr ShouldCollideLocked;
    }

    public partial struct JPH_ContactListener_Procs
    {
        [NativeTypeName("JPH_ValidateResult (*)(void *, const JPH_Body *, const JPH_Body *, const JPH_RVec3 *, const JPH_CollideShapeResult *) __attribute__((cdecl))")]
        public IntPtr OnContactValidate;

        [NativeTypeName("void (*)(void *, const JPH_Body *, const JPH_Body *, const JPH_ContactManifold *, JPH_ContactSettings *) __attribute__((cdecl))")]
        public IntPtr OnContactAdded;

        [NativeTypeName("void (*)(void *, const JPH_Body *, const JPH_Body *, const JPH_ContactManifold *, JPH_ContactSettings *) __attribute__((cdecl))")]
        public IntPtr OnContactPersisted;

        [NativeTypeName("void (*)(void *, const JPH_SubShapeIDPair *) __attribute__((cdecl))")]
        public IntPtr OnContactRemoved;
    }

    public partial struct JPH_BodyActivationListener_Procs
    {
        [NativeTypeName("void (*)(void *, JPH_BodyID, uint64_t) __attribute__((cdecl))")]
        public IntPtr OnBodyActivated;

        [NativeTypeName("void (*)(void *, JPH_BodyID, uint64_t) __attribute__((cdecl))")]
        public IntPtr OnBodyDeactivated;
    }

    public partial struct JPH_CharacterContactListener_Procs
    {
        [NativeTypeName("void (*)(void *, const JPH_CharacterVirtual *, const JPH_Body *, const JPH_Vec3 *, const JPH_Vec3 *) __attribute__((cdecl))")]
        public IntPtr OnAdjustBodyVelocity;

        [NativeTypeName(" (*)(void *, const JPH_CharacterVirtual *, const JPH_BodyID, const JPH_SubShapeID) __attribute__((cdecl))")]
        public IntPtr OnContactValidate;

        [NativeTypeName("void (*)(void *, const JPH_CharacterVirtual *, const JPH_BodyID, const JPH_SubShapeID, const JPH_RVec3 *, const JPH_Vec3 *) __attribute__((cdecl))")]
        public IntPtr OnContactAdded;

        [NativeTypeName("void (*)(void *, const JPH_CharacterVirtual *, const JPH_BodyID, const JPH_SubShapeID, const JPH_RVec3 *, const JPH_Vec3 *, const JPH_Vec3 *, const JPH_PhysicsMaterial *, const JPH_Vec3 *, JPH_Vec3 *) __attribute__((cdecl))")]
        public IntPtr OnContactSolve;
    }

    public static unsafe partial class UnsafeBindings
    {
        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_Init(uint tempAllocatorSize);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Shutdown();

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SetAssertFailureHandler([NativeTypeName("JPH_AssertFailureFunc")] IntPtr handler);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_BroadPhaseLayerInterface* JPH_BroadPhaseLayerInterfaceMask_Create(uint numBroadPhaseLayers);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BroadPhaseLayerInterfaceMask_ConfigureLayer(JPH_BroadPhaseLayerInterface* bpInterface, [NativeTypeName("JPH_BroadPhaseLayer")] BroadPhaseLayer broadPhaseLayer, uint groupsToInclude, uint groupsToExclude);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_BroadPhaseLayerInterface* JPH_BroadPhaseLayerInterfaceTable_Create(uint numObjectLayers, uint numBroadPhaseLayers);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BroadPhaseLayerInterfaceTable_MapObjectToBroadPhaseLayer(JPH_BroadPhaseLayerInterface* bpInterface, [NativeTypeName("JPH_ObjectLayer")] ObjectLayer objectLayer, [NativeTypeName("JPH_BroadPhaseLayer")] BroadPhaseLayer broadPhaseLayer);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_ObjectLayerPairFilter* JPH_ObjectLayerPairFilterMask_Create();

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_ObjectLayer")]
        public static extern ObjectLayer JPH_ObjectLayerPairFilterMask_GetObjectLayer(uint group, uint mask);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint JPH_ObjectLayerPairFilterMask_GetGroup([NativeTypeName("JPH_ObjectLayer")] ObjectLayer layer);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint JPH_ObjectLayerPairFilterMask_GetMask([NativeTypeName("JPH_ObjectLayer")] ObjectLayer layer);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_ObjectLayerPairFilter* JPH_ObjectLayerPairFilterTable_Create(uint numObjectLayers);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ObjectLayerPairFilterTable_DisableCollision(JPH_ObjectLayerPairFilter* objectFilter, [NativeTypeName("JPH_ObjectLayer")] ObjectLayer layer1, [NativeTypeName("JPH_ObjectLayer")] ObjectLayer layer2);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ObjectLayerPairFilterTable_EnableCollision(JPH_ObjectLayerPairFilter* objectFilter, [NativeTypeName("JPH_ObjectLayer")] ObjectLayer layer1, [NativeTypeName("JPH_ObjectLayer")] ObjectLayer layer2);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_ObjectLayerPairFilterTable_ShouldCollide(JPH_ObjectLayerPairFilter* objectFilter, [NativeTypeName("JPH_ObjectLayer")] ObjectLayer layer1, [NativeTypeName("JPH_ObjectLayer")] ObjectLayer layer2);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_ObjectVsBroadPhaseLayerFilter* JPH_ObjectVsBroadPhaseLayerFilterMask_Create([NativeTypeName("const JPH_BroadPhaseLayerInterface *")] JPH_BroadPhaseLayerInterface* broadPhaseLayerInterface);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_ObjectVsBroadPhaseLayerFilter* JPH_ObjectVsBroadPhaseLayerFilterTable_Create(JPH_BroadPhaseLayerInterface* broadPhaseLayerInterface, uint numBroadPhaseLayers, JPH_ObjectLayerPairFilter* objectLayerPairFilter, uint numObjectLayers);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_PhysicsSystem* JPH_PhysicsSystem_Create([NativeTypeName("const JPH_PhysicsSystemSettings *")] JPH_PhysicsSystemSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_PhysicsSystem_Destroy(JPH_PhysicsSystem* system);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_PhysicsSystem_SetPhysicsSettings(JPH_PhysicsSystem* system, JPH_PhysicsSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_PhysicsSystem_GetPhysicsSettings(JPH_PhysicsSystem* system, JPH_PhysicsSettings* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_PhysicsSystem_OptimizeBroadPhase(JPH_PhysicsSystem* system);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_PhysicsUpdateError")]
        public static extern PhysicsUpdateError JPH_PhysicsSystem_Step(JPH_PhysicsSystem* system, float deltaTime, int collisionSteps);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_BodyInterface* JPH_PhysicsSystem_GetBodyInterface(JPH_PhysicsSystem* system);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_BodyInterface* JPH_PhysicsSystem_GetBodyInterfaceNoLock(JPH_PhysicsSystem* system);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const JPH_BodyLockInterface *")]
        public static extern JPH_BodyLockInterface* JPH_PhysicsSystem_GetBodyLockInterface([NativeTypeName("const JPH_PhysicsSystem *")] JPH_PhysicsSystem* system);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const JPH_BodyLockInterface *")]
        public static extern JPH_BodyLockInterface* JPH_PhysicsSystem_GetBodyLockInterfaceNoLock([NativeTypeName("const JPH_PhysicsSystem *")] JPH_PhysicsSystem* system);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const JPH_BroadPhaseQuery *")]
        public static extern JPH_BroadPhaseQuery* JPH_PhysicsSystem_GetBroadPhaseQuery([NativeTypeName("const JPH_PhysicsSystem *")] JPH_PhysicsSystem* system);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const JPH_NarrowPhaseQuery *")]
        public static extern JPH_NarrowPhaseQuery* JPH_PhysicsSystem_GetNarrowPhaseQuery([NativeTypeName("const JPH_PhysicsSystem *")] JPH_PhysicsSystem* system);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const JPH_NarrowPhaseQuery *")]
        public static extern JPH_NarrowPhaseQuery* JPH_PhysicsSystem_GetNarrowPhaseQueryNoLock([NativeTypeName("const JPH_PhysicsSystem *")] JPH_PhysicsSystem* system);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_PhysicsSystem_SetContactListener(JPH_PhysicsSystem* system, JPH_ContactListener* listener);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_PhysicsSystem_SetBodyActivationListener(JPH_PhysicsSystem* system, JPH_BodyActivationListener* listener);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_PhysicsSystem_WereBodiesInContact([NativeTypeName("const JPH_PhysicsSystem *")] JPH_PhysicsSystem* system, [NativeTypeName("JPH_BodyID")] BodyID body1, [NativeTypeName("JPH_BodyID")] BodyID body2);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint JPH_PhysicsSystem_GetNumBodies([NativeTypeName("const JPH_PhysicsSystem *")] JPH_PhysicsSystem* system);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint JPH_PhysicsSystem_GetNumActiveBodies([NativeTypeName("const JPH_PhysicsSystem *")] JPH_PhysicsSystem* system, [NativeTypeName("JPH_BodyType")] BodyType type);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint JPH_PhysicsSystem_GetMaxBodies([NativeTypeName("const JPH_PhysicsSystem *")] JPH_PhysicsSystem* system);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint JPH_PhysicsSystem_GetNumConstraints([NativeTypeName("const JPH_PhysicsSystem *")] JPH_PhysicsSystem* system);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_PhysicsSystem_SetGravity(JPH_PhysicsSystem* system, [NativeTypeName("const JPH_Vec3 *")] float3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_PhysicsSystem_GetGravity(JPH_PhysicsSystem* system, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_PhysicsSystem_AddConstraint(JPH_PhysicsSystem* system, JPH_Constraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_PhysicsSystem_RemoveConstraint(JPH_PhysicsSystem* system, JPH_Constraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_PhysicsSystem_AddConstraints(JPH_PhysicsSystem* system, JPH_Constraint** constraints, uint count);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_PhysicsSystem_RemoveConstraints(JPH_PhysicsSystem* system, JPH_Constraint** constraints, uint count);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_PhysicsSystem_GetBodies([NativeTypeName("const JPH_PhysicsSystem *")] JPH_PhysicsSystem* system, [NativeTypeName("JPH_BodyID *")] BodyID* ids, uint count);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_PhysicsSystem_GetConstraints([NativeTypeName("const JPH_PhysicsSystem *")] JPH_PhysicsSystem* system, [NativeTypeName("const JPH_Constraint **")] JPH_Constraint** constraints, uint count);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Quaternion_FromTo([NativeTypeName("const JPH_Vec3 *")] float3* from, [NativeTypeName("const JPH_Vec3 *")] float3* to, [NativeTypeName("JPH_Quat *")] quaternion* quat);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ShapeSettings_Destroy(JPH_ShapeSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_ConvexShapeSettings_GetDensity([NativeTypeName("const JPH_ConvexShapeSettings *")] JPH_ConvexShapeSettings* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ConvexShapeSettings_SetDensity(JPH_ConvexShapeSettings* shape, float value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_ConvexShape_GetDensity([NativeTypeName("const JPH_ConvexShape *")] JPH_ConvexShape* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ConvexShape_SetDensity(JPH_ConvexShape* shape, float inDensity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_BoxShapeSettings* JPH_BoxShapeSettings_Create([NativeTypeName("const JPH_Vec3 *")] float3* halfExtent, float convexRadius);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_BoxShape* JPH_BoxShapeSettings_CreateShape([NativeTypeName("const JPH_BoxShapeSettings *")] JPH_BoxShapeSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_BoxShape* JPH_BoxShape_Create([NativeTypeName("const JPH_Vec3 *")] float3* halfExtent, float convexRadius);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BoxShape_GetHalfExtent([NativeTypeName("const JPH_BoxShape *")] JPH_BoxShape* shape, [NativeTypeName("JPH_Vec3 *")] float3* halfExtent);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_BoxShape_GetVolume([NativeTypeName("const JPH_BoxShape *")] JPH_BoxShape* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_BoxShape_GetConvexRadius([NativeTypeName("const JPH_BoxShape *")] JPH_BoxShape* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_SphereShapeSettings* JPH_SphereShapeSettings_Create(float radius);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_SphereShape* JPH_SphereShapeSettings_CreateShape([NativeTypeName("const JPH_SphereShapeSettings *")] JPH_SphereShapeSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_SphereShapeSettings_GetRadius([NativeTypeName("const JPH_SphereShapeSettings *")] JPH_SphereShapeSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SphereShapeSettings_SetRadius(JPH_SphereShapeSettings* settings, float radius);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_SphereShape* JPH_SphereShape_Create(float radius);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_SphereShape_GetRadius([NativeTypeName("const JPH_SphereShape *")] JPH_SphereShape* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_TriangleShapeSettings* JPH_TriangleShapeSettings_Create([NativeTypeName("const JPH_Vec3 *")] float3* v1, [NativeTypeName("const JPH_Vec3 *")] float3* v2, [NativeTypeName("const JPH_Vec3 *")] float3* v3, float convexRadius);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_CapsuleShapeSettings* JPH_CapsuleShapeSettings_Create(float halfHeightOfCylinder, float radius);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_CapsuleShape* JPH_CapsuleShape_Create(float halfHeightOfCylinder, float radius);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_CapsuleShape_GetRadius([NativeTypeName("const JPH_CapsuleShape *")] JPH_CapsuleShape* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_CapsuleShape_GetHalfHeightOfCylinder([NativeTypeName("const JPH_CapsuleShape *")] JPH_CapsuleShape* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_CylinderShapeSettings* JPH_CylinderShapeSettings_Create(float halfHeight, float radius, float convexRadius);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_CylinderShape* JPH_CylinderShape_Create(float halfHeight, float radius);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_CylinderShape_GetRadius([NativeTypeName("const JPH_CylinderShape *")] JPH_CylinderShape* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_CylinderShape_GetHalfHeight([NativeTypeName("const JPH_CylinderShape *")] JPH_CylinderShape* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_ConvexHullShapeSettings* JPH_ConvexHullShapeSettings_Create([NativeTypeName("const JPH_Vec3[]")] float3* points, uint pointsCount, float maxConvexRadius);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_ConvexHullShape* JPH_ConvexHullShapeSettings_CreateShape([NativeTypeName("const JPH_ConvexHullShapeSettings *")] JPH_ConvexHullShapeSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint JPH_ConvexHullShape_GetNumPoints([NativeTypeName("const JPH_ConvexHullShape *")] JPH_ConvexHullShape* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ConvexHullShape_GetPoint([NativeTypeName("const JPH_ConvexHullShape *")] JPH_ConvexHullShape* shape, uint index, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint JPH_ConvexHullShape_GetNumFaces([NativeTypeName("const JPH_ConvexHullShape *")] JPH_ConvexHullShape* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint JPH_ConvexHullShape_GetNumVerticesInFace([NativeTypeName("const JPH_ConvexHullShape *")] JPH_ConvexHullShape* shape, uint faceIndex);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint JPH_ConvexHullShape_GetFaceVertices([NativeTypeName("const JPH_ConvexHullShape *")] JPH_ConvexHullShape* shape, uint faceIndex, uint maxVertices, [NativeTypeName("[]")] uint* vertices);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_MeshShapeSettings* JPH_MeshShapeSettings_Create([NativeTypeName("const JPH_Triangle[]")] Triangle* triangles, uint triangleCount);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_MeshShapeSettings* JPH_MeshShapeSettings_Create2([NativeTypeName("const JPH_Vec3[]")] float3* vertices, uint verticesCount, [NativeTypeName("const JPH_IndexedTriangle[]")] IndexedTriangle* triangles, uint triangleCount);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_MeshShapeSettings_Sanitize(JPH_MeshShapeSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_MeshShape* JPH_MeshShapeSettings_CreateShape([NativeTypeName("const JPH_MeshShapeSettings *")] JPH_MeshShapeSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_HeightFieldShapeSettings* JPH_HeightFieldShapeSettings_Create([NativeTypeName("const float[]")] float* samples, [NativeTypeName("const JPH_Vec3 *")] float3* offset, [NativeTypeName("const JPH_Vec3 *")] float3* scale, uint sampleCount);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_HeightFieldShape* JPH_HeightFieldShapeSettings_CreateShape([NativeTypeName("const JPH_HeightFieldShapeSettings *")] JPH_HeightFieldShapeSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HeightFieldShapeSettings_DetermineMinAndMaxSample([NativeTypeName("const JPH_HeightFieldShapeSettings *")] JPH_HeightFieldShapeSettings* settings, float* pOutMinValue, float* pOutMaxValue, float* pOutQuantizationScale);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint JPH_HeightFieldShapeSettings_CalculateBitsPerSampleForError([NativeTypeName("const JPH_HeightFieldShapeSettings *")] JPH_HeightFieldShapeSettings* settings, float maxError);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_TaperedCapsuleShapeSettings* JPH_TaperedCapsuleShapeSettings_Create(float halfHeightOfTaperedCylinder, float topRadius, float bottomRadius);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CompoundShapeSettings_AddShape(JPH_CompoundShapeSettings* settings, [NativeTypeName("const JPH_Vec3 *")] float3* position, [NativeTypeName("const JPH_Quat *")] quaternion* rotation, [NativeTypeName("const JPH_ShapeSettings *")] JPH_ShapeSettings* shape, uint userData);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CompoundShapeSettings_AddShape2(JPH_CompoundShapeSettings* settings, [NativeTypeName("const JPH_Vec3 *")] float3* position, [NativeTypeName("const JPH_Quat *")] quaternion* rotation, [NativeTypeName("const JPH_Shape *")] JPH_Shape* shape, uint userData);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint JPH_CompoundShape_GetNumSubShapes([NativeTypeName("const JPH_CompoundShape *")] JPH_CompoundShape* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CompoundShape_GetSubShape([NativeTypeName("const JPH_CompoundShape *")] JPH_CompoundShape* shape, uint index, [NativeTypeName("const JPH_Shape **")] JPH_Shape** subShape, [NativeTypeName("JPH_Vec3 *")] float3* positionCOM, [NativeTypeName("JPH_Quat *")] quaternion* rotation, [NativeTypeName(" *")] uint* userData);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint JPH_CompoundShape_GetSubShapeIndexFromID([NativeTypeName("const JPH_CompoundShape *")] JPH_CompoundShape* shape, [NativeTypeName("JPH_SubShapeID")] uint id, [NativeTypeName("JPH_SubShapeID *")] uint* remainder);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_StaticCompoundShapeSettings* JPH_StaticCompoundShapeSettings_Create();

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_StaticCompoundShape* JPH_StaticCompoundShape_Create([NativeTypeName("const JPH_StaticCompoundShapeSettings *")] JPH_StaticCompoundShapeSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_MutableCompoundShapeSettings* JPH_MutableCompoundShapeSettings_Create();

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_MutableCompoundShape* JPH_MutableCompoundShape_Create([NativeTypeName("const JPH_MutableCompoundShapeSettings *")] JPH_MutableCompoundShapeSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint JPH_MutableCompoundShape_AddShape(JPH_MutableCompoundShape* shape, [NativeTypeName("const JPH_Vec3 *")] float3* position, [NativeTypeName("const JPH_Quat *")] quaternion* rotation, [NativeTypeName("const JPH_Shape *")] JPH_Shape* child, uint userData);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_MutableCompoundShape_RemoveShape(JPH_MutableCompoundShape* shape, uint index);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_MutableCompoundShape_ModifyShape(JPH_MutableCompoundShape* shape, uint index, [NativeTypeName("const JPH_Vec3 *")] float3* position, [NativeTypeName("const JPH_Quat *")] quaternion* rotation);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_MutableCompoundShape_ModifyShape2(JPH_MutableCompoundShape* shape, uint index, [NativeTypeName("const JPH_Vec3 *")] float3* position, [NativeTypeName("const JPH_Quat *")] quaternion* rotation, [NativeTypeName("const JPH_Shape *")] JPH_Shape* newShape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_MutableCompoundShape_AdjustCenterOfMass(JPH_MutableCompoundShape* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const JPH_Shape *")]
        public static extern JPH_Shape* JPH_DecoratedShape_GetInnerShape([NativeTypeName("const JPH_DecoratedShape *")] JPH_DecoratedShape* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_RotatedTranslatedShapeSettings* JPH_RotatedTranslatedShapeSettings_Create([NativeTypeName("const JPH_Vec3 *")] float3* position, [NativeTypeName("const JPH_Quat *")] quaternion* rotation, [NativeTypeName("const JPH_ShapeSettings *")] JPH_ShapeSettings* shapeSettings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_RotatedTranslatedShapeSettings* JPH_RotatedTranslatedShapeSettings_Create2([NativeTypeName("const JPH_Vec3 *")] float3* position, [NativeTypeName("const JPH_Quat *")] quaternion* rotation, [NativeTypeName("const JPH_Shape *")] JPH_Shape* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_RotatedTranslatedShape* JPH_RotatedTranslatedShapeSettings_CreateShape([NativeTypeName("const JPH_RotatedTranslatedShapeSettings *")] JPH_RotatedTranslatedShapeSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_RotatedTranslatedShape* JPH_RotatedTranslatedShape_Create([NativeTypeName("const JPH_Vec3 *")] float3* position, [NativeTypeName("const JPH_Quat *")] quaternion* rotation, [NativeTypeName("const JPH_Shape *")] JPH_Shape* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_RotatedTranslatedShape_GetPosition([NativeTypeName("const JPH_RotatedTranslatedShape *")] JPH_RotatedTranslatedShape* shape, [NativeTypeName("JPH_Vec3 *")] float3* position);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_RotatedTranslatedShape_GetRotation([NativeTypeName("const JPH_RotatedTranslatedShape *")] JPH_RotatedTranslatedShape* shape, [NativeTypeName("JPH_Quat *")] quaternion* rotation);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_OffsetCenterOfMassShapeSettings* JPH_OffsetCenterOfMassShapeSettings_Create([NativeTypeName("const JPH_Vec3 *")] float3* offset, [NativeTypeName("const JPH_ShapeSettings *")] JPH_ShapeSettings* shapeSettings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_OffsetCenterOfMassShapeSettings* JPH_OffsetCenterOfMassShapeSettings_Create2([NativeTypeName("const JPH_Vec3 *")] float3* offset, [NativeTypeName("const JPH_Shape *")] JPH_Shape* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_OffsetCenterOfMassShape* JPH_OffsetCenterOfMassShapeSettings_CreateShape([NativeTypeName("const JPH_OffsetCenterOfMassShapeSettings *")] JPH_OffsetCenterOfMassShapeSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_OffsetCenterOfMassShape* JPH_OffsetCenterOfMassShape_Create([NativeTypeName("JPH_Vec3 *")] float3* offset, JPH_Shape* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_OffsetCenterOfMassShape_GetOffset([NativeTypeName("const JPH_OffsetCenterOfMassShape *")] JPH_OffsetCenterOfMassShape* shape, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Shape_Destroy(JPH_Shape* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_ShapeType")]
        public static extern ShapeType JPH_Shape_GetType([NativeTypeName("const JPH_Shape *")] JPH_Shape* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_ShapeSubType")]
        public static extern ShapeSubType JPH_Shape_GetSubType([NativeTypeName("const JPH_Shape *")] JPH_Shape* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong JPH_Shape_GetUserData([NativeTypeName("const JPH_Shape *")] JPH_Shape* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Shape_SetUserData(JPH_Shape* shape, [NativeTypeName("uint64_t")] ulong userData);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_Shape_MustBeStatic([NativeTypeName("const JPH_Shape *")] JPH_Shape* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Shape_GetCenterOfMass([NativeTypeName("const JPH_Shape *")] JPH_Shape* shape, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Shape_GetLocalBounds([NativeTypeName("const JPH_Shape *")] JPH_Shape* shape, [NativeTypeName("JPH_AABox *")] AABox* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Shape_GetWorldSpaceBounds([NativeTypeName("const JPH_Shape *")] JPH_Shape* shape, [NativeTypeName("const JPH_RMatrix4x4 *")] rmatrix4x4* centerOfMassTransform, [NativeTypeName("const JPH_Vec3 *")] float3* scale, [NativeTypeName("JPH_AABox *")] AABox* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_Shape_GetInnerRadius([NativeTypeName("const JPH_Shape *")] JPH_Shape* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Shape_GetMassProperties([NativeTypeName("const JPH_Shape *")] JPH_Shape* shape, [NativeTypeName("JPH_MassProperties *")] MassProperties* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Shape_GetSurfaceNormal([NativeTypeName("const JPH_Shape *")] JPH_Shape* shape, [NativeTypeName("JPH_SubShapeID")] uint subShapeID, [NativeTypeName("const JPH_Vec3 *")] float3* localPosition, [NativeTypeName("JPH_Vec3 *")] float3* normal);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_Shape_GetVolume([NativeTypeName("const JPH_Shape *")] JPH_Shape* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_BodyCreationSettings* JPH_BodyCreationSettings_Create();

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_BodyCreationSettings* JPH_BodyCreationSettings_Create2(JPH_ShapeSettings* settings, [NativeTypeName("const JPH_RVec3 *")] rvec3* position, [NativeTypeName("const JPH_Quat *")] quaternion* rotation, [NativeTypeName("JPH_MotionType")] MotionType motionType, [NativeTypeName("JPH_ObjectLayer")] ObjectLayer objectLayer);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_BodyCreationSettings* JPH_BodyCreationSettings_Create3([NativeTypeName("const JPH_Shape *")] JPH_Shape* shape, [NativeTypeName("const JPH_RVec3 *")] rvec3* position, [NativeTypeName("const JPH_Quat *")] quaternion* rotation, [NativeTypeName("JPH_MotionType")] MotionType motionType, [NativeTypeName("JPH_ObjectLayer")] ObjectLayer objectLayer);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyCreationSettings_Destroy(JPH_BodyCreationSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyCreationSettings_GetLinearVelocity(JPH_BodyCreationSettings* settings, [NativeTypeName("JPH_Vec3 *")] float3* velocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyCreationSettings_SetLinearVelocity(JPH_BodyCreationSettings* settings, [NativeTypeName("const JPH_Vec3 *")] float3* velocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyCreationSettings_GetAngularVelocity(JPH_BodyCreationSettings* settings, [NativeTypeName("JPH_Vec3 *")] float3* velocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyCreationSettings_SetAngularVelocity(JPH_BodyCreationSettings* settings, [NativeTypeName("const JPH_Vec3 *")] float3* velocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_MotionType")]
        public static extern MotionType JPH_BodyCreationSettings_GetMotionType(JPH_BodyCreationSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyCreationSettings_SetMotionType(JPH_BodyCreationSettings* settings, [NativeTypeName("JPH_MotionType")] MotionType value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_AllowedDOFs")]
        public static extern AllowedDOFs JPH_BodyCreationSettings_GetAllowedDOFs(JPH_BodyCreationSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyCreationSettings_SetAllowedDOFs(JPH_BodyCreationSettings* settings, [NativeTypeName("JPH_AllowedDOFs")] AllowedDOFs value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_SoftBodyCreationSettings* JPH_SoftBodyCreationSettings_Create();

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SoftBodyCreationSettings_Destroy(JPH_SoftBodyCreationSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ConstraintSettings_Destroy(JPH_ConstraintSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_ConstraintSettings_GetEnabled(JPH_ConstraintSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_FixedConstraintSettings_SetEnabled(JPH_ConstraintSettings* settings, NativeBool value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint JPH_ConstraintSettings_GetConstraintPriority(JPH_ConstraintSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_FixedConstraintSettings_SetConstraintPriority(JPH_ConstraintSettings* settings, uint value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint JPH_ConstraintSettings_GetNumVelocityStepsOverride(JPH_ConstraintSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ConstraintSettings_SetNumVelocityStepsOverride(JPH_ConstraintSettings* settings, uint value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint JPH_ConstraintSettings_GetNumPositionStepsOverride(JPH_ConstraintSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ConstraintSettings_SetNumPositionStepsOverride(JPH_ConstraintSettings* settings, uint value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_ConstraintSettings_GetDrawConstraintSize(JPH_ConstraintSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ConstraintSettings_SetDrawConstraintSize(JPH_ConstraintSettings* settings, float value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong JPH_ConstraintSettings_GetUserData(JPH_ConstraintSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ConstraintSettings_SetUserData(JPH_ConstraintSettings* settings, [NativeTypeName("uint64_t")] ulong value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_ConstraintSettings* JPH_Constraint_GetConstraintSettings(JPH_Constraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_ConstraintType")]
        public static extern ConstraintType JPH_Constraint_GetType([NativeTypeName("const JPH_Constraint *")] JPH_Constraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_ConstraintSubType")]
        public static extern ConstraintSubType JPH_Constraint_GetSubType([NativeTypeName("const JPH_Constraint *")] JPH_Constraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint JPH_Constraint_GetConstraintPriority([NativeTypeName("const JPH_Constraint *")] JPH_Constraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Constraint_SetConstraintPriority(JPH_Constraint* constraint, uint priority);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_Constraint_GetEnabled(JPH_Constraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Constraint_SetEnabled(JPH_Constraint* constraint, NativeBool enabled);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong JPH_Constraint_GetUserData([NativeTypeName("const JPH_Constraint *")] JPH_Constraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Constraint_SetUserData(JPH_Constraint* constraint, [NativeTypeName("uint64_t")] ulong userData);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Constraint_NotifyShapeChanged(JPH_Constraint* constraint, [NativeTypeName("JPH_BodyID")] BodyID bodyID, [NativeTypeName("JPH_Vec3 *")] float3* deltaCOM);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Constraint_Destroy(JPH_Constraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_FixedConstraintSettings* JPH_FixedConstraintSettings_Create();

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_ConstraintSpace")]
        public static extern ConstraintSpace JPH_FixedConstraintSettings_GetSpace(JPH_FixedConstraintSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_FixedConstraintSettings_SetSpace(JPH_FixedConstraintSettings* settings, [NativeTypeName("JPH_ConstraintSpace")] ConstraintSpace space);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_FixedConstraintSettings_GetAutoDetectPoint(JPH_FixedConstraintSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_FixedConstraintSettings_SetAutoDetectPoint(JPH_FixedConstraintSettings* settings, NativeBool value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_FixedConstraintSettings_GetPoint1(JPH_FixedConstraintSettings* settings, [NativeTypeName("JPH_RVec3 *")] rvec3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_FixedConstraintSettings_SetPoint1(JPH_FixedConstraintSettings* settings, [NativeTypeName("const JPH_RVec3 *")] rvec3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_FixedConstraintSettings_GetAxisX1(JPH_FixedConstraintSettings* settings, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_FixedConstraintSettings_SetAxisX1(JPH_FixedConstraintSettings* settings, [NativeTypeName("const JPH_Vec3 *")] float3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_FixedConstraintSettings_GetAxisY1(JPH_FixedConstraintSettings* settings, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_FixedConstraintSettings_SetAxisY1(JPH_FixedConstraintSettings* settings, [NativeTypeName("const JPH_Vec3 *")] float3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_FixedConstraintSettings_GetPoint2(JPH_FixedConstraintSettings* settings, [NativeTypeName("JPH_RVec3 *")] rvec3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_FixedConstraintSettings_SetPoint2(JPH_FixedConstraintSettings* settings, [NativeTypeName("const JPH_RVec3 *")] rvec3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_FixedConstraintSettings_GetAxisX2(JPH_FixedConstraintSettings* settings, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_FixedConstraintSettings_SetAxisX2(JPH_FixedConstraintSettings* settings, [NativeTypeName("const JPH_Vec3 *")] float3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_FixedConstraintSettings_GetAxisY2(JPH_FixedConstraintSettings* settings, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_FixedConstraintSettings_SetAxisY2(JPH_FixedConstraintSettings* settings, [NativeTypeName("const JPH_Vec3 *")] float3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_FixedConstraint* JPH_FixedConstraintSettings_CreateConstraint(JPH_FixedConstraintSettings* settings, JPH_Body* body1, JPH_Body* body2);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_FixedConstraint_GetTotalLambdaPosition([NativeTypeName("const JPH_FixedConstraint *")] JPH_FixedConstraint* constraint, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_FixedConstraint_GetTotalLambdaRotation([NativeTypeName("const JPH_FixedConstraint *")] JPH_FixedConstraint* constraint, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_DistanceConstraintSettings* JPH_DistanceConstraintSettings_Create();

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_ConstraintSpace")]
        public static extern ConstraintSpace JPH_DistanceConstraintSettings_GetSpace(JPH_DistanceConstraintSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_DistanceConstraintSettings_SetSpace(JPH_DistanceConstraintSettings* settings, [NativeTypeName("JPH_ConstraintSpace")] ConstraintSpace space);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_DistanceConstraintSettings_GetPoint1(JPH_DistanceConstraintSettings* settings, [NativeTypeName("JPH_RVec3 *")] rvec3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_DistanceConstraintSettings_SetPoint1(JPH_DistanceConstraintSettings* settings, [NativeTypeName("const JPH_RVec3 *")] rvec3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_DistanceConstraintSettings_GetPoint2(JPH_DistanceConstraintSettings* settings, [NativeTypeName("JPH_RVec3 *")] rvec3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_DistanceConstraintSettings_SetPoint2(JPH_DistanceConstraintSettings* settings, [NativeTypeName("const JPH_RVec3 *")] rvec3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_DistanceConstraintSettings_SetMinDistance(JPH_DistanceConstraintSettings* settings, float value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_DistanceConstraintSettings_GetMinDistance(JPH_DistanceConstraintSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_DistanceConstraintSettings_SetMaxDistance(JPH_DistanceConstraintSettings* settings, float value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_DistanceConstraintSettings_GetMaxDistance(JPH_DistanceConstraintSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_DistanceConstraintSettings_SetLimitsSpringSettings(JPH_DistanceConstraintSettings* settings, [NativeTypeName("const JPH_SpringSettings *")] JPH_SpringSettings* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_DistanceConstraintSettings_GetLimitsSpringSettings(JPH_DistanceConstraintSettings* settings, JPH_SpringSettings* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_DistanceConstraint* JPH_DistanceConstraintSettings_CreateConstraint(JPH_DistanceConstraintSettings* settings, JPH_Body* body1, JPH_Body* body2);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_DistanceConstraint_SetDistance(JPH_DistanceConstraint* constraint, float minDistance, float maxDistance);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_DistanceConstraint_GetMinDistance(JPH_DistanceConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_DistanceConstraint_GetMaxDistance(JPH_DistanceConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_DistanceConstraint_GetLimitsSpringSettings(JPH_DistanceConstraint* constraint, JPH_SpringSettings* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_DistanceConstraint_SetLimitsSpringSettings(JPH_DistanceConstraint* constraint, JPH_SpringSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_DistanceConstraint_GetTotalLambdaPosition([NativeTypeName("const JPH_DistanceConstraint *")] JPH_DistanceConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_PointConstraintSettings* JPH_PointConstraintSettings_Create();

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_ConstraintSpace")]
        public static extern ConstraintSpace JPH_PointConstraintSettings_GetSpace(JPH_PointConstraintSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_PointConstraintSettings_SetSpace(JPH_PointConstraintSettings* settings, [NativeTypeName("JPH_ConstraintSpace")] ConstraintSpace space);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_PointConstraintSettings_GetPoint1(JPH_PointConstraintSettings* settings, [NativeTypeName("JPH_RVec3 *")] rvec3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_PointConstraintSettings_SetPoint1(JPH_PointConstraintSettings* settings, [NativeTypeName("const JPH_RVec3 *")] rvec3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_PointConstraintSettings_GetPoint2(JPH_PointConstraintSettings* settings, [NativeTypeName("JPH_RVec3 *")] rvec3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_PointConstraintSettings_SetPoint2(JPH_PointConstraintSettings* settings, [NativeTypeName("const JPH_RVec3 *")] rvec3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_PointConstraint* JPH_PointConstraintSettings_CreateConstraint(JPH_PointConstraintSettings* settings, JPH_Body* body1, JPH_Body* body2);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_PointConstraint_SetPoint1(JPH_PointConstraint* constraint, [NativeTypeName("JPH_ConstraintSpace")] ConstraintSpace space, [NativeTypeName("JPH_RVec3 *")] rvec3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_PointConstraint_SetPoint2(JPH_PointConstraint* constraint, [NativeTypeName("JPH_ConstraintSpace")] ConstraintSpace space, [NativeTypeName("JPH_RVec3 *")] rvec3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_PointConstraint_GetTotalLambdaPosition([NativeTypeName("const JPH_PointConstraint *")] JPH_PointConstraint* constraint, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_HingeConstraintSettings* JPH_HingeConstraintSettings_Create();

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraintSettings_SetSpace(JPH_HingeConstraintSettings* settings, [NativeTypeName("JPH_ConstraintSpace")] ConstraintSpace space);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraintSettings_GetPoint1(JPH_HingeConstraintSettings* settings, [NativeTypeName("JPH_RVec3 *")] rvec3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraintSettings_SetPoint1(JPH_HingeConstraintSettings* settings, [NativeTypeName("const JPH_RVec3 *")] rvec3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraintSettings_GetPoint2(JPH_HingeConstraintSettings* settings, [NativeTypeName("JPH_RVec3 *")] rvec3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraintSettings_SetPoint2(JPH_HingeConstraintSettings* settings, [NativeTypeName("const JPH_RVec3 *")] rvec3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraintSettings_SetHingeAxis1(JPH_HingeConstraintSettings* settings, [NativeTypeName("const JPH_Vec3 *")] float3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraintSettings_GetHingeAxis1(JPH_HingeConstraintSettings* settings, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraintSettings_SetNormalAxis1(JPH_HingeConstraintSettings* settings, [NativeTypeName("const JPH_Vec3 *")] float3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraintSettings_GetNormalAxis1(JPH_HingeConstraintSettings* settings, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraintSettings_SetHingeAxis2(JPH_HingeConstraintSettings* settings, [NativeTypeName("const JPH_Vec3 *")] float3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraintSettings_GetHingeAxis2(JPH_HingeConstraintSettings* settings, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraintSettings_SetNormalAxis2(JPH_HingeConstraintSettings* settings, [NativeTypeName("const JPH_Vec3 *")] float3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraintSettings_GetNormalAxis2(JPH_HingeConstraintSettings* settings, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraintSettings_SetLimits(JPH_HingeConstraintSettings* settings, float inLimitsMin, float inLimitsMax);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_HingeConstraintSettings_GetLimitMin(JPH_HingeConstraintSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_HingeConstraintSettings_GetLimitMax(JPH_HingeConstraintSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraintSettings_SetLimitsSpringSettings(JPH_HingeConstraintSettings* settings, [NativeTypeName("const JPH_SpringSettings *")] JPH_SpringSettings* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraintSettings_GetLimitsSpringSettings(JPH_HingeConstraintSettings* settings, JPH_SpringSettings* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraintSettings_SetMaxFrictionTorque(JPH_HingeConstraintSettings* settings, float frictionTorque);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_HingeConstraintSettings_GetMaxFrictionTorque(JPH_HingeConstraintSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraintSettings_SetMotorSettings(JPH_HingeConstraintSettings* settings, [NativeTypeName("const JPH_MotorSettings *")] JPH_MotorSettings* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraintSettings_GetMotorSettings(JPH_HingeConstraintSettings* settings, JPH_MotorSettings* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_HingeConstraint* JPH_HingeConstraintSettings_CreateConstraint(JPH_HingeConstraintSettings* settings, JPH_Body* body1, JPH_Body* body2);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_HingeConstraintSettings* JPH_HingeConstraint_GetSettings(JPH_HingeConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_HingeConstraint_GetCurrentAngle(JPH_HingeConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraint_SetMaxFrictionTorque(JPH_HingeConstraint* constraint, float frictionTorque);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_HingeConstraint_GetMaxFrictionTorque(JPH_HingeConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraint_SetMotorSettings(JPH_HingeConstraint* constraint, [NativeTypeName("const JPH_MotorSettings *")] JPH_MotorSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraint_GetMotorSettings(JPH_HingeConstraint* constraint, JPH_MotorSettings* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraint_SetMotorState(JPH_HingeConstraint* constraint, [NativeTypeName("JPH_MotorState")] MotorState state);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_MotorState")]
        public static extern MotorState JPH_HingeConstraint_GetMotorState(JPH_HingeConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraint_SetTargetAngularVelocity(JPH_HingeConstraint* constraint, float angularVelocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_HingeConstraint_GetTargetAngularVelocity(JPH_HingeConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraint_SetTargetAngle(JPH_HingeConstraint* constraint, float angle);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_HingeConstraint_GetTargetAngle(JPH_HingeConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraint_SetLimits(JPH_HingeConstraint* constraint, float inLimitsMin, float inLimitsMax);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_HingeConstraint_GetLimitsMin(JPH_HingeConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_HingeConstraint_GetLimitsMax(JPH_HingeConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_HingeConstraint_HasLimits(JPH_HingeConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraint_GetLimitsSpringSettings(JPH_HingeConstraint* constraint, JPH_SpringSettings* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraint_SetLimitsSpringSettings(JPH_HingeConstraint* constraint, [NativeTypeName("const JPH_SpringSettings *")] JPH_SpringSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraint_GetTotalLambdaPosition([NativeTypeName("const JPH_HingeConstraint *")] JPH_HingeConstraint* constraint, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_HingeConstraint_GetTotalLambdaRotation([NativeTypeName("const JPH_HingeConstraint *")] JPH_HingeConstraint* constraint, float* x, float* y);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_HingeConstraint_GetTotalLambdaRotationLimits([NativeTypeName("const JPH_HingeConstraint *")] JPH_HingeConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_HingeConstraint_GetTotalLambdaMotor([NativeTypeName("const JPH_HingeConstraint *")] JPH_HingeConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_SliderConstraintSettings* JPH_SliderConstraintSettings_Create();

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SliderConstraintSettings_SetSliderAxis(JPH_SliderConstraintSettings* settings, [NativeTypeName("const JPH_Vec3 *")] float3* axis);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SliderConstraintSettings_GetSliderAxis(JPH_SliderConstraintSettings* settings, [NativeTypeName("JPH_Vec3 *")] float3* axis);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_SliderConstraint* JPH_SliderConstraintSettings_CreateConstraint(JPH_SliderConstraintSettings* settings, JPH_Body* body1, JPH_Body* body2);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_SliderConstraintSettings* JPH_SliderConstraint_GetSettings(JPH_SliderConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_SliderConstraint_GetCurrentPosition(JPH_SliderConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SliderConstraint_SetMaxFrictionForce(JPH_SliderConstraint* constraint, float frictionForce);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_SliderConstraint_GetMaxFrictionForce(JPH_SliderConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SliderConstraint_SetMotorSettings(JPH_SliderConstraint* constraint, [NativeTypeName("const JPH_MotorSettings *")] JPH_MotorSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SliderConstraint_GetMotorSettings(JPH_SliderConstraint* constraint, JPH_MotorSettings* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SliderConstraint_SetMotorState(JPH_SliderConstraint* constraint, [NativeTypeName("JPH_MotorState")] MotorState state);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_MotorState")]
        public static extern MotorState JPH_SliderConstraint_GetMotorState(JPH_SliderConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SliderConstraint_SetTargetVelocity(JPH_SliderConstraint* constraint, float velocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_SliderConstraint_GetTargetVelocity(JPH_SliderConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SliderConstraint_SetTargetPosition(JPH_SliderConstraint* constraint, float position);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_SliderConstraint_GetTargetPosition(JPH_SliderConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SliderConstraint_SetLimits(JPH_SliderConstraint* constraint, float inLimitsMin, float inLimitsMax);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_SliderConstraint_GetLimitsMin(JPH_SliderConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_SliderConstraint_GetLimitsMax(JPH_SliderConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_SliderConstraint_HasLimits(JPH_SliderConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SliderConstraint_GetLimitsSpringSettings(JPH_SliderConstraint* constraint, JPH_SpringSettings* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SliderConstraint_SetLimitsSpringSettings(JPH_SliderConstraint* constraint, [NativeTypeName("const JPH_SpringSettings *")] JPH_SpringSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SliderConstraint_GetTotalLambdaPosition([NativeTypeName("const JPH_SliderConstraint *")] JPH_SliderConstraint* constraint, float* x, float* y);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_SliderConstraint_GetTotalLambdaPositionLimits([NativeTypeName("const JPH_SliderConstraint *")] JPH_SliderConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SliderConstraint_GetTotalLambdaRotation([NativeTypeName("const JPH_SliderConstraint *")] JPH_SliderConstraint* constraint, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_SliderConstraint_GetTotalLambdaMotor([NativeTypeName("const JPH_SliderConstraint *")] JPH_SliderConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_ConeConstraintSettings* JPH_ConeConstraintSettings_Create();

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ConeConstraintSettings_GetPoint1(JPH_ConeConstraintSettings* settings, [NativeTypeName("JPH_RVec3 *")] rvec3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ConeConstraintSettings_SetPoint1(JPH_ConeConstraintSettings* settings, [NativeTypeName("const JPH_RVec3 *")] rvec3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ConeConstraintSettings_GetPoint2(JPH_ConeConstraintSettings* settings, [NativeTypeName("JPH_RVec3 *")] rvec3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ConeConstraintSettings_SetPoint2(JPH_ConeConstraintSettings* settings, [NativeTypeName("const JPH_RVec3 *")] rvec3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ConeConstraintSettings_SetTwistAxis1(JPH_ConeConstraintSettings* settings, [NativeTypeName("const JPH_Vec3 *")] float3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ConeConstraintSettings_GetTwistAxis1(JPH_ConeConstraintSettings* settings, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ConeConstraintSettings_SetTwistAxis2(JPH_ConeConstraintSettings* settings, [NativeTypeName("const JPH_Vec3 *")] float3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ConeConstraintSettings_GetTwistAxis2(JPH_ConeConstraintSettings* settings, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ConeConstraintSettings_SetHalfConeAngle(JPH_ConeConstraintSettings* settings, float halfConeAngle);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_ConeConstraintSettings_GetHalfConeAngle(JPH_ConeConstraintSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_ConeConstraint* JPH_ConeConstraintSettings_CreateConstraint(JPH_ConeConstraintSettings* settings, JPH_Body* body1, JPH_Body* body2);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ConeConstraint_SetHalfConeAngle(JPH_ConeConstraint* constraint, float halfConeAngle);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_ConeConstraint_GetCosHalfConeAngle([NativeTypeName("const JPH_ConeConstraint *")] JPH_ConeConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ConeConstraint_GetTotalLambdaPosition([NativeTypeName("const JPH_ConeConstraint *")] JPH_ConeConstraint* constraint, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_ConeConstraint_GetTotalLambdaRotation([NativeTypeName("const JPH_ConeConstraint *")] JPH_ConeConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_SwingTwistConstraintSettings* JPH_SwingTwistConstraintSettings_Create();

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraintSettings_SetSpace(JPH_SwingTwistConstraintSettings* settings, [NativeTypeName("JPH_ConstraintSpace")] ConstraintSpace space);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_ConstraintSpace")]
        public static extern ConstraintSpace JPH_SwingTwistConstraintSettings_GetSpace(JPH_SwingTwistConstraintSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraintSettings_GetPosition1(JPH_SwingTwistConstraintSettings* settings, [NativeTypeName("JPH_RVec3 *")] rvec3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraintSettings_SetPosition1(JPH_SwingTwistConstraintSettings* settings, [NativeTypeName("const JPH_RVec3 *")] rvec3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraintSettings_GetPosition2(JPH_SwingTwistConstraintSettings* settings, [NativeTypeName("JPH_RVec3 *")] rvec3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraintSettings_SetPosition2(JPH_SwingTwistConstraintSettings* settings, [NativeTypeName("const JPH_RVec3 *")] rvec3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraintSettings_SetTwistAxis1(JPH_SwingTwistConstraintSettings* settings, [NativeTypeName("const JPH_Vec3 *")] float3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraintSettings_GetTwistAxis1(JPH_SwingTwistConstraintSettings* settings, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraintSettings_SetTwistAxis2(JPH_SwingTwistConstraintSettings* settings, [NativeTypeName("const JPH_Vec3 *")] float3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraintSettings_GetTwistAxis2(JPH_SwingTwistConstraintSettings* settings, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraintSettings_GetPlaneAxis1(JPH_SwingTwistConstraintSettings* settings, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraintSettings_SetPlaneAxis1(JPH_SwingTwistConstraintSettings* settings, [NativeTypeName("const JPH_Vec3 *")] float3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraintSettings_GetPlaneAxis2(JPH_SwingTwistConstraintSettings* settings, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraintSettings_SetPlaneAxis2(JPH_SwingTwistConstraintSettings* settings, [NativeTypeName("const JPH_Vec3 *")] float3* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraintSettings_SetSwingType(JPH_SwingTwistConstraintSettings* settings, JPH_SwingType value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_SwingType JPH_SwingTwistConstraintSettings_GetSwingType(JPH_SwingTwistConstraintSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraintSettings_SetNormalHalfConeAngle(JPH_SwingTwistConstraintSettings* settings, float value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_SwingTwistConstraintSettings_GetNormalHalfConeAngle(JPH_SwingTwistConstraintSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraintSettings_SetPlaneHalfConeAngle(JPH_SwingTwistConstraintSettings* settings, float value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_SwingTwistConstraintSettings_GetPlaneHalfConeAngle(JPH_SwingTwistConstraintSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraintSettings_SetTwistMinAngle(JPH_SwingTwistConstraintSettings* settings, float value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_SwingTwistConstraintSettings_GetTwistMinAngle(JPH_SwingTwistConstraintSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraintSettings_SetTwistMaxAngle(JPH_SwingTwistConstraintSettings* settings, float value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_SwingTwistConstraintSettings_GetTwistMaxAngle(JPH_SwingTwistConstraintSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraintSettings_SetMaxFrictionTorque(JPH_SwingTwistConstraintSettings* settings, float value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_SwingTwistConstraintSettings_GetMaxFrictionTorque(JPH_SwingTwistConstraintSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraintSettings_SetSwingMotorSettings(JPH_SwingTwistConstraintSettings* settings, [NativeTypeName("const JPH_MotorSettings *")] JPH_MotorSettings* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraintSettings_GetSwingMotorSettings(JPH_SwingTwistConstraintSettings* settings, JPH_MotorSettings* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraintSettings_SetTwistMotorSettings(JPH_SwingTwistConstraintSettings* settings, [NativeTypeName("const JPH_MotorSettings *")] JPH_MotorSettings* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraintSettings_GetTwistMotorSettings(JPH_SwingTwistConstraintSettings* settings, JPH_MotorSettings* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_SwingTwistConstraint* JPH_SwingTwistConstraintSettings_CreateConstraint(JPH_SwingTwistConstraintSettings* settings, JPH_Body* body1, JPH_Body* body2);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraint_GetLocalSpacePosition1([NativeTypeName("const JPH_SwingTwistConstraint *")] JPH_SwingTwistConstraint* constraint, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraint_GetLocalSpacePosition2([NativeTypeName("const JPH_SwingTwistConstraint *")] JPH_SwingTwistConstraint* constraint, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraint_GetConstraintToBody1([NativeTypeName("const JPH_SwingTwistConstraint *")] JPH_SwingTwistConstraint* constraint, [NativeTypeName("JPH_Quat *")] quaternion* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraint_GetConstraintToBody2([NativeTypeName("const JPH_SwingTwistConstraint *")] JPH_SwingTwistConstraint* constraint, [NativeTypeName("JPH_Quat *")] quaternion* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraint_SetNormalHalfConeAngle(JPH_SwingTwistConstraint* constraint, float value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_SwingTwistConstraint_GetNormalHalfConeAngle(JPH_SwingTwistConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraint_SetPlaneHalfConeAngle(JPH_SwingTwistConstraint* constraint, float value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_SwingTwistConstraint_GetPlaneHalfConeAngle(JPH_SwingTwistConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraint_SetTwistMinAngle(JPH_SwingTwistConstraint* constraint, float value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_SwingTwistConstraint_GetTwistMinAngle(JPH_SwingTwistConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraint_SetTwistMaxAngle(JPH_SwingTwistConstraint* constraint, float value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_SwingTwistConstraint_GetTwistMaxAngle(JPH_SwingTwistConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraint_SetSwingMotorSettings(JPH_SwingTwistConstraint* constraint, [NativeTypeName("const JPH_MotorSettings *")] JPH_MotorSettings* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraint_GetSwingMotorSettings(JPH_SwingTwistConstraint* constraint, JPH_MotorSettings* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraint_SetTwistMotorSettings(JPH_SwingTwistConstraint* constraint, [NativeTypeName("const JPH_MotorSettings *")] JPH_MotorSettings* value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraint_GetTwistMotorSettings(JPH_SwingTwistConstraint* constraint, JPH_MotorSettings* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraint_SetMaxFrictionTorque(JPH_SwingTwistConstraint* constraint, float value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_SwingTwistConstraint_GetMaxFrictionTorque(JPH_SwingTwistConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraint_SetSwingMotorState(JPH_SwingTwistConstraint* constraint, [NativeTypeName("JPH_MotorState")] MotorState state);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_MotorState")]
        public static extern MotorState JPH_SwingTwistConstraint_GetSwingMotorState(JPH_SwingTwistConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraint_SetTwistMotorState(JPH_SwingTwistConstraint* constraint, [NativeTypeName("JPH_MotorState")] MotorState state);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_MotorState")]
        public static extern MotorState JPH_SwingTwistConstraint_GetTwistMotorState(JPH_SwingTwistConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraint_SetTargetAngularVelocityCS(JPH_SwingTwistConstraint* constraint, [NativeTypeName("const JPH_Vec3 *")] float3* angularVelocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraint_GetTargetAngularVelocityCS(JPH_SwingTwistConstraint* constraint, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraint_SetTargetOrientationCS(JPH_SwingTwistConstraint* constraint, [NativeTypeName("const JPH_Quat *")] quaternion* orientation);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraint_GetTargetOrientationCS(JPH_SwingTwistConstraint* constraint, [NativeTypeName("JPH_Quat *")] quaternion* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraint_SetTargetOrientationBS(JPH_SwingTwistConstraint* constraint, [NativeTypeName("const JPH_Quat *")] quaternion* orientation);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraint_GetRotationInConstraintSpace(JPH_SwingTwistConstraint* constraint, [NativeTypeName("JPH_Quat *")] quaternion* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraint_GetTotalLambdaPosition([NativeTypeName("const JPH_SwingTwistConstraint *")] JPH_SwingTwistConstraint* constraint, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_SwingTwistConstraint_GetTotalLambdaTwist([NativeTypeName("const JPH_SwingTwistConstraint *")] JPH_SwingTwistConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_SwingTwistConstraint_GetTotalLambdaSwingY([NativeTypeName("const JPH_SwingTwistConstraint *")] JPH_SwingTwistConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_SwingTwistConstraint_GetTotalLambdaSwingZ([NativeTypeName("const JPH_SwingTwistConstraint *")] JPH_SwingTwistConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SwingTwistConstraint_GetTotalLambdaMotor([NativeTypeName("const JPH_SwingTwistConstraint *")] JPH_SwingTwistConstraint* constraint, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_SixDOFConstraintSettings* JPH_SixDOFConstraintSettings_Create();

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_SixDOFConstraint* JPH_SixDOFConstraintSettings_CreateConstraint(JPH_SixDOFConstraintSettings* settings, JPH_Body* body1, JPH_Body* body2);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_SixDOFConstraint_GetLimitsMin(JPH_SixDOFConstraint* constraint, [NativeTypeName("JPH_SixDOFConstraintAxis")] SixDOFConstraintAxis axis);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_SixDOFConstraint_GetLimitsMax(JPH_SixDOFConstraint* constraint, [NativeTypeName("JPH_SixDOFConstraintAxis")] SixDOFConstraintAxis axis);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SixDOFConstraint_GetTotalLambdaPosition([NativeTypeName("const JPH_SixDOFConstraint *")] JPH_SixDOFConstraint* constraint, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SixDOFConstraint_GetTotalLambdaRotation([NativeTypeName("const JPH_SixDOFConstraint *")] JPH_SixDOFConstraint* constraint, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SixDOFConstraint_GetTotalLambdaMotorTranslation([NativeTypeName("const JPH_SixDOFConstraint *")] JPH_SixDOFConstraint* constraint, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_SixDOFConstraint_GetTotalLambdaMotorRotation([NativeTypeName("const JPH_SixDOFConstraint *")] JPH_SixDOFConstraint* constraint, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_Body* JPH_TwoBodyConstraint_GetBody1(JPH_TwoBodyConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_Body* JPH_TwoBodyConstraint_GetBody2(JPH_TwoBodyConstraint* constraint);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_TwoBodyConstraint_GetConstraintToBody1Matrix(JPH_TwoBodyConstraint* constraint, [NativeTypeName("JPH_Matrix4x4 *")] float4x4* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_TwoBodyConstraint_GetConstraintToBody2Matrix(JPH_TwoBodyConstraint* constraint, [NativeTypeName("JPH_Matrix4x4 *")] float4x4* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_DestroyBody(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyID);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_BodyID")]
        public static extern BodyID JPH_BodyInterface_CreateAndAddBody(JPH_BodyInterface* bodyInterface, JPH_BodyCreationSettings* settings, [NativeTypeName("JPH_Activation")] Activation activationMode);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_Body* JPH_BodyInterface_CreateBody(JPH_BodyInterface* bodyInterface, JPH_BodyCreationSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_Body* JPH_BodyInterface_CreateBodyWithID(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyID, JPH_BodyCreationSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_Body* JPH_BodyInterface_CreateBodyWithoutID(JPH_BodyInterface* bodyInterface, JPH_BodyCreationSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_DestroyBodyWithoutID(JPH_BodyInterface* bodyInterface, JPH_Body* body);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_BodyInterface_AssignBodyID(JPH_BodyInterface* bodyInterface, JPH_Body* body);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_BodyInterface_AssignBodyID2(JPH_BodyInterface* bodyInterface, JPH_Body* body, [NativeTypeName("JPH_BodyID")] BodyID bodyID);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_Body* JPH_BodyInterface_UnassignBodyID(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyID);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_Body* JPH_BodyInterface_CreateSoftBody(JPH_BodyInterface* bodyInterface, [NativeTypeName("const JPH_SoftBodyCreationSettings *")] JPH_SoftBodyCreationSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_Body* JPH_BodyInterface_CreateSoftBodyWithID(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyID, [NativeTypeName("const JPH_SoftBodyCreationSettings *")] JPH_SoftBodyCreationSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_Body* JPH_BodyInterface_CreateSoftBodyWithoutID(JPH_BodyInterface* bodyInterface, [NativeTypeName("const JPH_SoftBodyCreationSettings *")] JPH_SoftBodyCreationSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_BodyID")]
        public static extern BodyID JPH_BodyInterface_CreateAndAddSoftBody(JPH_BodyInterface* bodyInterface, [NativeTypeName("const JPH_SoftBodyCreationSettings *")] JPH_SoftBodyCreationSettings* settings, [NativeTypeName("JPH_Activation")] Activation activationMode);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_AddBody(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyID, [NativeTypeName("JPH_Activation")] Activation activationMode);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_RemoveBody(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyID);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_BodyInterface_IsActive(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyID);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_BodyInterface_IsAdded(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyID);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_BodyType")]
        public static extern BodyType JPH_BodyInterface_GetBodyType(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyID);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_SetLinearVelocity(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyID, [NativeTypeName("const JPH_Vec3 *")] float3* velocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_GetLinearVelocity(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyID, [NativeTypeName("JPH_Vec3 *")] float3* velocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_GetCenterOfMassPosition(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyID, [NativeTypeName("JPH_RVec3 *")] rvec3* position);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_MotionType")]
        public static extern MotionType JPH_BodyInterface_GetMotionType(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyID);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_SetMotionType(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyID, [NativeTypeName("JPH_MotionType")] MotionType motionType, [NativeTypeName("JPH_Activation")] Activation activationMode);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_BodyInterface_GetRestitution([NativeTypeName("const JPH_BodyInterface *")] JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyID);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_SetRestitution(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyID, float restitution);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_BodyInterface_GetFriction([NativeTypeName("const JPH_BodyInterface *")] JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyID);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_SetFriction(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyID, float friction);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_SetPosition(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("const JPH_RVec3 *")] rvec3* position, [NativeTypeName("JPH_Activation")] Activation activationMode);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_GetPosition(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("JPH_RVec3 *")] rvec3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_SetRotation(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("const JPH_Quat *")] quaternion* rotation, [NativeTypeName("JPH_Activation")] Activation activationMode);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_GetRotation(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("JPH_Quat *")] quaternion* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_SetPositionAndRotation(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("const JPH_RVec3 *")] rvec3* position, [NativeTypeName("const JPH_Quat *")] quaternion* rotation, [NativeTypeName("JPH_Activation")] Activation activationMode);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_SetPositionAndRotationWhenChanged(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("const JPH_RVec3 *")] rvec3* position, [NativeTypeName("const JPH_Quat *")] quaternion* rotation, [NativeTypeName("JPH_Activation")] Activation activationMode);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_SetPositionRotationAndVelocity(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("const JPH_RVec3 *")] rvec3* position, [NativeTypeName("const JPH_Quat *")] quaternion* rotation, [NativeTypeName("const JPH_Vec3 *")] float3* linearVelocity, [NativeTypeName("const JPH_Vec3 *")] float3* angularVelocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const JPH_Shape *")]
        public static extern JPH_Shape* JPH_BodyInterface_GetShape(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_SetShape(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("const JPH_Shape *")] JPH_Shape* shape, NativeBool updateMassProperties, [NativeTypeName("JPH_Activation")] Activation activationMode);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_NotifyShapeChanged(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("const JPH_Vec3 *")] float3* previousCenterOfMass, NativeBool updateMassProperties, [NativeTypeName("JPH_Activation")] Activation activationMode);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_ActivateBody(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_DeactivateBody(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_SetObjectLayer(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("JPH_ObjectLayer")] ObjectLayer layer);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_ObjectLayer")]
        public static extern ObjectLayer JPH_BodyInterface_GetObjectLayer(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_GetWorldTransform(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("JPH_RMatrix4x4 *")] rmatrix4x4* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_GetCenterOfMassTransform(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("JPH_RMatrix4x4 *")] rmatrix4x4* resutlt);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_MoveKinematic(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("const JPH_RVec3 *")] rvec3* targetPosition, [NativeTypeName("const JPH_Quat *")] quaternion* targetRotation, float deltaTime);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_SetLinearAndAngularVelocity(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("const JPH_Vec3 *")] float3* linearVelocity, [NativeTypeName("const JPH_Vec3 *")] float3* angularVelocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_GetLinearAndAngularVelocity(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("JPH_Vec3 *")] float3* linearVelocity, [NativeTypeName("JPH_Vec3 *")] float3* angularVelocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_AddLinearVelocity(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("const JPH_Vec3 *")] float3* linearVelocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_AddLinearAndAngularVelocity(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("const JPH_Vec3 *")] float3* linearVelocity, [NativeTypeName("const JPH_Vec3 *")] float3* angularVelocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_SetAngularVelocity(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("const JPH_Vec3 *")] float3* angularVelocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_GetAngularVelocity(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("JPH_Vec3 *")] float3* angularVelocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_GetPointVelocity(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("JPH_RVec3 *")] rvec3* point, [NativeTypeName("JPH_Vec3 *")] float3* velocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_AddForce(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("const JPH_Vec3 *")] float3* force);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_AddForce2(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("const JPH_Vec3 *")] float3* force, [NativeTypeName("const JPH_RVec3 *")] rvec3* point);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_AddTorque(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("const JPH_Vec3 *")] float3* torque);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_AddForceAndTorque(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("const JPH_Vec3 *")] float3* force, [NativeTypeName("const JPH_Vec3 *")] float3* torque);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_AddImpulse(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("const JPH_Vec3 *")] float3* impulse);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_AddImpulse2(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("const JPH_Vec3 *")] float3* impulse, [NativeTypeName("const JPH_RVec3 *")] rvec3* point);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_AddAngularImpulse(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("const JPH_Vec3 *")] float3* angularImpulse);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_SetMotionQuality(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("JPH_MotionQuality")] MotionQuality quality);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_MotionQuality")]
        public static extern MotionQuality JPH_BodyInterface_GetMotionQuality(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_GetInverseInertia(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("JPH_Matrix4x4 *")] float4x4* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_SetGravityFactor(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, float gravityFactor);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_BodyInterface_GetGravityFactor(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_InvalidateContactCache(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyInterface_SetUserData(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId, [NativeTypeName("uint64_t")] ulong inUserData);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong JPH_BodyInterface_GetUserData(JPH_BodyInterface* bodyInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyId);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyLockInterface_LockRead([NativeTypeName("const JPH_BodyLockInterface *")] JPH_BodyLockInterface* lockInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyID, JPH_BodyLockRead* outLock);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyLockInterface_UnlockRead([NativeTypeName("const JPH_BodyLockInterface *")] JPH_BodyLockInterface* lockInterface, JPH_BodyLockRead* ioLock);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyLockInterface_LockWrite([NativeTypeName("const JPH_BodyLockInterface *")] JPH_BodyLockInterface* lockInterface, [NativeTypeName("JPH_BodyID")] BodyID bodyID, JPH_BodyLockWrite* outLock);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyLockInterface_UnlockWrite([NativeTypeName("const JPH_BodyLockInterface *")] JPH_BodyLockInterface* lockInterface, JPH_BodyLockWrite* ioLock);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_AllowedDOFs")]
        public static extern AllowedDOFs JPH_MotionProperties_GetAllowedDOFs([NativeTypeName("const JPH_MotionProperties *")] JPH_MotionProperties* properties);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_MotionProperties_SetLinearDamping(JPH_MotionProperties* properties, float damping);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_MotionProperties_GetLinearDamping([NativeTypeName("const JPH_MotionProperties *")] JPH_MotionProperties* properties);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_MotionProperties_SetAngularDamping(JPH_MotionProperties* properties, float damping);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_MotionProperties_GetAngularDamping([NativeTypeName("const JPH_MotionProperties *")] JPH_MotionProperties* properties);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_MotionProperties_SetMassProperties(JPH_MotionProperties* properties, [NativeTypeName("JPH_AllowedDOFs")] AllowedDOFs allowedDOFs, [NativeTypeName("const JPH_MassProperties *")] MassProperties* massProperties);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_MotionProperties_GetInverseMassUnchecked(JPH_MotionProperties* properties);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_MotionProperties_SetInverseMass(JPH_MotionProperties* properties, float inverseMass);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_MotionProperties_GetInverseInertiaDiagonal(JPH_MotionProperties* properties, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_MotionProperties_GetInertiaRotation(JPH_MotionProperties* properties, [NativeTypeName("JPH_Quat *")] quaternion* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_MotionProperties_SetInverseInertia(JPH_MotionProperties* properties, [NativeTypeName("const JPH_Vec3 *")] float3* diagonal, [NativeTypeName("const JPH_Quat *")] quaternion* rot);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_MassProperties_DecomposePrincipalMomentsOfInertia([NativeTypeName("JPH_MassProperties *")] MassProperties* properties, [NativeTypeName("JPH_Matrix4x4 *")] float4x4* rotation, [NativeTypeName("JPH_Vec3 *")] float3* diagonal);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_MassProperties_ScaleToMass([NativeTypeName("JPH_MassProperties *")] MassProperties* properties, float mass);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_BroadPhaseQuery_CastRay([NativeTypeName("const JPH_BroadPhaseQuery *")] JPH_BroadPhaseQuery* query, [NativeTypeName("const JPH_Vec3 *")] float3* origin, [NativeTypeName("const JPH_Vec3 *")] float3* direction, [NativeTypeName("JPH_RayCastBodyCollector *")] IntPtr callback, void* userData, JPH_BroadPhaseLayerFilter* broadPhaseLayerFilter, JPH_ObjectLayerFilter* objectLayerFilter);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_BroadPhaseQuery_CollideAABox([NativeTypeName("const JPH_BroadPhaseQuery *")] JPH_BroadPhaseQuery* query, [NativeTypeName("const JPH_AABox *")] AABox* box, [NativeTypeName("JPH_CollideShapeBodyCollector *")] IntPtr callback, void* userData, JPH_BroadPhaseLayerFilter* broadPhaseLayerFilter, JPH_ObjectLayerFilter* objectLayerFilter);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_BroadPhaseQuery_CollideSphere([NativeTypeName("const JPH_BroadPhaseQuery *")] JPH_BroadPhaseQuery* query, [NativeTypeName("const JPH_Vec3 *")] float3* center, float radius, [NativeTypeName("JPH_CollideShapeBodyCollector *")] IntPtr callback, void* userData, JPH_BroadPhaseLayerFilter* broadPhaseLayerFilter, JPH_ObjectLayerFilter* objectLayerFilter);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_BroadPhaseQuery_CollidePoint([NativeTypeName("const JPH_BroadPhaseQuery *")] JPH_BroadPhaseQuery* query, [NativeTypeName("const JPH_Vec3 *")] float3* point, [NativeTypeName("JPH_CollideShapeBodyCollector *")] IntPtr callback, void* userData, JPH_BroadPhaseLayerFilter* broadPhaseLayerFilter, JPH_ObjectLayerFilter* objectLayerFilter);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_NarrowPhaseQuery_CastRay([NativeTypeName("const JPH_NarrowPhaseQuery *")] JPH_NarrowPhaseQuery* query, [NativeTypeName("const JPH_RVec3 *")] rvec3* origin, [NativeTypeName("const JPH_Vec3 *")] float3* direction, JPH_RayCastResult* hit, JPH_BroadPhaseLayerFilter* broadPhaseLayerFilter, JPH_ObjectLayerFilter* objectLayerFilter, JPH_BodyFilter* bodyFilter);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_NarrowPhaseQuery_CastRay2([NativeTypeName("const JPH_NarrowPhaseQuery *")] JPH_NarrowPhaseQuery* query, [NativeTypeName("const JPH_RVec3 *")] rvec3* origin, [NativeTypeName("const JPH_Vec3 *")] float3* direction, [NativeTypeName("JPH_CastRayCollector *")] IntPtr callback, void* userData, JPH_BroadPhaseLayerFilter* broadPhaseLayerFilter, JPH_ObjectLayerFilter* objectLayerFilter, JPH_BodyFilter* bodyFilter);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_NarrowPhaseQuery_CollidePoint([NativeTypeName("const JPH_NarrowPhaseQuery *")] JPH_NarrowPhaseQuery* query, [NativeTypeName("const JPH_RVec3 *")] rvec3* point, [NativeTypeName("JPH_CollidePointCollector *")] IntPtr callback, void* userData, JPH_BroadPhaseLayerFilter* broadPhaseLayerFilter, JPH_ObjectLayerFilter* objectLayerFilter, JPH_BodyFilter* bodyFilter);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_NarrowPhaseQuery_CollideShape([NativeTypeName("const JPH_NarrowPhaseQuery *")] JPH_NarrowPhaseQuery* query, [NativeTypeName("const JPH_Shape *")] JPH_Shape* shape, [NativeTypeName("const JPH_Vec3 *")] float3* scale, [NativeTypeName("const JPH_RMatrix4x4 *")] rmatrix4x4* centerOfMassTransform, [NativeTypeName("JPH_RVec3 *")] rvec3* baseOffset, [NativeTypeName("JPH_CollideShapeCollector *")] IntPtr callback, void* userData, JPH_BroadPhaseLayerFilter* broadPhaseLayerFilter, JPH_ObjectLayerFilter* objectLayerFilter, JPH_BodyFilter* bodyFilter);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_NarrowPhaseQuery_CastShape([NativeTypeName("const JPH_NarrowPhaseQuery *")] JPH_NarrowPhaseQuery* query, [NativeTypeName("const JPH_Shape *")] JPH_Shape* shape, [NativeTypeName("const JPH_RMatrix4x4 *")] rmatrix4x4* centerOfMassTransform, [NativeTypeName("const JPH_Vec3 *")] float3* direction, [NativeTypeName("JPH_RVec3 *")] rvec3* baseOffset, [NativeTypeName("JPH_CastShapeCollector *")] IntPtr callback, void* userData, JPH_BroadPhaseLayerFilter* broadPhaseLayerFilter, JPH_ObjectLayerFilter* objectLayerFilter, JPH_BodyFilter* bodyFilter);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_BodyID")]
        public static extern BodyID JPH_Body_GetID([NativeTypeName("const JPH_Body *")] JPH_Body* body);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_BodyType")]
        public static extern BodyType JPH_Body_GetBodyType([NativeTypeName("const JPH_Body *")] JPH_Body* body);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_GetWorldSpaceBounds([NativeTypeName("const JPH_Body *")] JPH_Body* body, [NativeTypeName("JPH_AABox *")] AABox* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_GetWorldSpaceSurfaceNormal([NativeTypeName("const JPH_Body *")] JPH_Body* body, [NativeTypeName("JPH_SubShapeID")] uint subShapeID, [NativeTypeName("const JPH_RVec3 *")] rvec3* position, [NativeTypeName("JPH_Vec3 *")] float3* normal);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_Body_IsActive([NativeTypeName("const JPH_Body *")] JPH_Body* body);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_Body_IsStatic([NativeTypeName("const JPH_Body *")] JPH_Body* body);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_Body_IsKinematic([NativeTypeName("const JPH_Body *")] JPH_Body* body);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_Body_IsDynamic([NativeTypeName("const JPH_Body *")] JPH_Body* body);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_Body_IsSensor([NativeTypeName("const JPH_Body *")] JPH_Body* body);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_SetIsSensor(JPH_Body* body, NativeBool value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_SetCollideKinematicVsNonDynamic(JPH_Body* body, NativeBool value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_Body_GetCollideKinematicVsNonDynamic([NativeTypeName("const JPH_Body *")] JPH_Body* body);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_SetUseManifoldReduction(JPH_Body* body, NativeBool value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_Body_GetUseManifoldReduction([NativeTypeName("const JPH_Body *")] JPH_Body* body);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_Body_GetUseManifoldReductionWithBody([NativeTypeName("const JPH_Body *")] JPH_Body* body, [NativeTypeName("const JPH_Body *")] JPH_Body* other);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_SetApplyGyroscopicForce(JPH_Body* body, NativeBool value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_Body_GetApplyGyroscopicForce([NativeTypeName("const JPH_Body *")] JPH_Body* body);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_MotionProperties* JPH_Body_GetMotionProperties(JPH_Body* body);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_MotionType")]
        public static extern MotionType JPH_Body_GetMotionType([NativeTypeName("const JPH_Body *")] JPH_Body* body);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_SetMotionType(JPH_Body* body, [NativeTypeName("JPH_MotionType")] MotionType motionType);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_Body_GetAllowSleeping(JPH_Body* body);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_SetAllowSleeping(JPH_Body* body, NativeBool allowSleeping);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_ResetSleepTimer(JPH_Body* body);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_Body_GetFriction([NativeTypeName("const JPH_Body *")] JPH_Body* body);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_SetFriction(JPH_Body* body, float friction);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_Body_GetRestitution([NativeTypeName("const JPH_Body *")] JPH_Body* body);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_SetRestitution(JPH_Body* body, float restitution);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_GetLinearVelocity(JPH_Body* body, [NativeTypeName("JPH_Vec3 *")] float3* velocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_SetLinearVelocity(JPH_Body* body, [NativeTypeName("const JPH_Vec3 *")] float3* velocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_GetAngularVelocity(JPH_Body* body, [NativeTypeName("JPH_Vec3 *")] float3* velocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_SetAngularVelocity(JPH_Body* body, [NativeTypeName("const JPH_Vec3 *")] float3* velocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_AddForce(JPH_Body* body, [NativeTypeName("const JPH_Vec3 *")] float3* force);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_AddForceAtPosition(JPH_Body* body, [NativeTypeName("const JPH_Vec3 *")] float3* force, [NativeTypeName("const JPH_RVec3 *")] rvec3* position);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_AddTorque(JPH_Body* body, [NativeTypeName("const JPH_Vec3 *")] float3* force);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_GetAccumulatedForce(JPH_Body* body, [NativeTypeName("JPH_Vec3 *")] float3* force);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_GetAccumulatedTorque(JPH_Body* body, [NativeTypeName("JPH_Vec3 *")] float3* force);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_AddImpulse(JPH_Body* body, [NativeTypeName("const JPH_Vec3 *")] float3* impulse);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_AddImpulseAtPosition(JPH_Body* body, [NativeTypeName("const JPH_Vec3 *")] float3* impulse, [NativeTypeName("const JPH_RVec3 *")] rvec3* position);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_AddAngularImpulse(JPH_Body* body, [NativeTypeName("const JPH_Vec3 *")] float3* angularImpulse);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_GetPosition([NativeTypeName("const JPH_Body *")] JPH_Body* body, [NativeTypeName("JPH_RVec3 *")] rvec3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_GetRotation([NativeTypeName("const JPH_Body *")] JPH_Body* body, [NativeTypeName("JPH_Quat *")] quaternion* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_GetCenterOfMassPosition([NativeTypeName("const JPH_Body *")] JPH_Body* body, [NativeTypeName("JPH_RVec3 *")] rvec3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_GetWorldTransform([NativeTypeName("const JPH_Body *")] JPH_Body* body, [NativeTypeName("JPH_RMatrix4x4 *")] rmatrix4x4* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_GetCenterOfMassTransform([NativeTypeName("const JPH_Body *")] JPH_Body* body, [NativeTypeName("JPH_RMatrix4x4 *")] rmatrix4x4* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_Body_SetUserData(JPH_Body* body, [NativeTypeName("uint64_t")] ulong userData);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong JPH_Body_GetUserData(JPH_Body* body);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BroadPhaseLayerFilter_SetProcs(JPH_BroadPhaseLayerFilter* filter, JPH_BroadPhaseLayerFilter_Procs procs, void* userData);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_BroadPhaseLayerFilter* JPH_BroadPhaseLayerFilter_Create();

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BroadPhaseLayerFilter_Destroy(JPH_BroadPhaseLayerFilter* filter);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ObjectLayerFilter_SetProcs(JPH_ObjectLayerFilter* filter, JPH_ObjectLayerFilter_Procs procs, void* userData);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_ObjectLayerFilter* JPH_ObjectLayerFilter_Create();

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ObjectLayerFilter_Destroy(JPH_ObjectLayerFilter* filter);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyFilter_SetProcs(JPH_BodyFilter* filter, JPH_BodyFilter_Procs procs, void* userData);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_BodyFilter* JPH_BodyFilter_Create();

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyFilter_Destroy(JPH_BodyFilter* filter);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ContactListener_SetProcs(JPH_ContactListener* listener, JPH_ContactListener_Procs procs, void* userData);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_ContactListener* JPH_ContactListener_Create();

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ContactListener_Destroy(JPH_ContactListener* listener);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyActivationListener_SetProcs(JPH_BodyActivationListener* listener, JPH_BodyActivationListener_Procs procs, void* userData);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_BodyActivationListener* JPH_BodyActivationListener_Create();

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_BodyActivationListener_Destroy(JPH_BodyActivationListener* listener);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ContactManifold_GetWorldSpaceNormal([NativeTypeName("const JPH_ContactManifold *")] JPH_ContactManifold* manifold, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_ContactManifold_GetPenetrationDepth([NativeTypeName("const JPH_ContactManifold *")] JPH_ContactManifold* manifold);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_SubShapeID")]
        public static extern uint JPH_ContactManifold_GetSubShapeID1([NativeTypeName("const JPH_ContactManifold *")] JPH_ContactManifold* manifold);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_SubShapeID")]
        public static extern uint JPH_ContactManifold_GetSubShapeID2([NativeTypeName("const JPH_ContactManifold *")] JPH_ContactManifold* manifold);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint JPH_ContactManifold_GetPointCount([NativeTypeName("const JPH_ContactManifold *")] JPH_ContactManifold* manifold);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ContactManifold_GetWorldSpaceContactPointOn1([NativeTypeName("const JPH_ContactManifold *")] JPH_ContactManifold* manifold, uint index, [NativeTypeName("JPH_RVec3 *")] rvec3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ContactManifold_GetWorldSpaceContactPointOn2([NativeTypeName("const JPH_ContactManifold *")] JPH_ContactManifold* manifold, uint index, [NativeTypeName("JPH_RVec3 *")] rvec3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_ContactSettings_GetFriction(JPH_ContactSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ContactSettings_SetFriction(JPH_ContactSettings* settings, float friction);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_ContactSettings_GetRestitution(JPH_ContactSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ContactSettings_SetRestitution(JPH_ContactSettings* settings, float restitution);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_ContactSettings_GetInvMassScale1(JPH_ContactSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ContactSettings_SetInvMassScale1(JPH_ContactSettings* settings, float scale);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_ContactSettings_GetInvInertiaScale1(JPH_ContactSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ContactSettings_SetInvInertiaScale1(JPH_ContactSettings* settings, float scale);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_ContactSettings_GetInvMassScale2(JPH_ContactSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ContactSettings_SetInvMassScale2(JPH_ContactSettings* settings, float scale);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_ContactSettings_GetInvInertiaScale2(JPH_ContactSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ContactSettings_SetInvInertiaScale2(JPH_ContactSettings* settings, float scale);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_ContactSettings_GetIsSensor(JPH_ContactSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ContactSettings_SetIsSensor(JPH_ContactSettings* settings, NativeBool sensor);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ContactSettings_GetRelativeLinearSurfaceVelocity(JPH_ContactSettings* settings, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ContactSettings_SetRelativeLinearSurfaceVelocity(JPH_ContactSettings* settings, [NativeTypeName("const JPH_Vec3 *")] float3* velocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ContactSettings_GetRelativeAngularSurfaceVelocity(JPH_ContactSettings* settings, [NativeTypeName("JPH_Vec3 *")] float3* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_ContactSettings_SetRelativeAngularSurfaceVelocity(JPH_ContactSettings* settings, [NativeTypeName("const JPH_Vec3 *")] float3* velocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterBaseSettings_Destroy(JPH_CharacterBaseSettings* settings);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterBaseSettings_SetSupportingVolume(JPH_CharacterBaseSettings* settings, [NativeTypeName("const JPH_Vec3 *")] float3* normal, float constant);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterBaseSettings_SetMaxSlopeAngle(JPH_CharacterBaseSettings* settings, float maxSlopeAngle);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterBaseSettings_SetShape(JPH_CharacterBaseSettings* settings, JPH_Shape* shape);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterBase_Destroy(JPH_CharacterBase* character);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_GroundState")]
        public static extern GroundState JPH_CharacterBase_GetGroundState(JPH_CharacterBase* character);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_CharacterBase_IsSupported(JPH_CharacterBase* character);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterBase_GetGroundPosition(JPH_CharacterBase* character, [NativeTypeName("JPH_RVec3 *")] rvec3* position);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterBase_GetGroundNormal(JPH_CharacterBase* character, [NativeTypeName("JPH_Vec3 *")] float3* normal);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterBase_GetGroundVelocity(JPH_CharacterBase* character, [NativeTypeName("JPH_Vec3 *")] float3* velocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_BodyID")]
        public static extern BodyID JPH_CharacterBase_GetGroundBodyId(JPH_CharacterBase* character);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("JPH_SubShapeID")]
        public static extern uint JPH_CharacterBase_GetGroundSubShapeId(JPH_CharacterBase* character);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_CharacterVirtualSettings* JPH_CharacterVirtualSettings_Create();

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_CharacterVirtual* JPH_CharacterVirtual_Create([NativeTypeName("const JPH_CharacterVirtualSettings *")] JPH_CharacterVirtualSettings* settings, [NativeTypeName("const JPH_RVec3 *")] rvec3* position, [NativeTypeName("const JPH_Quat *")] quaternion* rotation, [NativeTypeName("uint64_t")] ulong userData, JPH_PhysicsSystem* system);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterVirtual_SetListener(JPH_CharacterVirtual* character, JPH_CharacterContactListener* listener);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterVirtual_GetLinearVelocity(JPH_CharacterVirtual* character, [NativeTypeName("JPH_Vec3 *")] float3* velocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterVirtual_SetLinearVelocity(JPH_CharacterVirtual* character, [NativeTypeName("const JPH_Vec3 *")] float3* velocity);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterVirtual_GetPosition(JPH_CharacterVirtual* character, [NativeTypeName("JPH_RVec3 *")] rvec3* position);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterVirtual_SetPosition(JPH_CharacterVirtual* character, [NativeTypeName("const JPH_RVec3 *")] rvec3* position);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterVirtual_GetRotation(JPH_CharacterVirtual* character, [NativeTypeName("JPH_Quat *")] quaternion* rotation);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterVirtual_SetRotation(JPH_CharacterVirtual* character, [NativeTypeName("const JPH_Quat *")] quaternion* rotation);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterVirtual_GetWorldTransform(JPH_CharacterVirtual* character, [NativeTypeName("JPH_RMatrix4x4 *")] rmatrix4x4* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterVirtual_GetCenterOfMassTransform(JPH_CharacterVirtual* character, [NativeTypeName("JPH_RMatrix4x4 *")] rmatrix4x4* result);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_CharacterVirtual_GetMass(JPH_CharacterVirtual* character);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterVirtual_SetMass(JPH_CharacterVirtual* character, float value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_CharacterVirtual_GetMaxStrength(JPH_CharacterVirtual* character);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterVirtual_SetMaxStrength(JPH_CharacterVirtual* character, float value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_CharacterVirtual_GetPenetrationRecoverySpeed(JPH_CharacterVirtual* character);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterVirtual_SetPenetrationRecoverySpeed(JPH_CharacterVirtual* character, float value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool JPH_CharacterVirtual_GetEnhancedInternalEdgeRemoval(JPH_CharacterVirtual* character);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterVirtual_SetEnhancedInternalEdgeRemoval(JPH_CharacterVirtual* character, NativeBool value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_CharacterVirtual_GetCharacterPadding(JPH_CharacterVirtual* character);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint JPH_CharacterVirtual_GetMaxNumHits(JPH_CharacterVirtual* character);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterVirtual_SetMaxNumHits(JPH_CharacterVirtual* character, uint value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float JPH_CharacterVirtual_GetHitReductionCosMaxAngle(JPH_CharacterVirtual* character);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterVirtual_SetHitReductionCosMaxAngle(JPH_CharacterVirtual* character, float value);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterVirtual_Update(JPH_CharacterVirtual* character, float deltaTime, [NativeTypeName("JPH_ObjectLayer")] ObjectLayer layer, JPH_PhysicsSystem* system);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterVirtual_ExtendedUpdate(JPH_CharacterVirtual* character, float deltaTime, [NativeTypeName("const JPH_ExtendedUpdateSettings *")] JPH_ExtendedUpdateSettings* settings, [NativeTypeName("JPH_ObjectLayer")] ObjectLayer layer, JPH_PhysicsSystem* system);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterVirtual_RefreshContacts(JPH_CharacterVirtual* character, [NativeTypeName("JPH_ObjectLayer")] ObjectLayer layer, JPH_PhysicsSystem* system);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern JPH_CharacterContactListener* JPH_CharacterContactListener_Create(JPH_CharacterContactListener_Procs procs, void* userData);

        [DllImport("joltc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void JPH_CharacterContactListener_Destroy(JPH_CharacterContactListener* listener);
    }
}
