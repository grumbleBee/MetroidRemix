using CSE3902.Interfaces;
using CSE3902.Players;
using Microsoft.Xna.Framework;

namespace CSE3902.Commands.Collision
{
    class CommandPlayerTileFromRightCollision : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            if (CollisionHandler.Instance.BlockedRight(collidedWith.BoundingBox, 1, "Environment"))
            {
                if (CollisionHandler.Instance.BlockedAbove(collidedWith.BoundingBox,1,"Player"))
                    new CommandPlayerTileFromTopCollision().Execute(gameObject, collidedWith);
                else
                    new CommandPlayerTileFromBottomCollision().Execute(gameObject, collidedWith);
                return;
            }
            Samus samus = (Samus)gameObject;
            samus.State.LeftRelease();
            while (gameObject.BoundingBox.Intersects(collidedWith.BoundingBox))
                samus.Position = new Vector2(samus.Position.X + 1, samus.Position.Y);
        }
    }
}
