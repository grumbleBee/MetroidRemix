using CSE3902.Interfaces;

namespace CSE3902.Commands.Collision
{
    internal class CommandBombEnemyCollision : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            IEnemy enemy = (IEnemy)collidedWith;
            enemy.TakeDamage();
        }
    }
}
