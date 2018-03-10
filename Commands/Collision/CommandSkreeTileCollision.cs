using CSE3902.Enemies;
using CSE3902.Interfaces;

namespace CSE3902.Commands.Collision
{
    class CommandSkreeTileCollision : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            Skree skree = (Skree)gameObject;
            skree.Move();
        }
    }
}
