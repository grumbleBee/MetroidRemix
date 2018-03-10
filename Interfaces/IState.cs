using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Interfaces
{
    public interface IState
    {
        ISprite Sprite { get; set; }
        void Draw(SpriteBatch spriteBatch);
        void Update();
    }
}
