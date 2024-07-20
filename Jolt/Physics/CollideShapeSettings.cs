using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace Jolt
{
    /// <summary>
    /// Settings to be passed with a collision query
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct CollideShapeSettings
    {
        /// <summary>
        /// How active edges (edges that a moving object should bump into) are handled
        /// </summary>
        [FieldOffset(0x0)]
        public ActiveEdgeMode ActiveEdgeMode;
        /// <summary>
        /// If colliding faces should be collected or only the collision point
        /// </summary>
        [FieldOffset(0x1)]
        public CollectFacesMode CollectFacesMode;

        /// <summary>
        /// If objects are closer than this distance, they are considered to be colliding (used for GJK) (unit: meter)
        /// </summary>
        [FieldOffset(0x4)]
        public float CollisionTolerance;
        /// <summary>
        /// A factor that determines the accuracy of the penetration depth calculation. If the change of the squared distance is less than tolerance * current_penetration_depth^2 the algorithm will terminate. (unit: dimensionless)
        /// </summary>
        [FieldOffset(0x8)]
        public float PenetrationTolerance;

        /// <summary>
        /// When mActiveEdgeMode is CollideOnlyWithActive a movement direction can be provided. When hitting an inactive edge, the system will select the triangle normal as penetration depth only if it impedes the movement less than with the calculated penetration depth.
        /// </summary>
        [FieldOffset(0x10)]
        public float3 ActiveEdgeMovementDirection;

        /// <summary>
        /// When > 0 contacts in the vicinity of the query shape can be found. All nearest contacts that are not further away than this distance will be found (unit: meter)
        /// </summary>
        [FieldOffset(0x20)]
        public float maxSeparationDistance;
        
        /// <summary>
        /// How backfacing triangles should be treated
        /// </summary>
        [FieldOffset(0x24)]
        public BackFaceMode BackFaceMode;
        
        public static CollideShapeSettings Default => new CollideShapeSettings
        {
            ActiveEdgeMode = ActiveEdgeMode.CollideWithAll,
            CollectFacesMode = CollectFacesMode.NoFaces,
            CollisionTolerance = ShapeCastSettings.DefaultCollisionTolerance,
            PenetrationTolerance = ShapeCastSettings.DefaultCollisionTolerance,
            ActiveEdgeMovementDirection = float3.zero,
            maxSeparationDistance = 0.0f,
            BackFaceMode = BackFaceMode.IgnoreBackFaces
        };
    }
}