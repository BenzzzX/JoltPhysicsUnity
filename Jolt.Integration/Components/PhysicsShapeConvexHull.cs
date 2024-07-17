using System;
using Unity.Mathematics;
using UnityEngine;

namespace Jolt.Integration
{
    public class PhysicsShapeConvexHull : MonoBehaviour, IPhysicsShapeComponent
    {
        public Mesh Mesh;

        public float MaxConvexRadius = PhysicsSettings.DefaultConvexRadius;

        public ReadOnlySpan<float3> BuildMeshPoints()
        {
            var points = new float3[Mesh.vertices.Length];

            for (var i = 0; i < Mesh.vertices.Length; i++)
            {
                points[i] = Vector3.Scale(Mesh.vertices[i], transform.localScale);
            }

            return points;
        }
        
        public ShapeSettings ShapeSettings => ConvexHullShapeSettings.Create(BuildMeshPoints(), MaxConvexRadius);
    }
}
