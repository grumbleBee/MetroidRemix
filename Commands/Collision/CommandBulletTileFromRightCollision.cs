using CSE3902.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE3902.Commands.Collision
{
    class CommandBulletTileFromRightCollision : ICommandCollision
    {
        public CommandBulletTileFromRightCollision()
        {

        }

        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            Bullet bullet = (Bullet)gameObject;
            bullet.GetSprite().NextFrame();
            Game1.GetLevel().Destroy(bullet);
            
        }
    }
}
