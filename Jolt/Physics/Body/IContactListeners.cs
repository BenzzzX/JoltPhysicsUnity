namespace Jolt
{
    public interface IContactListener
    {
        public ValidateResult OnContactValidate();

        public void OnContactAdded(Body bodyA, Body bodyB, ContactSettings settings);
        public void OnContactPersisted(Body bodyA, Body bodyB, ContactSettings settings);
        public void OnContactRemoved();
    }
}
