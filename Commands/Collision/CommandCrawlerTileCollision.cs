using CSE3902.Enemies;
using CSE3902.Interfaces;

namespace CSE3902.Commands.Collision
{
    class CommandCrawlerTileCollision : ICommandCollision
    {
        public void Execute(IGameObject gameObject, IGameObject collidedWith)
        {
            Crawler crawler = (Crawler)gameObject;
            crawler.Move();
        }
    }
}