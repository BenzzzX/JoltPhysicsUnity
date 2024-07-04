using UnityEngine;

namespace Jolt.Samples
{
    public class PhysicsShapeCompound : MonoBehaviour, IPhysicsShapeComponent
    {
        public bool Mutable;

        public ShapeSettings ShapeSettings
        {
            get
            {
                CompoundShapeSettings settings;

                if (Mutable)
                {
                    settings = MutableCompoundShapeSettings.Create();
                }
                else
                {
                    settings = StaticCompoundShapeSettings.Create();
                }

                // Very simple single depth compound collider creation. Not intended for robust use.

                for (var i = 0; i < transform.childCount; i++)
                {
                    var child = transform.GetChild(i);

                    var childBody = child.GetComponent<IPhysicsShapeComponent>();
                    if (childBody == null) continue;
                    var s = childBody.ShapeSettings;
                    settings.AddShape(child.localPosition, child.localRotation, s);
                }

                return settings;
            }
        }

    }
}
