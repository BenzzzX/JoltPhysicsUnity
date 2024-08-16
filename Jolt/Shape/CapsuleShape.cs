﻿using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_Shape"), GenerateBindings("JPH_ConvexShape"), GenerateBindings("JPH_CapsuleShape")]
    public readonly partial struct CapsuleShape: IConvexShape
    {
        internal readonly NativeHandle<JPH_CapsuleShape> Handle;

        internal CapsuleShape(NativeHandle<JPH_CapsuleShape> handle)
        {
            Handle = handle;
        }
    }
}
