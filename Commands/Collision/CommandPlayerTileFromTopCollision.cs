using CSE3902.Interfaces;
using CSE3902.Players;
using Microsoft.Xna.Framework;

namespace CSE3902.Commands.Collision
{
    class CommandPlayerTileFromTopCollision : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            Samus samus = (Samus)gameObject;
            samus.Velocity = new Vector2(samus.Velocity.X, 0);
            while (gameObject.BoundingBox.Intersects(collidedWith.BoundingBox))
                samus.Position = new Vector2(samus.Position.X, samus.Position.Y - 1);
            samus.BecomeGrounded();
        }
    }
}
