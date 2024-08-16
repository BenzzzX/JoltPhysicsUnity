using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_PhysicsSystem")]
    public partial struct PhysicsSystem : IDisposable
    {
        internal readonly NativeHandle<JPH_PhysicsSystem> Handle;

        internal readonly NativeHandle<JPH_ContactListener> ContactListenerHandle;

        internal readonly NativeHandle<JPH_BodyActivationListener> BodyActivationListenerHandle;

        /// <summary>
        /// The ObjectLayerPairFilter of the system.
        /// </summary>
        public ObjectLayerPairFilter ObjectLayerPairFilter;

        /// <summary>
        /// The BroadPhaseLayerInterface of the system.
        /// </summary>
        public BroadPhaseLayerInterface BroadPhaseLayerInterface;

        /// <summary>
        /// The ObjectVsBroadPhaseLayerFilter of the system.
        /// </summary>
        public ObjectVsBroadPhaseLayerFilter ObjectVsBroadPhaseLayerFilter;

        internal PhysicsSystem(PhysicsSystemSettings settings)
        {
            var nativeSettings = new JPH_PhysicsSystemSettings
            {
                maxBodies = settings.MaxBodies,
                maxBodyPairs = settings.MaxBodyPairs,
                maxContactConstraints = settings.MaxContactConstraints,
                objectLayerPairFilter = settings.ObjectLayerPairFilter.Handle,
                broadPhaseLayerInterface = settings.BroadPhaseLayerInterface.Handle,
                objectVsBroadPhaseLayerFilter = settings.ObjectVsBroadPhaseLayerFilter.Handle
            };
            Handle = JPH_PhysicsSystem_Create(nativeSettings);

            ObjectLayerPairFilter = settings.ObjectLayerPairFilter;

            BroadPhaseLayerInterface = settings.BroadPhaseLayerInterface;

            ObjectVsBroadPhaseLayerFilter = settings.ObjectVsBroadPhaseLayerFilter;

            ContactListenerHandle = JPH_ContactListener_Create();

            JPH_PhysicsSystem_SetContactListener(Handle, ContactListenerHandle);

            BodyActivationListenerHandle = JPH_BodyActivationListener_Create();

            JPH_PhysicsSystem_SetBodyActivationListener(Handle, BodyActivationListenerHandle);
        }
        
        [OverrideBinding("JPH_PhysicsSystem_Create")]
        public static PhysicsSystem Create(PhysicsSystemSettings settings)
        {
            return new PhysicsSystem(settings);
        }
        
        [OverrideBinding("JPH_PhysicsSystem_GetBodyInterface")]
        public BodyInterface GetBodyInterface()
        {
            return new BodyInterface(JPH_PhysicsSystem_GetBodyInterface(Handle));
        }

        [OverrideBinding("JPH_PhysicsSystem_GetBodyInterfaceNoLock")]
        public BodyInterface GetBodyInterfaceNoLock()
        {
            return new BodyInterface(JPH_PhysicsSystem_GetBodyInterfaceNoLock(Handle));
        }
        
        [OverrideBinding("JPH_PhysicsSystem_GetBodyLockInterface")]
        public BodyLockInterface GetBodyLockInterface()
        {
            return new BodyLockInterface(JPH_PhysicsSystem_GetBodyLockInterface(Handle));
        }
        
        [OverrideBinding("JPH_PhysicsSystem_GetBodyLockInterfaceNoLock")]
        public BodyLockInterface GetBodyLockInterfaceNoLock()
        {
            return new BodyLockInterface(JPH_PhysicsSystem_GetBodyLockInterfaceNoLock(Handle));
        }
        
        [OverrideBinding("JPH_PhysicsSystem_AddConstraints")]
        public unsafe void AddConstraints<T>(NativeArray<T> constraints) where T : struct, IConstraint
        {
            JPH_PhysicsSystem_AddConstraints(Handle, (JPH_Constraint**)constraints.GetUnsafePtr(), (uint)constraints.Length);
        }
        
        [OverrideBinding("JPH_PhysicsSystem_RemoveConstraints")]
        public unsafe void RemoveConstraints<T>(NativeArray<T> constraints) where T : struct, IConstraint
        {
            JPH_PhysicsSystem_RemoveConstraints(Handle, (JPH_Constraint**)constraints.GetUnsafePtr(), (uint)constraints.Length);
        }
        
        [OverrideBinding("JPH_PhysicsSystem_GetConstraints")]
        public unsafe void GetConstraints(NativeArray<Constraint> outConstraints)
        {
            JPH_PhysicsSystem_GetConstraints(Handle, (JPH_Constraint**)outConstraints.GetUnsafePtr(), (uint)outConstraints.Length);
        }
        
        [OverrideBinding("JPH_PhysicsSystem_AddConstraint")]
        public void AddConstraint<T>(T constraint) where T : IConstraint
        {
            JPH_PhysicsSystem_AddConstraint(Handle, constraint.Handle.Reinterpret<JPH_Constraint>());
        }
        
        [OverrideBinding("JPH_PhysicsSystem_RemoveConstraint")]
        public void RemoveConstraint<T>(T constraint) where T : IConstraint
        {
            JPH_PhysicsSystem_RemoveConstraint(Handle, constraint.Handle.Reinterpret<JPH_Constraint>());
        }
        
        [OverrideBinding("JPH_PhysicsSystem_GetBroadPhaseQuery")]
        public BroadPhaseQuery GetBroadPhaseQuery()
        {
            return new BroadPhaseQuery(JPH_PhysicsSystem_GetBroadPhaseQuery(Handle));
        }
        
        [OverrideBinding("JPH_PhysicsSystem_GetNarrowPhaseQuery")]
        public NarrowPhaseQuery GetNarrowPhaseQuery()
        {
            return new NarrowPhaseQuery(JPH_PhysicsSystem_GetNarrowPhaseQuery(Handle));
        }
        
        [OverrideBinding("JPH_PhysicsSystem_GetNarrowPhaseQueryNoLock")]
        public NarrowPhaseQuery GetNarrowPhaseQueryNoLock()
        {
            return new NarrowPhaseQuery(JPH_PhysicsSystem_GetNarrowPhaseQueryNoLock(Handle));
        }

        [OverrideBinding("JPH_PhysicsSystem_SetContactListener")]
        public void SetContactListener(IContactListener listener)
        {
            JPH_ContactListener_SetProcs(ContactListenerHandle, listener);
        }

        [OverrideBinding("JPH_PhysicsSystem_SetBodyActivationListener")]
        public void SetBodyActivationListener(IBodyActivationListener listener)
        {
            JPH_BodyActivationListener_SetProcs(BodyActivationListenerHandle, listener);
        }

        /// <summary>
        /// Update the physics system. Returns true if there were no errors.
        /// </summary>
        /// <remarks>
        /// The out parameter will contain the error if any.
        /// </remarks>
        public bool Step(float deltaTime, int collisionSteps, out PhysicsUpdateError error)
        {
            return (error = JPH_PhysicsSystem_Step(Handle, deltaTime, collisionSteps)) == PhysicsUpdateError.None;
        }
        
        public unsafe delegate float CombineRestitutionDelegate(JPH_Body* body1, uint* subShapeID1, JPH_Body* body2, uint* subShapeID2);
        public unsafe void SetCombineRestitution(CombineRestitutionDelegate combineRestitution)
        {
            IntPtr ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(combineRestitution);
            UnsafeBindings.JPH_PhysicsSystem_SetCombineRestitution(Handle, ptr);
        }

        public void Dispose()
        {
            JPH_ContactListener_Destroy(ContactListenerHandle);
            JPH_BodyActivationListener_Destroy(BodyActivationListenerHandle);
            Destroy();
        }
    }
}
