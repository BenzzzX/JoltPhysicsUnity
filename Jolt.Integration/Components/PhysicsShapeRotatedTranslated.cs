using Unity.Mathematics;
using UnityEngine;

namespace Jolt.Integration
{
    [RequireComponent(typeof(PhysicsBody))]
    public class PhysicsShapeRotatedTranslated : MonoBehaviour, IPhysicsShapeComponent
    {
        public ShapeSettings ShapeSettings
        {
            get
            {
                IPhysicsShapeComponent childBody = null;
                float3 translation = float3.zero;
                quaternion rotation = quaternion.identity;
                for (var i = 0; i < transform.childCount; i++)
                {
                    var child = transform.GetChild(i);

                    childBody = child.GetComponent<IPhysicsShapeComponent>();
                    if (childBody != null && child.GetComponent<PhysicsBody>() == null)
                    {
                        translation = child.localPosition;
                        rotation = child.localRotation;
                        break;
                    }
                }
                Debug.Assert(childBody != null);
                var s = childBody.ShapeSettings;
                return RotatedTranslatedShapeSettings.Create(translation, rotation, s);
            }
        }
    }
}
