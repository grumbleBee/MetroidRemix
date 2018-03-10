using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Interfaces
{
    public interface IVisibleObject : IGameObject
    {
        void Draw(SpriteBatch spriteBatch);
        ISprite GetSprite();
    }
}
