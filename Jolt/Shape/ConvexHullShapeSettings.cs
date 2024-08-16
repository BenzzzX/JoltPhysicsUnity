using System;
using Unity.Mathematics;
using UnityEngine;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_ShapeSettings"), GenerateBindings("JPH_ConvexShapeSettings"), GenerateBindings("JPH_ConvexHullShapeSettings")]
    public readonly partial struct ConvexHullShapeSettings : IConvexShapeSettings, IDisposable
    {
        internal readonly NativeHandle<JPH_ConvexHullShapeSettings> Handle;

        internal ConvexHullShapeSettings(NativeHandle<JPH_ConvexHullShapeSettings> handle)
        {
            Handle = handle;
        }

        [OverrideBinding("JPH_ConvexHullShapeSettings_Create")]
        public static unsafe ConvexHullShapeSettings Create(ReadOnlySpan<float3> points, float maxConvexRadius)
        {
            Debug.Assert(points.Length > 0);
            fixed(float3* pointsPtr = &points.GetPinnableReference())
            {
                return new ConvexHullShapeSettings(JPH_ConvexHullShapeSettings_Create(pointsPtr, (uint)points.Length, maxConvexRadius));
            }
        }

        public void Dispose()
        {
            Destroy();
        }
    }
}
