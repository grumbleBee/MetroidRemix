using CSE3902.Environment;
using CSE3902.Interfaces;
using CSE3902.States.Environment;
using CSE3902.Util;

namespace CSE3902.Commands.Collision
{
    class CommandPlayerDoorFromLeftCollision : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            TileDoor door = (TileDoor)collidedWith;
            if (!door.FacingRight && door.State is StateDoorClosed && Game1.GetLevel().CurrentWorldState == WorldUtil.WorldState.Transitioning)
            {
                door.OnInteract();
            }
            else
            {
                ICommandCollision tileCollision = new CommandPlayerTileFromLeftCollision();
                tileCollision.Execute(gameObject, collidedWith);
            }
        }
    }
}
