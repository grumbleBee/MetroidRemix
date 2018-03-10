using CSE3902.Effects;
using CSE3902.Interfaces;
using CSE3902.Players;
using CSE3902.Power_Ups;

namespace CSE3902.Commands.Collision
{
    class CommandPlayerMaruMariCollision : ICommandCollision
    {
        readonly ILevel _currentLevel = Game1.GetLevel();
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            MaruMari maruMari = (MaruMari)gameObject;
            maruMari.Obtain();
            foreach(var player in _currentLevel.Players)
            {
                var samus = (Samus) player;
                samus.HasBallForm = true;
            }
            SoundManager.Instance.PlaySong("obtainItem");
            SoundManager.Instance.PauseSong("brinstarLevel");
            Game1.GetLevel().SetWorldState(Util.WorldUtil.WorldState.Paused);

        }
    }
}
