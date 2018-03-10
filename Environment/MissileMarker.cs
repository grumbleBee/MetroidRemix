using CSE3902.Interfaces;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Environment
{
    class MissileMarker : StandardGameObject
    {
        private ISprite Sprite { get; }
        public MissileMarker(Vector2 pos)
        {
            Sprite = EnvironmentSpriteFactory.Instance.CreateMissileMarkerSprite();
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
