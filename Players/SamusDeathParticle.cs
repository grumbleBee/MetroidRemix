using CSE3902.Interfaces;
using CSE3902.Sprites.Sprite_Factories;
using CSE3902.Util;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Players
{
    class SamusDeathParticle : StandardGameObject
    {
        private readonly ISprite _sprite;
        public SamusDeathParticle()
        {
            _sprite = PlayerSpriteFactory.Instance.CreateDeathParticles();
            Mass = PlayerConstants.SamusMass;
        }

        public override ISprite GetSprite()
        {
            return _sprite;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _sprite.Draw(spriteBatch);
        }
    }
}
