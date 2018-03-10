using CSE3902.Interfaces;
using CSE3902.Players;
using CSE3902.Power_Ups;

namespace CSE3902.Commands.Collision
{
    class CommandPlayerEnergyTankCollision : ICommandCollision
    {
        readonly ILevel _currentLevel = Game1.GetLevel();
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            EnergyTank energyTank = (EnergyTank)gameObject;
            foreach (var player in _currentLevel.Players)
            {
                var samus = (Samus) player;
                samus.MaxHealth += 100;
            }
            energyTank.Obtain();
            //((Samus)collidedWith).MaxHealth += 100;
        }
    }
}
