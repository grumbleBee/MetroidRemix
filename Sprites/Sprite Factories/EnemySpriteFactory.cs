using CSE3902.Interfaces;
using CSE3902.Sprites.Enemies.Crawler;
using CSE3902.Sprites.Enemies.Ridley;
using CSE3902.Sprites.Enemies.Ripper;
using CSE3902.Sprites.Enemies.Skree;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Sprites.Sprite_Factories
{
    class EnemySpriteFactory
    {
        private Texture2D _skree;
        private Texture2D _skreeRed;
        private Texture2D _skreeExplosion;
        private Texture2D _zoomerUp;
        private Texture2D _zoomerUpRed;
        private Texture2D _zoomerDown;
        private Texture2D _zoomerDownRed;
        private Texture2D _zoomerRight;
        private Texture2D _zoomerRightRed;
        private Texture2D _zoomerLeft;
        private Texture2D _zoomerLeftRed;
        private Texture2D _ripperRight;
        private Texture2D _ripperRightRed;
        private Texture2D _ripperLeft;
        private Texture2D _ripperLeftRed;
        private Texture2D _ridleyStanding;
        private Texture2D _ridleyStandingRed;
        private Texture2D _ridleyJumping;
        private Texture2D _ridleyJumpingRed;
        private Texture2D _ridleyProjectile;

        public static EnemySpriteFactory Instance { get; } = new EnemySpriteFactory();

        private EnemySpriteFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            _skree = content.Load<Texture2D>("Skree");
            _skreeRed = content.Load<Texture2D>("skree_Red");
            _skreeExplosion = content.Load<Texture2D>("explosion");
            _zoomerUp = content.Load<Texture2D>("zoomerUp");
            _zoomerUpRed = content.Load<Texture2D>("zoomerUp_Red");
            _zoomerDown = content.Load<Texture2D>("zoomerDown");
            _zoomerDownRed = content.Load<Texture2D>("zoomerDown_Red");
            _zoomerLeft = content.Load<Texture2D>("zoomerLeft");
            _zoomerLeftRed = content.Load<Texture2D>("zoomerLeft_Red");
            _zoomerRight = content.Load<Texture2D>("zoomerRight");
            _zoomerRightRed = content.Load<Texture2D>("zoomerRight_Red");
            _ripperLeft = content.Load<Texture2D>("ripper");
            _ripperLeftRed = content.Load<Texture2D>("ripperLeft_Red");
            _ripperRight = content.Load<Texture2D>("ripper_left");
            _ripperRightRed = content.Load<Texture2D>("ripperRight_Red");
            _ridleyJumping = content.Load<Texture2D>("ridleyJumping");
            _ridleyJumpingRed = content.Load<Texture2D>("ridleyJumpingRed");
            _ridleyStanding = content.Load<Texture2D>("ridleyStanding");
            _ridleyStandingRed = content.Load<Texture2D>("ridleyStandingRed");
            _ridleyProjectile = content.Load<Texture2D>("ridleyProjectileSheet");

        }

        public ISprite CreateSkreeHangingSprite(bool isVisible)
        {
            return new SkreeHangingSprite(_skree, 16, 24, isVisible);
        }

        public ISprite CreateSkreeHangingRedSprite(bool isVisible)
        {
            return new SkreeHangingSprite(_skreeRed, 16, 24, isVisible);
        }

        public ISprite CreateSkreeDrillingSprite()
        {
            return new SkreeDrillingSprite(_skree, 16, 24);
        }

        public ISprite CreateSkreeDrillingRedSprite()
        {
            return new SkreeDrillingSprite(_skreeRed, 16, 24);
        }

        public ISprite CreateSkreeDivingSprite(bool isVisible)
        {
            return new SkreeDivingSprite(_skree, 16, 24, isVisible);
        }

        public ISprite CreateSkreeDivingRedSprite(bool isVisible)
        {
            return new SkreeDivingSprite(_skreeRed, 16, 24, isVisible);
        }

        public ISprite CreateSkreeExplodingSprite(bool isVisible)
        {
            return new SkreeExplodingSprite(_skreeExplosion, 32, 32, isVisible);
        }

        public ISprite CreateCrawlerDownSprite()
        {
            return new CrawlerDownSprite(_zoomerDown, 18, 18);
        }

        public ISprite CreateCrawlerDownRedSprite()
        {
            return new CrawlerDownSprite(_zoomerDownRed, 18, 18);
        }

        public ISprite CreateCrawlerLeftSprite()
        {
            return new CrawlerLeftSprite(_zoomerLeft, 18, 18);
        }

        public ISprite CreateCrawlerLeftRedSprite()
        {
            return new CrawlerLeftSprite(_zoomerLeftRed, 18, 18);
        }
        public ISprite CreateCrawlerRightSprite()
        {
            return new CrawlerRightSprite(_zoomerRight, 18, 18);
        }
        public ISprite CreateCrawlerRightRedSprite()
        {
            return new CrawlerRightSprite(_zoomerRightRed, 18, 18);
        }
        public ISprite CreateCrawlerUpSprite()
        {
            return new CrawlerUpSprite(_zoomerUp, 18, 18);
        }
        public ISprite CreateCrawlerUpRedSprite()
        {
            return new CrawlerUpSprite(_zoomerUpRed, 18, 18);
        }
        public ISprite CreateRipperRightSprite(bool isVisible)
        {
            return new RipperRightSprite(_ripperRight, 16, 16, isVisible);
        }

        public ISprite CreateRipperRightRedSprite(bool isVisible)
        {
            return new RipperRightSprite(_ripperRightRed, 16, 16, isVisible);
        }

        public ISprite CreateRipperLeftSprite(bool isVisible)
        {
            return new RipperLeftSprite(_ripperLeft, 16, 16, isVisible);
        }

        public ISprite CreateRipperLeftRedSprite(bool isVisible)
        {
            return new RipperLeftSprite(_ripperLeftRed, 16, 16, isVisible);
        }

        public ISprite CreateRidleyStandingRedSprite(bool isFacingRight)
        {
            return new StandingRidleySprite(_ridleyStandingRed, 34, 48,isFacingRight);
        }

        public ISprite CreateRidleyStandingSprite(bool isFacingRight)
        {
            return new StandingRidleySprite(_ridleyStanding, 34, 48,isFacingRight);
        }

        public ISprite CreateRidleyJumpingSprite(bool isFacingRight)
        {
            return new JumpingRidleySprite(_ridleyJumping, 34, 48, isFacingRight);
        }

        public ISprite CreateRidleyJumpingRedSprite(bool isFacingRight)
        {
            return new JumpingRidleySprite(_ridleyJumpingRed, 34, 48,isFacingRight);
        }

        public ISprite CreateRidleyProjectileSprite(bool isFacingRight)
        {
            return new RidleyProjectileSprite(_ridleyProjectile, 9, 10, isFacingRight);
        }

    }
}
