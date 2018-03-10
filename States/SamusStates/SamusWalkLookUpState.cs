using CSE3902.Effects;
using CSE3902.Players;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.SamusStates
{
    class SamusWalkLookUpState : AbstractSamusState
    {
        readonly Samus _samus;
        public SamusWalkLookUpState(Samus samus)
        {
            _samus = samus;
            Sprite = PlayerSpriteFactory.Instance.CreateSamusWalkLookUp(samus.Id, samus.FacingRight);
            if (samus.FacingRight)
            {
                Sprite.WorldRect = new Rectangle(Sprite.WorldRect.X - 6, Sprite.WorldRect.Y, Sprite.WorldRect.Width, Sprite.WorldRect.Height);
                samus.BoundingBox = new Rectangle(7, 7, 9, 31);
            }
            else
            {
                Sprite.WorldRect = new Rectangle(Sprite.WorldRect.X + 5, Sprite.WorldRect.Y, Sprite.WorldRect.Width, Sprite.WorldRect.Height);
                samus.BoundingBox = new Rectangle(4, 7, 9, 31);
            }
            Sprite.X = (int)samus.Position.X;
            Sprite.Y = (int)samus.Position.Y;
        }

        public override void DownPress()
        {
            if (_samus.HasBallForm)
                _samus.State = new SamusBallTransformState(_samus);
        }

        public override void ActionPress()
        {
            if (_samus.HasMissileUpgrade && _samus.MissilesOn && _samus.Missiles > 0)
            {
                _samus.MissileCreationUpdate();
            }
            else
            {
                _samus.BulletCreationUpdate();
            }
        }

        public override void JumpPress()
        {
            _samus.State = new SamusJumpingLookUpState(_samus);
            SoundManager.Instance.PlaySong("jump");
        }

        public override void LeftPress()
        {
            _samus.FacingRight = false;
            _samus.Position = new Vector2(_samus.Position.X, _samus.Position.Y + 6);
            _samus.State = new SamusWalkLookUpState(_samus);
        }

        public override void LeftRelease()
        {
            if (!_samus.FacingRight)
            {
                _samus.Position = new Vector2(_samus.Position.X, _samus.Position.Y + 6);
                _samus.State = new SamusStandLookUpState(_samus);
            }
        }

        public override void RightPress()
        {
            _samus.FacingRight = true;
            _samus.Position = new Vector2(_samus.Position.X, _samus.Position.Y + 6);
            _samus.State = new SamusWalkLookUpState(_samus);
        }

        public override void RightRelease()
        {
            if (_samus.FacingRight)
            {
                _samus.Position = new Vector2(_samus.Position.X, _samus.Position.Y + 6);
                _samus.State = new SamusStandLookUpState(_samus);
            }
        }

        public override void ActionRelease()
        {
            _samus.ResetBulletUpdateCounter();
        }

        public override void UpRelease()
        {
            _samus.Position = new Vector2(_samus.Position.X, _samus.Position.Y + 6);
            _samus.State = new SamusWalkState(_samus);
        }

        public override void Update()
        {
            Sprite.Update();
            if (_samus.FacingRight)
                _samus.ApplyForce(new Vector2(.5f, 0));
            else
                _samus.ApplyForce(new Vector2(-.5f, 0));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }
    }
}
