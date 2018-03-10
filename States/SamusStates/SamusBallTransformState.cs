using CSE3902.Effects;
using CSE3902.Players;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.SamusStates
{
    class SamusBallTransformState : AbstractSamusState
    {
        readonly Samus _samus;

        int _framesDone;
        readonly int _totalFrames;

        public SamusBallTransformState(Samus samus)
        {
            _samus = samus;
            _framesDone = 0;
            _totalFrames = 4;
            Sprite = PlayerSpriteFactory.Instance.CreateSamusTransformSprite(samus.Id, samus.FacingRight);
            Sprite.X = (int)samus.Position.X;
            Sprite.Y = (int)samus.Position.Y;
            SoundManager.Instance.PlaySong("samus_morphball");

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
            _framesDone++;
            if (_framesDone > _totalFrames)
            {
                _samus.State = new SamusBallState(_samus);
            }
        }

        public override void LeftPress()
        {
            _samus.FacingRight = false;
        }

        public override void RightPress()
        {
            _samus.FacingRight = true;
        }

        public override void Update()
        {
            Sprite.Update();
        }
    }
}
