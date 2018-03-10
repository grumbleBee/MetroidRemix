using CSE3902.Interfaces;
using CSE3902.Players;
using CSE3902.Power_Ups;

namespace CSE3902.Commands.Collision
{
    class CommandPlayerEnergyRefillCollision : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            EnergyRefill energyRefill = (EnergyRefill)gameObject;
            energyRefill.Obtain();
            Samus samus = (Samus)collidedWith;
            samus.RefillEnergy();
        }
    }
}
