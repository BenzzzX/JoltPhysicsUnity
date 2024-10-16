using Unity.Mathematics;

namespace Jolt
{
    public interface IContactListener
    {
        public ValidateResult OnContactValidate(Body bodyA, Body bodyB, rvec3 offset, ref JPH_CollideShapeResult result);

        public void OnContactAdded(Body bodyA, Body bodyB, ContactSettings settings);
        public void OnContactPersisted(Body bodyA, Body bodyB, ContactSettings settings);
        public void OnContactRemoved(BodyID bodyA, uint subShapeIDA, BodyID bodyB, uint subShapeIDB);
    }
}
