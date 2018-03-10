using CSE3902.Interfaces;
using CSE3902.Players;

namespace CSE3902.Commands.Collision
{
    public class CommandSamusRidleyProjectileCollision : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            Samus samus = (Samus)gameObject;
            samus.TakeDamage(collidedWith);
            Game1.GetLevel().Destroy(collidedWith);
        }
    }
}
