using UnityEngine;

namespace Jolt.Integration
{
    public class PhysicsShapeCylinder : MonoBehaviour, IPhysicsShapeComponent
    {
        public float Radius = 0.5f;

        public float HalfHeight = 0.5f;

        public float ConvexRadius = PhysicsSettings.DefaultConvexRadius;
        
        public ShapeSettings ShapeSettings => CylinderShapeSettings.Create(HalfHeight, Radius, ConvexRadius);
    }
}
