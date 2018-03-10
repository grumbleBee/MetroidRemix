using CSE3902.Interfaces;
using CSE3902.Players;
using CSE3902.Power_Ups;

namespace CSE3902.Commands.Collision
{
    class CommandPlayerBombCollision : ICommandCollision
    {
        readonly ILevel _currentLevel = Game1.GetLevel();
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            foreach (var player in _currentLevel.Players)
            {
                var samus = (Samus) player;
                samus.HasBombs = true;
            }
            //samus.HasBombs = true;
            Bomb bomb = (Bomb)collidedWith;
            bomb.Obtain();
        }
    }
}
