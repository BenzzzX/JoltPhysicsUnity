﻿using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct ObjectVsBroadPhaseLayerFilterTable : IEquatable<ObjectVsBroadPhaseLayerFilterTable>
    {
        #region IEquatable
        
        public bool Equals(ObjectVsBroadPhaseLayerFilterTable other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is ObjectVsBroadPhaseLayerFilterTable other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(ObjectVsBroadPhaseLayerFilterTable lhs, ObjectVsBroadPhaseLayerFilterTable rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(ObjectVsBroadPhaseLayerFilterTable lhs, ObjectVsBroadPhaseLayerFilterTable rhs) => !lhs.Equals(rhs);
        
        #endregion
        
    }
}
