using UnityEngine;

namespace Jolt.Samples
{
    public class PhysicsShapeSphere : MonoBehaviour, IPhysicsShapeComponent
    {
        public float Radius = 0.5f;
        
        public ShapeSettings ShapeSettings => SphereShapeSettings.Create(Radius);
    }
}
