using CSE3902.Environment;
using CSE3902.Interfaces;
using CSE3902.States.Environment;
using CSE3902.Util;

namespace CSE3902.Commands.Collision
{
    class CommandPlayerDoorFromRightCollision : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            TileDoor door = (TileDoor)collidedWith;
            if (door.State is StateDoorClosed && door.FacingRight && Game1.GetLevel().CurrentWorldState == WorldUtil.WorldState.Transitioning)
            {
                door.OnInteract();
            } 
            else
            {
                ICommandCollision tileCollision = new CommandPlayerTileFromRightCollision();
                tileCollision.Execute(gameObject, collidedWith);
            }
        }
    }
}
