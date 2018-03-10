using CSE3902.Cameras;
using CSE3902.Interfaces;
using CSE3902.Util;
using Microsoft.Xna.Framework;

namespace CSE3902.Triggers
{
    class CameraFocusTrigger : ICollidableObject, ITrigger
    {
        public WorldUtil.WorldState CollideDuringLesserState { get; set; }
        private readonly string _cameraType;
        private readonly bool _rightTransition;
        public CameraFocusTrigger(int width, int height, Vector2 pos, string cameraType, bool rightTransition)
        {
            Position = pos;
            BoundingBox = new Rectangle((int)pos.X, (int)pos.Y, width, height);
            DoCollisions = true;
            NoOutwardCollisions = true;
            _rightTransition = rightTransition;
            _cameraType = cameraType;
            CollideDuringLesserState = WorldUtil.WorldState.Transitioning;
            UpdateDuringLesserState = WorldUtil.WorldState.Transitioning;
        }

        public Rectangle BoundingBox { get; set; }

        public bool DoCollisions { get; set; }

        public bool NoOutwardCollisions { get; set; }

        public bool OnGround { get; set; }

        public Vector2 Position { get; set; }

        public Vector2 PositionOld { get; set; }

        public WorldUtil.WorldState UpdateDuringLesserState { get; set; }

        public void ActivateTrigger()
        {
            Camera oldCamera = Game1.GetLevel().GetCamera();
            if (oldCamera.Transitioning) return;
            Camera newCamera;
            Vector2 newPosition;
            if (_rightTransition)
                newPosition = new Vector2(oldCamera.CameraPosition.X + 320, oldCamera.CameraPosition.Y);
            else
                newPosition = new Vector2(oldCamera.CameraPosition.X - 320, oldCamera.CameraPosition.Y);



            if (_cameraType.Equals("horizontal"))
                newCamera = new HorizontalScrollingCamera(oldCamera.Viewport);
            else if (_cameraType.Equals("vertical"))
                newCamera = new VerticalScrollingCamera(oldCamera.Viewport);
            else
                newCamera = new HorizontalScrollingCamera(oldCamera.Viewport);
            newCamera.CameraPosition = oldCamera.CameraPosition;
            newCamera.Focus = oldCamera.Focus;
            newCamera.Zoom = oldCamera.Zoom;
            newCamera.LockedLeft = true;
            newCamera.LockedRight = true;
            newCamera.DoTransition(newPosition);
            Game1.GetLevel().SetCamera(newCamera);
        }

        public void Update()
        {

        }
    }
}
