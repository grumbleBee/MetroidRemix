using CSE3902.Players;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.SamusStates
{
    class SamusJumpingLookUpState : AbstractSamusState
    {
        readonly Samus _samus;
        public SamusJumpingLookUpState(Samus samus)
        {
            _samus = samus;
            Sprite = PlayerSpriteFactory.Instance.CreateSamusJumpingLookUp(samus.Id, samus.FacingRight);
            if (samus.FacingRight)
                Sprite.WorldRect = new Rectangle(Sprite.WorldRect.X - 5, Sprite.WorldRect.Y, Sprite.WorldRect.Width, Sprite.WorldRect.Height);
            else
                Sprite.WorldRect = new Rectangle(Sprite.WorldRect.X + 4, Sprite.WorldRect.Y, Sprite.WorldRect.Width, Sprite.WorldRect.Height);
            samus.BoundingBox = new Rectangle(Sprite.WorldRect.X + 5, Sprite.WorldRect.Y + 6, 9, 26);
            Sprite.X = (int)samus.Position.X;
            Sprite.Y = (int)samus.Position.Y;
        }

        public override void ActionPress()
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

        public override void ActionHold()
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

        public override void ActionRelease()
        {
            _samus.ResetBulletUpdateCounter();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public override void JumpRelease()
        {
            _samus.State = new SamusStandLookUpState(_samus);
        }

        public override void LeftPress()
        {
            _samus.FacingRight = false;
            _samus.State = new SamusJumpingLookUpState(_samus);
        }

        public override void RightPress()
        {
            _samus.FacingRight = true;
            _samus.State = new SamusJumpingLookUpState(_samus);
        }

        public override void RightHold()
        {
            _samus.ApplyForce(new Vector2(0.5f, 0));
        }

        public override void LeftHold()
        {
            _samus.ApplyForce(new Vector2(-0.5f, 0));
        }

        public override void Update()
        {
            Sprite.Update();
        }

        public override void UpRelease()
        {
            _samus.State = new SamusJumpingState(_samus);
        }
    }
}
