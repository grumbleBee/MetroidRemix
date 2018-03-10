using CSE3902.Effects;
using CSE3902.Interfaces;

namespace CSE3902.Commands.Collision
{
    internal class CommandBulletDoorCollision : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            ITileInteractable door = (ITileInteractable)collidedWith;
            door.OnInteract();
            Game1.GetLevel().Destroy(gameObject);
            SoundManager.Instance.PlaySong("door");
        }
    }
}
