using System;
using Unity.Mathematics;
using UnityEngine;

namespace Jolt.Integration
{
    // convert unity collider to jolt physics shape
    [RequireComponent(typeof(Collider))]
    public class PhysicsShapeUnity : MonoBehaviour, IPhysicsShapeComponent
    {
        public bool compound = false;
        public static ReadOnlySpan<float3> BuildMeshVertices(Mesh mesh, Vector3 scale)
        {
            var result = new float3[mesh.vertices.Length];

            for (var i = 0; i < result.Length; i++)
            {
                result[i] = Vector3.Scale(mesh.vertices[i], scale);
            }

            return result;
        }

        public static ReadOnlySpan<IndexedTriangle> BuildMeshTriangles(Mesh mesh)
        {
            var result = new IndexedTriangle[mesh.triangles.Length];

            const uint materialIndex = 0; // TODO

            for (var i = 0; i < mesh.triangles.Length; i += 3)
            {
                var i1 = (uint) mesh.triangles[i + 0];
                var i2 = (uint) mesh.triangles[i + 1];
                var i3 = (uint) mesh.triangles[i + 2];

                result[i] = new IndexedTriangle(i1, i2, i3, materialIndex);
            }

            return result;
        }
        
        static ShapeSettings FromCollidor(Collider collider, bool compound)
        {
            if (collider is BoxCollider boxCollider)
            {
                return BoxShapeSettings.Create(boxCollider.size / 2, boxCollider.contactOffset);
            }
            else if (collider is SphereCollider sphereCollider)
            {
                return SphereShapeSettings.Create(sphereCollider.radius);
            }
            else if (collider is CapsuleCollider capsuleCollider)
            {
                return CapsuleShapeSettings.Create(capsuleCollider.height / 2, capsuleCollider.radius);
            }
            else if (collider is MeshCollider meshCollider)
            {
                return MeshShapeSettings.Create(BuildMeshVertices(meshCollider.sharedMesh, collider.transform.localScale), BuildMeshTriangles(meshCollider.sharedMesh));
            }
            else if(compound)
            {
                CompoundShapeSettings settings;

                settings = StaticCompoundShapeSettings.Create();

                // Very simple single depth compound collider creation. Not intended for robust use.

                for (var i = 0; i < collider.transform.childCount; i++)
                {
                    var child = collider.transform.GetChild(i);

                    var childBody = child.GetComponent<Collider>();
                    if (childBody == null) continue;
                    var s = FromCollidor(childBody, false);
                    settings.AddShape(child.localPosition, child.localRotation, s);
                }

                return settings;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        public ShapeSettings ShapeSettings
        {
            get
            {
                Collider collider = GetComponent<Collider>();
                return FromCollidor(collider, compound);
            }
        }
    }
}