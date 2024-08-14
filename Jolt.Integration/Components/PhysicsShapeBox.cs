using System;
using Unity.Mathematics;
using UnityEngine;

namespace Jolt.Integration
{
    public class PhysicsShapeBox : MonoBehaviour, IPhysicsShapeComponent
    {
        public float3 HalfExtent = new (0.5f, 0.5f, 0.5f);

        public float ConvexRadius = PhysicsSettings.DefaultConvexRadius;
        
        public ShapeSettings ShapeSettings => BoxShapeSettings.Create(HalfExtent, ConvexRadius);

        private void OnValidate()
        {
            // assert convex radius must be less than half the smallest extent
            var minExtent = math.cmin(HalfExtent);
            var objName = gameObject.name;
            Debug.Assert(ConvexRadius < minExtent, $"{objName}: Convex radius must be less than half the smallest extent.");
        }

        private void Awake()
        {
            // assert convex radius must be less than half the smallest extent
            var minExtent = math.cmin(HalfExtent);
            var objName = gameObject.name;
            Debug.Assert(ConvexRadius < minExtent, $"{objName}: Convex radius must be less than half the smallest extent.");
        }
    }
}
