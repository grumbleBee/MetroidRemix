using CSE3902.Interfaces;
using CSE3902.Players;

namespace CSE3902.Commands.Collision
{
    internal class CommandBulletEnemyCollision : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            Bullet bullet = (Bullet)gameObject;
            bullet.GetSprite().Frames = 2;
            bullet.GetSprite().NextFrame();
            Game1.GetLevel().Destroy(bullet);
            IEnemy enemy = (IEnemy)collidedWith;
            enemy.TakeDamage();
            
        }
    }
}
