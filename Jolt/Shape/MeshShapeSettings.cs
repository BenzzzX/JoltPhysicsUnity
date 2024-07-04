using System;
using Unity.Mathematics;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_ShapeSettings"), GenerateBindings("JPH_MeshShapeSettings")]
    public readonly partial struct MeshShapeSettings : IShapeSettings, IDisposable
    {
        internal readonly NativeHandle<JPH_MeshShapeSettings> Handle;

        internal MeshShapeSettings(NativeHandle<JPH_MeshShapeSettings> handle)
        {
            Handle = handle;
        }

        /// <summary>
        /// Allocate a new native MeshShapeSettings and return the handle.
        /// </summary>
        [OverrideBinding("JPH_MeshShapeSettings_Create")]
        public static unsafe MeshShapeSettings Create(ReadOnlySpan<Triangle> triangles)
        {
            fixed(Triangle* trianglesPtr = &triangles.GetPinnableReference())
            {
                return new MeshShapeSettings(JPH_MeshShapeSettings_Create(trianglesPtr, (uint)triangles.Length));
            }
        }

        /// <summary>
        /// Allocate a new native MeshShapeSettings and return the handle.
        /// </summary>
        [OverrideBinding("JPH_MeshShapeSettings_Create2")]
        public static unsafe MeshShapeSettings Create(ReadOnlySpan<float3> vertices, ReadOnlySpan<IndexedTriangle> triangles)
        {
            fixed(float3* verticesPtr = &vertices.GetPinnableReference())
            fixed(IndexedTriangle* trianglesPtr = &triangles.GetPinnableReference())
            {
                return new MeshShapeSettings(JPH_MeshShapeSettings_Create2(verticesPtr, (uint)vertices.Length, trianglesPtr, (uint)triangles.Length));
            }
        }

        /// <summary>
        /// Allocate a new native MeshShape from these settings and return the handle.
        /// </summary>
        [OverrideBinding("JPH_MeshShapeSettings_CreateShape")]
        public MeshShape CreateShape()
        {
            return new MeshShape(JPH_MeshShapeSettings_CreateShape(Handle));
        }

        public void Dispose()
        {
            Destroy();
        }
    }
}
