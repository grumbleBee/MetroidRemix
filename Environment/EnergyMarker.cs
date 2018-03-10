using CSE3902.Interfaces;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Environment
{
    class EnergyMarker : StandardGameObject
    {
        private ISprite Sprite { get; }
        public EnergyMarker(Vector2 pos)
        {
            Sprite = EnvironmentSpriteFactory.Instance.CreateEnergyMarkerSprite();
            Sprite.LayerOrder = 0f;
            Position = pos;
        }

        public override ISprite GetSprite()
        {
            return Sprite;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }
    }
}
