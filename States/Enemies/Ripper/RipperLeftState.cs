using CSE3902.Interfaces;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.Enemies.Ripper
{
    class RipperLeftState : IRipperState
    {
        readonly CSE3902.Enemies.Ripper _ripper;
        public ISprite Sprite { get; set; }

        public RipperLeftState(CSE3902.Enemies.Ripper ripper)
        {
            _ripper = ripper;
            Sprite = EnemySpriteFactory.Instance.CreateRipperLeftSprite(true);
            Sprite.X = (int)ripper.Position.X;
            Sprite.Y = (int)ripper.Position.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public void Move()
        {
            _ripper.State = new RipperRightState(_ripper);

        }

        public void TurnRed()
        {
            Sprite = EnemySpriteFactory.Instance.CreateRipperLeftRedSprite(true);
        }

        public void Update()
        {
          
            _ripper.Position = new Vector2((_ripper.Position.X) - 1, _ripper.Position.Y);

        }
    }
}
