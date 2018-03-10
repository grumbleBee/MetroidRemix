using CSE3902.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework;

namespace CSE3902.Environment
{
    class Cursor : StandardGameObject
    {
        private ISprite Sprite { get; }
        public Cursor(Vector2 pos)
        {
            Sprite = EnvironmentSpriteFactory.Instance.CreateCursorSprite();
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

        public void MoveUp()
        {
            Position = new Vector2(Position.X, Position.Y - 16);
        }

        public void MoveDown()
        {
            Position = new Vector2(Position.X, Position.Y + 16);
        }
    }
}
