﻿using CSE3902.Interfaces;
using CSE3902.Players;

namespace CSE3902.Commands.Collision
{
    class CommandMissileTileCollision : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            Missile missile = (Missile)gameObject;
            MissileExplosion missileExplosion = new MissileExplosion(missile);
            Game1.GetLevel().Spawn(missileExplosion, missileExplosion.Position);
            Game1.GetLevel().Destroy(missile);
        }
    }
}