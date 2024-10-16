﻿using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_Shape"), GenerateBindings("JPH_ConvexShape"), GenerateBindings("JPH_SphereShape")]
    public readonly partial struct SphereShape : IConvexShape
    {
        internal readonly NativeHandle<JPH_SphereShape> Handle;

        internal SphereShape(NativeHandle<JPH_SphereShape> handle)
        {
            Handle = handle;
        }
    }
}
