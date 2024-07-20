using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace Jolt
{
    /// <summary>
    /// How collision detection functions will treat back facing triangles
    /// </summary>
    public enum BackFaceMode : byte
    {
        /// <summary>
        /// Ignore collision with back facing surfaces/triangles
        /// </summary>
        IgnoreBackFaces = 0,
        
        /// <summary>
        /// Collide with back facing surfaces/triangles
        /// </summary>
        CollideWithBackFaces = 1,
    }
    
    /// <summary>
    /// 
    /// How to treat active/inactive edges.
    /// An active edge is an edge that either has no neighbouring edge or if the angle between the two connecting faces is too large, see: ActiveEdges
    /// </summary>
    public enum ActiveEdgeMode : byte
    {
        /// <summary>
        /// Do not collide with inactive edges. For physics simulation, this gives less ghost collisions.
        /// </summary>
        CollideOnlyWithActive = 0,
        
        /// <summary>
        /// Collide with all edges. Use this when you're interested in all collisions.
        /// </summary>
        CollideWithAll = 1,
    }
    
    /// <summary>
    /// Whether or not to collect faces, used by CastShape and CollideShape
    /// </summary>
    public enum CollectFacesMode : byte
    {
        /// <summary>
        /// mShape1/2Face is desired
        /// </summary>
        CollectFaces = 0,
        
        /// <summary>
        /// mShape1/2Face is not desired
        /// </summary>
        NoFaces = 1,
    }
    
    /// <summary>
    /// Settings to be passed with a shape cast
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct ShapeCastSettings
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
        /// How backfacing triangles should be treated (should we report moving out of a triangle?)
        /// </summary>
        [FieldOffset(0x20)]
        public BackFaceMode BackFaceMode;
        
        /// <summary>
        /// How backfacing convex objects should be treated (should we report starting inside an object and moving out?)
        /// </summary>
        [FieldOffset(0x21)]
        public BackFaceMode BackFaceModeConvex;
        
        /// <summary>
        /// Indicates if we want to shrink the shape by the convex radius and then expand it again. This speeds up collision detection and gives a more accurate normal at the cost of a more 'rounded' shape.
        /// </summary>
        [FieldOffset(0x22)]
        public bool UseShrunkenShapeAndConvexRadius;

        /// <summary>
        /// When true, and the shape is intersecting at the beginning of the cast (fraction = 0) then this will calculate the deepest penetration point (costing additional CPU time)
        /// </summary>
        [FieldOffset(0x23)]
        public bool ReturnDeepestPoint;
        
        public const float DefaultCollisionTolerance = 1.0e-4f;
        
        public static ShapeCastSettings Default => new ShapeCastSettings
        {
            ActiveEdgeMode = ActiveEdgeMode.CollideOnlyWithActive,
            CollectFacesMode = CollectFacesMode.NoFaces,
            CollisionTolerance = 0.001f,
            PenetrationTolerance = 0.001f,
            ActiveEdgeMovementDirection = float3.zero,
            BackFaceMode = BackFaceMode.IgnoreBackFaces,
            BackFaceModeConvex = BackFaceMode.IgnoreBackFaces,
            UseShrunkenShapeAndConvexRadius = false,
            ReturnDeepestPoint = false,
        };
    }
}