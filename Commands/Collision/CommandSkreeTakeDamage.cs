using CSE3902.Enemies;
using CSE3902.Interfaces;

namespace CSE3902.Commands.Collision
{
    class CommandSkreeTakeDamage : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            Skree skree = (Skree)gameObject;
            skree.TakeDamage();
        }
    }
}
