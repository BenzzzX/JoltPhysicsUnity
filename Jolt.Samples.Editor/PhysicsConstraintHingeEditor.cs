using Unity.Mathematics;
using UnityEditor;

namespace Jolt.Samples.Editor
{
    [CustomEditor(typeof(PhysicsConstraintHinge)), CanEditMultipleObjects]
    public class PhysicsConstraintHingeEditor : UnityEditor.Editor
    {
        public void OnSceneGUI()
        {
            var constraint = target as PhysicsConstraintHinge;
            if (constraint == null)
                return;
            PhysicsShapeHandles.StartHandle(constraint.Point1, quaternion.LookRotation(constraint.NormalAxis1, math.cross(constraint.HingeAxis1, constraint.NormalAxis1)));
            // Draw the hinge axis
            Handles.DrawLine(-math.right(), math.right(), 10f);
            // Draw limit arc
            Handles.DrawSolidArc(float3.zero, math.right(), math.rotate(quaternion.Euler(math.radians(constraint.LimitsMin), 0, 0), math.forward()), constraint.LimitsMax - constraint.LimitsMin, 1);
            PhysicsShapeHandles.ResetHandle();
        }
    }
}
