using CSE3902.Enemies;
using CSE3902.Interfaces;
using Microsoft.Xna.Framework;

namespace CSE3902.Commands.Collision
{
    class CommandRipperTileFromRightCollision : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            Ripper ripper = (Ripper)gameObject;
            ripper.Move();
            while (gameObject.BoundingBox.Intersects(collidedWith.BoundingBox))
            {
                ripper.Position = new Vector2(ripper.Position.X + 1, ripper.Position.Y);
            }
        }
    }
}
