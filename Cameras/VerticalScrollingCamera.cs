using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Cameras
{
    internal class VerticalScrollingCamera: Camera
    {
        public VerticalScrollingCamera(Viewport viewport) : base(viewport)
        {
        }

        override
        public void Update()
        {
            while (Focus.Position.Y <= CameraCenterPoint.Y - DampingDistance && !LockedUp)
                DoTransform(-Vector2.UnitY);
            while (Focus.Position.Y >= CameraCenterPoint.Y + DampingDistance && !LockedDown)
                DoTransform(Vector2.UnitY);
            base.Update();
        }
    }
}
