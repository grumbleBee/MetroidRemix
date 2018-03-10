using CSE3902.Interfaces;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.Enemies.Crawler
{
    class CrawlerRightState : ICrawlerState
    {
        readonly CSE3902.Enemies.Crawler _crawler;
        public ISprite Sprite { get; set; }
        private readonly Vector2 _velocity;
        public CrawlerRightState(CSE3902.Enemies.Crawler crawler)
        {
            _crawler = crawler;
            Sprite = EnemySpriteFactory.Instance.CreateCrawlerRightSprite();
            _velocity = new Vector2(0, 1);
            crawler.BoundingBox = new Rectangle(3, 0, 12, 18);
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

            if (!CollisionHandler.Instance.BlockedLeft(_crawler.BoundingBox, 5, "Environment"))
            {
                Move();
            }
        }
        public void TurnRed()
        {
            Sprite = EnemySpriteFactory.Instance.CreateCrawlerRightRedSprite();
        }

        public void Move()
        {
            Vector2 offset = new Vector2(1, 1);
            if (_crawler.Clockwise)
            {
                if (CollisionHandler.Instance.BlockedLeft(_crawler.BoundingBox, 5, "Environment"))
                {
                    _crawler.State = new CrawlerUpState(_crawler);
                    _crawler.Position += new Vector2(2, 0);
                }
                else
                {
                    _crawler.State = new CrawlerDownState(_crawler);
                    _crawler.Position -= offset;
                }
            } else
            {
                if (CollisionHandler.Instance.BlockedLeft(_crawler.BoundingBox, 5, "Environment"))
                {
                    _crawler.State = new CrawlerDownState(_crawler);
                    _crawler.Position += new Vector2(2, 0);
                }
                else
                {
                    _crawler.State = new CrawlerUpState(_crawler);
                    _crawler.Position -= offset;
                }
            }
        }
    }
}
