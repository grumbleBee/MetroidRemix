using CSE3902.Interfaces;

namespace CSE3902.Commands.Collision
{
    class CommandPlayerDoorFromDownCollision : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            ICommandCollision tileCollision = new CommandPlayerTileFromBottomCollision();
            tileCollision.Execute(gameObject, collidedWith);
        }
    }
}
