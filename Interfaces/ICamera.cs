using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Interfaces
{
    public interface ICamera
    {
        Viewport Viewport { get; set; }

        Vector2 Position { get; set; }
        float Zoom { get; set; }
        Vector2 Origin { get; set; }
    }
}
