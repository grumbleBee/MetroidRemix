using CSE3902.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CSE3902.Cameras
{
    public abstract class Camera
    {
        private Vector2 _position;
        private Vector2 _originalPos;
        private Vector2 _destination;
        private float _lerpProgress;

        protected Camera(Viewport viewport)
        {
            Viewport = viewport;
            DampingDistance = 50;
        }

        public bool LockedRight { get; set; }
        public bool LockedLeft { get; set; }
        public bool LockedUp { get; set; }
        public bool LockedDown { get; set; }

        protected Vector2 CameraCenterPoint => new Vector2(_position.X + Viewport.Width / (Zoom*2), _position.Y + Viewport.Height / (Zoom*2));

        public int InitOffset { get; set; }

        public Viewport Viewport { get; }

        public bool Transitioning { get; set; }

        public float Zoom { get; set; }

        public IGameObject Focus { get; set; }

        protected float DampingDistance { get; }

        public Vector2 CameraPosition
        {
            get
            {
                return _position;
            }

            set
            {
                _position = value;
            }
        }

        public Matrix GetViewMatrix()
        {
            return
                Matrix.CreateTranslation(new Vector3(-CameraPosition, 0.0f)) *
                Matrix.CreateTranslation(new Vector3(-Vector2.Zero, 0.0f)) *
                Matrix.CreateScale(Zoom, Zoom, 1) *
                Matrix.CreateTranslation(new Vector3(Vector2.Zero, 0.0f));
        }

        public virtual void Update()
        {
            if (Transitioning)
            {
                float lerpedX = MathHelper.Lerp(_originalPos.X, _destination.X, _lerpProgress);
                float lerpedY = MathHelper.Lerp(_originalPos.Y, _destination.Y, _lerpProgress);
                CameraPosition = new Vector2(lerpedX, lerpedY);
                _lerpProgress += 0.025f;
            }
            if ((_destination - CameraPosition).Length() < 1)
            {
                Transitioning = false;
                if (_destination.X > _originalPos.X)
                {
                    LockedRight = false;
                } else
                {
                    LockedLeft = false;
                }
            }
        }

        protected void DoTransform(Vector2 change)
        {
            if (LockedRight && change.X > 0)
                change.X = 0;
            if (LockedLeft && change.X < 0)
                change.X = 0;
            if (LockedUp && change.Y < 0)
                change.Y = 0;
            if (LockedDown && change.Y > 0)
                change.Y = 0;
            CameraPosition += change;
        }

        public bool IsRendered(IGameObject gameObject)
        {
            bool inFromLeft = gameObject.BoundingBox.Right > CameraPosition.X;
            bool inFromRight = gameObject.BoundingBox.Left < CameraPosition.X + Viewport.Width/Zoom;
            bool inFromTop = gameObject.BoundingBox.Bottom > CameraPosition.Y;
            bool inFromBottom = gameObject.BoundingBox.Top < CameraPosition.Y + Viewport.Height/Zoom;
            return inFromBottom && inFromTop && inFromLeft && inFromRight;
        }

        public bool IsRendered(IGameObject gameObject, int leniance)
        {
            bool inFromLeft = gameObject.BoundingBox.Right > CameraPosition.X - leniance;
            bool inFromRight = gameObject.BoundingBox.Left < CameraPosition.X + leniance + Viewport.Width / Zoom;
            bool inFromTop = gameObject.BoundingBox.Bottom > CameraPosition.Y - leniance;
            bool inFromBottom = gameObject.BoundingBox.Top < CameraPosition.Y + leniance + Viewport.Height / Zoom;
            return inFromBottom && inFromTop && inFromLeft && inFromRight;
        }

        public void DoTransition(Vector2 newPosition)
        {
            _originalPos = CameraPosition;
            Transitioning = true;
            _destination = newPosition;
            _lerpProgress = 0;
        }
    }


    }
