using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_Shape"), GenerateBindings("JPH_ConvexShape"), GenerateBindings("JPH_ConvexHullShape")]
    public readonly partial struct ConvexHullShape: IConvexShape
    {
        internal readonly NativeHandle<JPH_ConvexHullShape> Handle;

        internal ConvexHullShape(NativeHandle<JPH_ConvexHullShape> handle)
        {
            Handle = handle;
        }
        
        [OverrideBinding("JPH_ConvexHullShape_GetFaceVertices")]
        public unsafe void GetFaceVertices(uint faceIndex, NativeList<uint> vertices)
        {
            Bindings.JPH_ConvexHullShape_GetFaceVertices(Handle, faceIndex,(uint)vertices.Length, vertices.GetUnsafePtr());
        }
    }
}
