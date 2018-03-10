using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Cameras
{
    internal class HorizontalScrollingCamera : Camera
    {
        public HorizontalScrollingCamera(Viewport viewport) : base(viewport)
        {

        }

        override
        public void Update()
        {
            while (Focus.Position.X <= CameraCenterPoint.X - DampingDistance && !LockedLeft)
                DoTransform(-Vector2.UnitX);
            while (Focus.Position.X >= CameraCenterPoint.X + DampingDistance && !LockedRight)
                DoTransform(Vector2.UnitX);
            base.Update();
        }
    }



}
