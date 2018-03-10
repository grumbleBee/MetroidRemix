using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Interfaces
{
    public interface ISprite
    {
        Texture2D Texture { get; }
        int X { get; set; }
        int Y { get; set; }
        int Width { get; }
        int Height { get; }
        float LayerOrder { get; set; }
        bool Visible { get; set; }
        bool FacingRight { get; set; }
        Rectangle WorldRect { get; set; }
        Rectangle SourceRect { get; }

        int Frames { get; set; }
        int Frame { get; }

        void Update();
        void Draw(SpriteBatch spriteBatch);
        void NextFrame();
    }
}
