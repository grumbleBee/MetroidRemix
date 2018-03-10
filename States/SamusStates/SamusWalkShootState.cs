using CSE3902.Players;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.SamusStates
{
    class SamusWalkShootState : AbstractSamusState
    {
        readonly Samus _samus;

        public SamusWalkShootState(Samus samus)
        {
            _samus = samus;
            Sprite = PlayerSpriteFactory.Instance.CreateSamusWalkShoot(samus.Id, samus.FacingRight);
            if (samus.FacingRight)
            {
                Sprite.WorldRect = new Rectangle(Sprite.WorldRect.X - 6, Sprite.WorldRect.Y, Sprite.WorldRect.Width, Sprite.WorldRect.Height);
            }
            samus.BoundingBox = new Rectangle(Sprite.WorldRect.X + 8, Sprite.WorldRect.Y+1, 11, 31);
            Sprite.X = (int)samus.Position.X;
            Sprite.Y = (int)samus.Position.Y;

        }

        public override void ActionRelease()
        {
            _samus.ResetBulletUpdateCounter();
            _samus.State = new SamusWalkState(_samus);

        }

        public override void DownPress()
        {
            if (_samus.HasBallForm)
                _samus.State = new SamusBallTransformState(_samus);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public override void JumpPress()
        {
        }

        public override void LeftPress()
        {
            _samus.FacingRight = false;
            _samus.State = new SamusWalkShootState(_samus);
        }

        public override void LeftRelease()
        {
            if (!_samus.FacingRight)
                _samus.State = new SamusStandState(_samus);
        }

        public override void RightPress()
        {
            _samus.FacingRight = true;
            _samus.State = new SamusWalkShootState(_samus);
        }

        public override void RightRelease()
        {
            if (_samus.FacingRight)
                _samus.State = new SamusStandState(_samus);
        }

        public override void Update()
        {
            Sprite.Update();
            if (_samus.FacingRight)
                _samus.ApplyForce(new Vector2(.5f, 0));
            else
                _samus.ApplyForce(new Vector2(-.5f, 0));
            if(_samus.HasMissileUpgrade && _samus.MissilesOn && _samus.Missiles > 0)
            {
                _samus.MissileCreationUpdate();
            }
            else
            {
                _samus.BulletCreationUpdate();
            }

        }

        public override void UpPress()
        {
            _samus.State = new SamusWalkLookUpState(_samus);
        }


    }
}
