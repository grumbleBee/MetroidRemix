using CSE3902.Effects;
using CSE3902.Interfaces;
using CSE3902.Players;
using CSE3902.Power_Ups;

namespace CSE3902.Commands.Collision
{
    class CommandPlayerMissilePackCollision : ICommandCollision
    {
        readonly ILevel _currentLevel = Game1.GetLevel();
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            MissilePack missilePack = (MissilePack)gameObject;
            missilePack.Obtain();
            foreach (var player in _currentLevel.Players)
            {
                var samus = (Samus) player;
                samus.HasMissileUpgrade = true;
                samus.RefillMissiles();
            }
            //((Samus)collidedWith).HasMissileUpgrade = true;
            //((Samus)collidedWith).RefillMissiles();
            SoundManager.Instance.PlaySong("rocket_ammo");
        }
    }
}
