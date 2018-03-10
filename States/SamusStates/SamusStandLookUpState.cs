using CSE3902.Effects;
using CSE3902.Players;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.SamusStates
{
    class SamusStandLookUpState : AbstractSamusState
    {
        readonly Samus _samus;
        public SamusStandLookUpState(Samus samus)
        {
            _samus = samus;
            Sprite = PlayerSpriteFactory.Instance.CreateSamusStandLookUpSprite(samus.Id, samus.FacingRight);
            if (samus.FacingRight)
            {
                samus.Position = new Vector2(samus.Position.X, samus.Position.Y - 6);
                samus.BoundingBox = new Rectangle(5, 7, 9, 31);
            }
            else
            {
                samus.Position = new Vector2(samus.Position.X, samus.Position.Y - 6);
                samus.BoundingBox = new Rectangle(6, 7, 9, 31);
            }
            Sprite.X = (int)samus.Position.X;
            Sprite.Y = (int)samus.Position.Y;
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

        public override void ActionHold()
        {
            if (_samus.MissilesOn && _samus.Missiles > 0)
            {
                _samus.MissileCreationUpdate();
            }
            else
            {
                _samus.BulletCreationUpdate();
            }
        }

        public override void ActionRelease()
        {
            _samus.ResetBulletUpdateCounter();
        }

        public override void DownPress()
        {
            if (_samus.HasBallForm)
                _samus.State = new SamusBallTransformState(_samus);
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

        public override void RightPress()
        {
            _samus.FacingRight = true;
            _samus.Position = new Vector2(_samus.Position.X, _samus.Position.Y + 6);
            _samus.State = new SamusWalkLookUpState(_samus);
        }

        public override void UpRelease()
        {
            _samus.Position = new Vector2(_samus.Position.X, _samus.Position.Y + 6);
            _samus.State = new SamusStandState(_samus);
        }

        public override void Update()
        {
            Sprite.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }
    }
}
