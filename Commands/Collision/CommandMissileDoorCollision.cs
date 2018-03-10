using CSE3902.Effects;
using CSE3902.Interfaces;
using CSE3902.Players;

namespace CSE3902.Commands.Collision
{
    class CommandMissileDoorCollision : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            ITileInteractable door = (ITileInteractable)collidedWith;
            Missile missile = (Missile)gameObject;
            door.OnInteract();
            MissileExplosion missileExplosion = new MissileExplosion(missile);
            Game1.GetLevel().Spawn(missileExplosion, missileExplosion.Position);
            Game1.GetLevel().Destroy(gameObject);
            SoundManager.Instance.PlaySong("rocket_door");
        }
    }
}
