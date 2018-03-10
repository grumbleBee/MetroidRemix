using CSE3902.Interfaces;

namespace CSE3902.Commands.Collision
{
    internal class CommandBombDestroyableTileCollision : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            ITileInteractable tile = (ITileInteractable)collidedWith;
            Game1.GetLevel().Destroy(tile);
        }
    }
}
