using CSE3902.Interfaces;

namespace CSE3902.Commands.Collision
{
    class CommandPlayerDoorFromUpCollision : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            ICommandCollision tileCollision = new CommandPlayerTileFromTopCollision();
            tileCollision.Execute(gameObject, collidedWith);
        }
    }
}
