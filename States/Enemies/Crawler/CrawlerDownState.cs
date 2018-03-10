using CSE3902.Interfaces;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.Enemies.Crawler
{
    class CrawlerDownState : ICrawlerState
    {
        readonly CSE3902.Enemies.Crawler _crawler;
        public ISprite Sprite { get; set; }
        private readonly Vector2 _velocity;
        public CrawlerDownState(CSE3902.Enemies.Crawler crawler)
        {
            _crawler = crawler;
            Sprite = EnemySpriteFactory.Instance.CreateCrawlerDownSprite();
            _velocity = new Vector2(-1, 0);
            crawler.BoundingBox = new Rectangle(0, 3, 18, 12);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public void Update()
        {
            if (_crawler.Clockwise)
            {
                _crawler.Position += _velocity;
            }
            else
            {
                _crawler.Position -= _velocity;
            }

            if (!CollisionHandler.Instance.BlockedAbove(_crawler.BoundingBox, 5, "Environment"))
            {
                Move();
            }
        }

        public void TurnRed()
        {
            Sprite = EnemySpriteFactory.Instance.CreateCrawlerDownRedSprite();
        }

        public void Move()
        {
            Vector2 offset = new Vector2(-3, 1);
            if (_crawler.Clockwise)
            {
                if (CollisionHandler.Instance.BlockedAbove(_crawler.BoundingBox, 5, "Environment"))
                {
                    _crawler.State = new CrawlerRightState(_crawler);
                }
                else
                {
                    _crawler.State = new CrawlerLeftState(_crawler);
                    _crawler.Position -= offset;
                }
            } else
            {
                if (CollisionHandler.Instance.BlockedAbove(_crawler.BoundingBox, 5, "Environment"))
                {
                    _crawler.State = new CrawlerLeftState(_crawler);
                }
                else
                {
                    _crawler.State = new CrawlerRightState(_crawler);
                    _crawler.Position -= offset;
                }
            }
        }
    }
}

