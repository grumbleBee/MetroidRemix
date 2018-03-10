using CSE3902.Effects;
using CSE3902.Players;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.SamusStates
{
    class SamusWalkJumpingState:AbstractSamusState
    {
        private readonly Samus _samus;

        public SamusWalkJumpingState(Samus samus)
        {
            SoundManager.Instance.PlaySong("jump");
            _samus = samus;
            Sprite = PlayerSpriteFactory.Instance.CreateSamusWalkJumpingSprite(samus.Id, samus.FacingRight);
            if (samus.FacingRight)
            {
                Sprite.WorldRect = new Rectangle(Sprite.WorldRect.X - 6, Sprite.WorldRect.Y, Sprite.WorldRect.Width, Sprite.WorldRect.Height);
                samus.BoundingBox = new Rectangle(Sprite.WorldRect.X + 7, Sprite.WorldRect.Y, 9, 28);
            }
            else
            {
                Sprite.WorldRect = new Rectangle(Sprite.WorldRect.X + 5, Sprite.WorldRect.Y, Sprite.WorldRect.Width, Sprite.WorldRect.Height);
                samus.BoundingBox = new Rectangle(Sprite.WorldRect.X + 5, Sprite.WorldRect.Y, 9, 28);
            }
            Sprite.X = (int)samus.Position.X;
            Sprite.Y = (int)samus.Position.Y;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
           Sprite.Draw(spriteBatch);
        }

        public override void UpPress()
        {
            _samus.State = new SamusJumpingLookUpState(_samus);
        }

        public override void LeftPress()
        {
            _samus.FacingRight = false;
        }

        public override void RightPress()
        {
            _samus.FacingRight = true;
        }

        public override void ActionRelease()
        {
            _samus.ResetBulletUpdateCounter();
        }

        public override void ActionPress()
        {
            _samus.State = new SamusJumpingShootState(_samus);
        }

        public override void Update()
        {
            Sprite.Update();
            if (_samus.FacingRight)
                _samus.ApplyForce(new Vector2(.5f, 0));
            else
                _samus.ApplyForce(new Vector2(-.5f, 0));
        }

        public override void JumpRelease()
        {

        }
    }
}
