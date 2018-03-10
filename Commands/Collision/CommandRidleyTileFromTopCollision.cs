using CSE3902.Enemies;
using CSE3902.Interfaces;
using CSE3902.States.Enemies.Ridley;

namespace CSE3902.Commands.Collision
{
    class CommandRidleyTileFromTopCollision : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            Ridley ridley = (Ridley)gameObject;
            if (ridley.JumpDirectionProp.Equals(Ridley.JumpDirection.Down))
            {
                ridley.State = new RidleyStandingState(ridley);
                ridley.JumpDirectionProp = Ridley.JumpDirection.Up;
            }
            
            
        }
    }
}
