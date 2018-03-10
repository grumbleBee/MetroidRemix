using CSE3902.Interfaces;

namespace CSE3902.Commands.Collision
{
    public class CommandRidleyProjectileTileCollision : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            Game1.GetLevel().Destroy(gameObject);
        }
    }
}
