using System;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_ShapeSettings"), GenerateBindings("JPH_ConvexShapeSettings"), GenerateBindings("JPH_CylinderShapeSettings")]
    public readonly partial struct CylinderShapeSettings : IConvexShapeSettings, IDisposable
    {
        internal readonly NativeHandle<JPH_CylinderShapeSettings> Handle;

        internal CylinderShapeSettings(NativeHandle<JPH_CylinderShapeSettings> handle)
        {
            Handle = handle;
        }
        
        /// <summary>
        /// Dispose the native object.
        /// </summary>
        public void Dispose()
        {
            Destroy();
        }
    }
}
