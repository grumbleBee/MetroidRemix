using CSE3902.Interfaces;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Environment
{
    class MenuBackground : StandardGameObject
    {
        private ISprite Sprite { get; }
        public MenuBackground(Vector2 pos)
        {
            Sprite = EnvironmentSpriteFactory.Instance.CreateMenuBackgroundSprite();
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