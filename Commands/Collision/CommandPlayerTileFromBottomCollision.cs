using CSE3902.Interfaces;
using CSE3902.Players;
using Microsoft.Xna.Framework;

namespace CSE3902.Commands.Collision
{
    class CommandPlayerTileFromBottomCollision : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            Samus samus = (Samus)gameObject;
            samus.BonkBlock();
            while (gameObject.BoundingBox.Intersects(collidedWith.BoundingBox))
                samus.Position = new Vector2(samus.Position.X, samus.Position.Y + 1);
        }
    }
}
