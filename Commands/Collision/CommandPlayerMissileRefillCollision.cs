using CSE3902.Interfaces;
using CSE3902.Players;
using CSE3902.Power_Ups;

namespace CSE3902.Commands.Collision
{
    class CommandPlayerMissileRefillCollision : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            MissileRefill missleRefill = (MissileRefill)gameObject;
            missleRefill.Obtain();
            Samus samus = (Samus)collidedWith;
            samus.RefillMissiles();
        }
    }
}
