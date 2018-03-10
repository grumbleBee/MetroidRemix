using CSE3902.Enemies;
using CSE3902.Interfaces;

namespace CSE3902.Commands.Collision
{
    class CommandCrawlerTakeDamage : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            Crawler crawler = (Crawler)gameObject;
            crawler.TakeDamage();
        }
    }
}
