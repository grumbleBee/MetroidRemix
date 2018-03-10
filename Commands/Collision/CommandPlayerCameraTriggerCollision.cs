using CSE3902.Interfaces;

namespace CSE3902.Commands.Collision
{
    class CommandPlayerCameraTriggerCollision : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            if (gameObject == Game1.GetLevel().GetCamera().Focus)
                ((ITrigger)collidedWith).ActivateTrigger();
        }
    }
}
