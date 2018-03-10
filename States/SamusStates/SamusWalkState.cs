using CSE3902.Effects;
using CSE3902.Players;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.SamusStates
{
    class SamusWalkState : AbstractSamusState
    {
        private readonly Samus _samus;

        public SamusWalkState(Samus samus)
        {
            _samus = samus;
            Sprite = PlayerSpriteFactory.Instance.CreateSamusWalkSprite(samus.Id, samus.FacingRight);
            if (samus.FacingRight)
            {
                Sprite.WorldRect = new Rectangle(Sprite.WorldRect.X - 6, Sprite.WorldRect.Y, Sprite.WorldRect.Width, Sprite.WorldRect.Height);
                samus.BoundingBox = new Rectangle(Sprite.WorldRect.X + 10, Sprite.WorldRect.Y + 1, 9, 31);
            }
            else
            {
                Sprite.WorldRect = new Rectangle(Sprite.WorldRect.X + 5, Sprite.WorldRect.Y, Sprite.WorldRect.Width, Sprite.WorldRect.Height);
                samus.BoundingBox = new Rectangle(Sprite.WorldRect.X + 2, Sprite.WorldRect.Y + 1, 9, 31);
            }
            Sprite.X = (int)samus.Position.X;
            Sprite.Y = (int)samus.Position.Y;
        }

        public override void DownPress()
        {
            if (_samus.HasBallForm)
                _samus.State = new SamusBallTransformState(_samus);
        }

        public override void UpPress()
        {
            _samus.Position = new Vector2(_samus.Position.X, _samus.Position.Y - 6);
            _samus.State = new SamusWalkLookUpState(_samus);
        }

        public override void LeftPress()
        {
            _samus.FacingRight = false;
            _samus.State = new SamusWalkState(_samus);
        }

        public override void RightPress()
        {
            _samus.FacingRight = true;
            _samus.State = new SamusWalkState(_samus);
            
        }

        public override void ActionPress()
        {
            _samus.State = new SamusWalkShootState(_samus);
        }

        public override void ActionHold()
        {
            _samus.State = new SamusWalkShootState(_samus);
        }

        public override void JumpPress()
        {
            _samus.State = new SamusWalkJumpingState(_samus);
            SoundManager.Instance.PlaySong("jump");

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public override void Update()
        {
            Sprite.Update();
            if (_samus.FacingRight)
                _samus.ApplyForce(new Vector2(.5f, 0));
            else
                _samus.ApplyForce(new Vector2(-.5f, 0));
        }

        public override void RightRelease()
        {
            if (_samus.FacingRight)
                _samus.State = new SamusStandState(_samus);
        }

        public override void LeftRelease()
        {
            if (!_samus.FacingRight)
                _samus.State = new SamusStandState(_samus);
        }
    }
}
