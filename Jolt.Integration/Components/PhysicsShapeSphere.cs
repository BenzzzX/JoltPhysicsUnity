using UnityEngine;

namespace Jolt.Integration
{
    public class PhysicsShapeSphere : MonoBehaviour, IPhysicsShapeComponent
    {
        public float Radius = 0.5f;
        
        public ShapeSettings ShapeSettings => SphereShapeSettings.Create(Radius);
    }
}
