﻿using UnityEngine;

namespace Jolt.Integration
{
    public class PhysicsShapeCapsule : MonoBehaviour, IPhysicsShapeComponent
    {
        public float Radius = 0.5f;

        public float HalfHeight = 0.5f;
        
        public ShapeSettings ShapeSettings => CapsuleShapeSettings.Create(HalfHeight, Radius);
    }
}
