namespace Jolt
{
    /// <summary>
    /// Marker interface for JPH structs that can be used as JPH_Shape pointers.
    /// </summary>
    public interface INativeShape { }

    /// <summary>
    /// Marker interface for JPH structs that can be used as JPH_ConvexShape pointers.
    /// </summary>
    public interface INativeConvexShape { }

    /// <summary>
    /// Marker interface for JPH structs that can be used as JPH_ShapeSettings pointers.
    /// </summary>
    public interface INativeShapeSettings { }

    /// <summary>
    /// Marker interface for JPH structs that can be used as JPH_ConvexShapeSettings pointers.
    /// </summary>
    public interface INativeConvexShapeSettings { }

    /// <summary>
    /// Marker interface for JPH structs that can be used as JPH_CompoundShapeSettings pointers.
    /// </summary>
    public interface INativeCompoundShapeSettings  { }

    #region Shapes

    public partial struct JPH_Shape : INativeShape { }

    public partial struct JPH_ConvexShape : INativeShape, INativeConvexShape { }

    public partial struct JPH_BoxShape : INativeShape, INativeConvexShape { }

    public partial struct JPH_SphereShape : INativeShape, INativeConvexShape { }

    public partial struct JPH_CapsuleShape : INativeShape, INativeConvexShape { }

    public partial struct JPH_CylinderShape : INativeShape, INativeConvexShape { }

    public partial struct JPH_ConvexHullShape : INativeShape, INativeConvexShape { }

    public partial struct JPH_MeshShape : INativeShape { }

    #endregion

    #region Shape Settings

    public partial struct JPH_ShapeSettings : INativeShapeSettings { }

    public partial struct JPH_ConvexShapeSettings : INativeShapeSettings, INativeConvexShapeSettings { }

    public partial struct JPH_BoxShapeSettings : INativeShapeSettings, INativeConvexShapeSettings { }

    public partial struct JPH_SphereShapeSettings : INativeShapeSettings, INativeConvexShapeSettings { }

    public partial struct JPH_CapsuleShapeSettings : INativeShapeSettings, INativeConvexShapeSettings { }

    public partial struct JPH_CylinderShapeSettings : INativeShapeSettings, INativeConvexShapeSettings { }

    public partial struct JPH_ConvexHullShapeSettings : INativeShapeSettings, INativeConvexShapeSettings { }

    public partial struct JPH_MeshShapeSettings : INativeShapeSettings { }

    public partial struct JPH_TaperedCapsuleShapeSettings : INativeShapeSettings, INativeConvexShapeSettings { }

    public partial struct JPH_CompoundShapeSettings : INativeShapeSettings, INativeCompoundShapeSettings { }

    public partial struct JPH_StaticCompoundShapeSettings : INativeShapeSettings, INativeCompoundShapeSettings { }

    public partial struct JPH_MutableCompoundShapeSettings : INativeShapeSettings, INativeCompoundShapeSettings { }

    #endregion
}
