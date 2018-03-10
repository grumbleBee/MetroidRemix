using CSE3902.Effects;
using CSE3902.Players;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.SamusStates
{
    class SamusStandState : AbstractSamusState
    {
        private readonly Samus _samus;

        public SamusStandState(Samus samus)
        {
            _samus = samus;
            Sprite = PlayerSpriteFactory.Instance.CreateSamusStandSprite(samus.Id, samus.FacingRight);
            if (samus.FacingRight)
            {
                samus.BoundingBox = new Rectangle(Sprite.WorldRect.X + 4, Sprite.WorldRect.Y, 9, 32);
            }
            else
            {
                samus.BoundingBox = new Rectangle(Sprite.WorldRect.X + 7, Sprite.WorldRect.Y, 9, 32);
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

        public override void UpPress()
        {
            _samus.State = new SamusStandLookUpState(_samus);
        }

        public override void LeftPress()
        {
            _samus.FacingRight = false;
            if (!CollisionHandler.Instance.BlockedLeft(_samus.BoundingBox, 2, "Environment"))
                _samus.State = new SamusWalkState(_samus);
        }

        public override void RightPress()
        {
            _samus.FacingRight = true;
            if (!CollisionHandler.Instance.BlockedRight(_samus.BoundingBox, 2, "Environment"))
                _samus.State = new SamusWalkState(_samus);
        }

        public override void RightHold()
        {
            if (!CollisionHandler.Instance.BlockedRight(_samus.BoundingBox, 2, "Environment"))
                _samus.State = new SamusWalkState(_samus);
        }

        public override void LeftHold()
        {
            if (!CollisionHandler.Instance.BlockedLeft(_samus.BoundingBox, 2, "Environment"))
                _samus.State = new SamusWalkState(_samus);
        }

        public override void JumpPress()
        {
            _samus.State = new SamusJumpingState(_samus);
            SoundManager.Instance.PlaySong("jump");

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public override void Update()
        {
            Sprite.Update();
        }
    }
}
