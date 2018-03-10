using CSE3902.Interfaces;
using CSE3902.Players;
using Microsoft.Xna.Framework;

namespace CSE3902.Commands.Collision
{
    public class CommandSamusSamusCollision : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            Vector2 knockbackVector = gameObject.Position - collidedWith.Position;
            knockbackVector.Normalize();
            ((Samus)gameObject).ApplyForce(knockbackVector);
        }
    }
}