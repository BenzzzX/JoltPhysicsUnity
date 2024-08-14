using UnityEditor;
using UnityEngine;

namespace Jolt.Integration.Editor
{
    [CustomEditor(typeof(PhysicsShapeCapsule)), CanEditMultipleObjects]
    public class PhysicsShapeCapsuleEditor : UnityEditor.Editor
    {
        public void OnSceneGUI()
        {
            var shape = target as PhysicsShapeCapsule;

            var pos = shape.transform.position;
            var rot = shape.transform.rotation;

            PhysicsShapeHandles.DrawCapsuleShape(pos, rot, shape);
            // draw parent position
            var parent = shape.transform.parent;
            if (parent != null)
            {
                Handles.color = Color.green;
                Handles.DrawDottedLine(pos, parent.position, 5);
            }
        }
    }
}
