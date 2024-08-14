using UnityEditor;
using UnityEngine;

namespace Jolt.Integration.Editor
{
    [CustomEditor(typeof(PhysicsShapeSphere)), CanEditMultipleObjects]
    public class PhysicsShapeSphereEditor : UnityEditor.Editor
    {
        public void OnSceneGUI()
        {
            var shape = target as PhysicsShapeSphere;

            var pos = shape.transform.position;
            var rot = shape.transform.rotation;

            PhysicsShapeHandles.DrawSphereShape(pos, rot, shape);
            var parent = shape.transform.parent;
            if (parent != null)
            {
                Handles.color = Color.green;
                Handles.DrawDottedLine(pos, parent.position, 5);
            }
        }
    }
}
