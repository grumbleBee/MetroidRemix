using System.Linq;
using CSE3902.Interfaces;
using CSE3902.Triggers;
using static CSE3902.Util.WorldUtil;

namespace CSE3902.Commands.Collision
{
    class CommandPlayerTransitionTrigger : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            ICollidableObject door = (ICollidableObject) collidedWith;
            if (Game1.GetLevel().CurrentWorldState >= WorldState.Transitioning || Game1.GetLevel().Players.Any(e => !e.BoundingBox.Intersects(door.BoundingBox)))
                return;
            Game1.GetLevel().CurrentWorldState = WorldState.Transitioning;
            foreach (var player1 in Game1.GetLevel().Players)
            {
                var player = (IPhysicsObject) player1;
                player.IsKinematic = true;
            }
            DoorTransitionTrigger trigger = (DoorTransitionTrigger)collidedWith;
            trigger.ActivateTrigger();
        }
    }
}
