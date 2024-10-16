﻿using UnityEngine;

namespace Jolt.Integration
{
    public class PhysicsShapeTaperedCapsule : MonoBehaviour, IPhysicsShapeComponent
    {
        public float TopRadius = 0.5f;

        public float BottomRadius = 0.5f;

        public float HalfHeight = 0.5f;
        
        public ShapeSettings ShapeSettings => TaperedCapsuleShapeSettings.Create(HalfHeight, TopRadius, BottomRadius);
    }
}
