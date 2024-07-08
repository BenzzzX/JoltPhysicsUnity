using Unity.Mathematics;
using UnityEditor;

namespace Jolt.Samples.Editor
{
    [CustomEditor(typeof(PhysicsConstraintSwingTwist)), CanEditMultipleObjects]
    public class PhysicsConstraintSwingTwistEditor : UnityEditor.Editor
    {
        public void OnSceneGUI()
        {
            var constraint = target as PhysicsConstraintSwingTwist;
            if (constraint == null)
                return;
            PhysicsShapeHandles.StartHandle(constraint.Position1, quaternion.LookRotation(constraint.TwistAxis1, math.cross(constraint.TwistAxis1, constraint.PlaneAxis1)));
            // Draw the hinge axis
            Handles.DrawLine(float3.zero, math.forward() * 2, 10f);
            // Draw limit arc
            Handles.DrawSolidArc(float3.zero, math.right(), math.rotate(quaternion.Euler(math.radians(-constraint.NormalHalfConeAngle), 0, 0), math.forward()), constraint.NormalHalfConeAngle * 2, 1);
            Handles.DrawSolidArc(float3.zero, math.up(), math.rotate(quaternion.Euler(0, math.radians(-constraint.PlaneHalfConeAngle), 0), math.forward()), constraint.PlaneHalfConeAngle * 2, 1);
            Handles.DrawSolidArc(float3.zero, math.forward(), math.rotate(quaternion.Euler(0, 0, math.radians(constraint.TwistMinAngle)), math.up()), constraint.TwistMaxAngle - constraint.TwistMinAngle, 1);
            PhysicsShapeHandles.ResetHandle();
        }
    }
}
