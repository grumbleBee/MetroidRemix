using CSE3902.Players;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.SamusStates
{
    class SamusBallState:AbstractSamusState
    {
        readonly Samus _samus;

        public SamusBallState(Samus samus)
        {
            _samus = samus;
            Sprite = PlayerSpriteFactory.Instance.CreateSamusBallSprite(samus.Id, samus.FacingRight);
            Sprite.WorldRect = new Rectangle(Sprite.WorldRect.X + 2, Sprite.WorldRect.Y, Sprite.WorldRect.Width, Sprite.WorldRect.Height);
            samus.BoundingBox = new Rectangle(Sprite.WorldRect.X, Sprite.WorldRect.Y, 11, 12);
        }

        public override void UpPress()
        {
            if (!CollisionHandler.Instance.BlockedAbove(_samus.BoundingBox, 8))
            {
                _samus.Position = new Vector2(_samus.Position.X, _samus.Position.Y - 20);
                _samus.State = new SamusStandLookUpState(_samus);
            }
        }

        public override void LeftPress()
        {
            _samus.FacingRight = false;
            _samus.State = new SamusBallState(_samus);
        }

        public override void RightPress()
        {
            _samus.FacingRight = true;
            _samus.State = new SamusBallState(_samus);
        }

        public override void JumpPress()
        {
            if (!CollisionHandler.Instance.BlockedAbove(_samus.BoundingBox, 8))
            {
                _samus.Position = new Vector2(_samus.Position.X, _samus.Position.Y - 20);
                _samus.State = new SamusStandState(_samus);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public override void ActionPress()
        {
            if (_samus.HasBombs)
            {
                _samus.CreateBomb();
            }
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
    }
}
