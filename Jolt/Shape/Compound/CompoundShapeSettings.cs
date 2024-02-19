﻿using System;
using Unity.Mathematics;
using static Jolt.JoltAPI;

namespace Jolt
{
    public readonly struct CompoundShapeSettings : IShapeSettings, IDisposable, IEquatable<CompoundShapeSettings>
    {
        internal readonly NativeHandle<JPH_CompoundShapeSettings> Handle;

        internal CompoundShapeSettings(NativeHandle<JPH_CompoundShapeSettings> handle)
        {
            Handle = handle;
        }

        #region Reinterpreting

        public static implicit operator CompoundShapeSettings(MutableCompoundShapeSettings settings)
        {
            return new CompoundShapeSettings(settings.Handle.Reinterpret<JPH_CompoundShapeSettings>());
        }

        public static implicit operator CompoundShapeSettings(StaticCompoundShapeSettings settings)
        {
            return new CompoundShapeSettings(settings.Handle.Reinterpret<JPH_CompoundShapeSettings>());
        }

        #endregion

        #region JPH_CompoundShapeSettings

        public void AddShape(in float3 position, in quaternion rotation, ShapeSettings shape, uint userData = 0)
        {
            JPH_CompoundShapeSettings_AddShape(Handle, in position, in rotation, shape.Handle, userData);
        }

        public void AddShape(in float3 position, in quaternion rotation, Shape shape, uint userData = 0)
        {
            JPH_CompoundShapeSettings_AddShape2(Handle, in position, in rotation, shape.Handle, userData);
        }

        #endregion

        public void Dispose()
        {
            JPH_ShapeSettings_Destroy(Handle);
        }

        #region IEquatable

        public static bool operator ==(CompoundShapeSettings lhs, CompoundShapeSettings rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(CompoundShapeSettings lhs, CompoundShapeSettings rhs)
        {
            return !lhs.Equals(rhs);
        }

        public bool Equals(CompoundShapeSettings other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is CompoundShapeSettings other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #endregion
    }
}
