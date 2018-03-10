using CSE3902.Interfaces;
using static CSE3902.Util.WorldUtil;

namespace CSE3902.Commands.Collision
{
    class CommandPlayerTransitionExitTrigger : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            Game1.GetLevel().CurrentWorldState = WorldState.Playing;
            foreach (var player1 in Game1.GetLevel().Players)
            {
                var player = (IPhysicsObject) player1;
                player.IsKinematic = false;
            }
        }
    }
}
