using System.Linq;
using CSE3902.Interfaces;
using CSE3902.Triggers;

namespace CSE3902.Commands.Collision
{
    class CommandPlayerFocusTriggerCollision : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            ICollidableObject trigger = (ICollidableObject)collidedWith;
            if (Game1.GetLevel().Players.Any(e => !e.BoundingBox.Intersects(trigger.BoundingBox)))
                return;
            ((CameraFocusTrigger)collidedWith).ActivateTrigger();
        }
    }
}
