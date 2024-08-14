using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

namespace Jolt.Integration.Editor
{
    [CustomEditor(typeof(PhysicsConstraintSwingTwist)), CanEditMultipleObjects]
    public class PhysicsConstraintSwingTwistEditor : UnityEditor.Editor
    {
        private float3 _constraintPosition;
        private float3 _constraintPosition1;
        private float3 _constraintPosition2;
        
        private bool _bInitalized = false;
        public void OnSceneGUI()
        {
            var constraint = target as PhysicsConstraintSwingTwist;
            if (constraint == null)
                return;





      
            if (constraint.Space == ConstraintSpace.WorldSpace)
            {
                //编辑器下开始时暂停
                if (!EditorApplication.isPlaying || !_bInitalized)
                {
                    _bInitalized = true;
                    _constraintPosition = constraint.gameObject.transform.position;
                    _constraintPosition1 = constraint.Position1;
                    _constraintPosition2 = constraint.Position2;
                }
                
                PhysicsShapeHandles.ResetHandle();
                PhysicsShapeHandles.SetColor( Color.blue );
                Handles.DrawLine(_constraintPosition1, _constraintPosition2);
                
                var forward = math.normalize(_constraintPosition - _constraintPosition2);
                var up = Vector3.up;
                quaternion rotation;
                if ((_constraintPosition - _constraintPosition2).Equals(float3.zero))
                {
                    rotation = quaternion.LookRotation(constraint.PlaneAxis1, constraint.TwistAxis1);
                }
                else
                {
                    rotation = quaternion.LookRotation(constraint.PlaneAxis1, constraint.TwistAxis1) * Quaternion.LookRotation(forward, new float3(up));
                }
                PhysicsShapeHandles.StartHandle(_constraintPosition2, rotation,  new Color(0.7f, 1f, 0.5f));
                // Draw the hinge axis
                Handles.DrawLine(float3.zero, math.forward() * 2, 10f);
                // Draw limit arc
                Handles.DrawSolidArc(float3.zero, math.right(), math.rotate(quaternion.Euler(math.radians(-constraint.NormalHalfConeAngle), 0, 0), math.forward()), constraint.NormalHalfConeAngle * 2, 1);
                Handles.DrawSolidArc(float3.zero, math.up(), math.rotate(quaternion.Euler(0, math.radians(-constraint.PlaneHalfConeAngle), 0), math.forward()), constraint.PlaneHalfConeAngle * 2, 1);
                Handles.DrawSolidArc(float3.zero, math.forward(), math.rotate(quaternion.Euler(0, 0, math.radians(constraint.TwistMinAngle)), math.up()), constraint.TwistMaxAngle - constraint.TwistMinAngle, 1);
                PhysicsShapeHandles.ResetHandle();
            }
            else
            {
                var bodyPosition = new float3(constraint.gameObject.transform.position) + constraint.Position1;
                var bodyRotation = constraint.gameObject.transform.rotation * quaternion.LookRotation(constraint.TwistAxis1, math.cross(constraint.TwistAxis1, constraint.PlaneAxis1));
                PhysicsShapeHandles.StartHandle(bodyPosition, bodyRotation);
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
}
