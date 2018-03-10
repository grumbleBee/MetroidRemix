using CSE3902.Players;
using Microsoft.Xna.Framework.Graphics;
using CSE3902.Sprites.Sprite_Factories;

namespace CSE3902.States.SamusStates
{
    class SamusIntroState:AbstractSamusState
    {
        Samus samus;
        public SamusIntroState(Samus samus)
        {
            this.samus = samus;
            Sprite = PlayerSpriteFactory.Instance.CreateSamusIntro(samus.Id);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public override void Update()
        {
            if (Sprite.Frame >= Sprite.Frames)
            {
                samus.UpdateDuringLesserState = Util.WorldUtil.WorldState.Transitioning;
                samus.CollideDuringLesserState = Util.WorldUtil.WorldState.Transitioning;
                Game1.GetLevel().CurrentWorldState = Util.WorldUtil.WorldState.Playing;
                samus.IsKinematic = false;
                samus.State = new SamusStandState(samus);
            }
        }
    }
}
