using CSE3902.Interfaces;
using CSE3902.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CSE3902
{
    public abstract class StandardGameObject : IVisibleObject, IPhysicsObject, ICollidableObject
    {
        private Rectangle _boundingBox;
        private Vector2 _position;
        public Vector2 Acceleration { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 MaxVelocity { get; set; }
        public WorldUtil.WorldState UpdateDuringLesserState { get; set; }
        public WorldUtil.WorldState CollideDuringLesserState { get; set; }
        public WorldUtil.WorldState PhysicsDuringLesserState { get; set; }
        public bool IsKinematic { get; set; }
        public float Mass { get; set; }
        public bool NoOutwardCollisions { get; set; }
        public bool OnGround { get; set; }
        public ICollection<Vector2> Forces { get; } = new List<Vector2>();

        public bool DoCollisions { get; set; } = true;

        public Rectangle BoundingBox
        {
            get
            {
                if (_boundingBox.Width == 0 && _boundingBox.Height == 0)
                {
                    _boundingBox = new Rectangle(0, 0, GetSprite().Width, GetSprite().Height);
                }

                return new Rectangle((int)Position.X + _boundingBox.X, (int)Position.Y + _boundingBox.Y, _boundingBox.Width, _boundingBox.Height);

            }
            set
            {
                _boundingBox = value;
            }
        }

        public Vector2 Position
        {
            get
            {
                return _position;
            }

            set
            {
                _position = value;
                GetSprite().X = (int) value.X;
                GetSprite().Y = (int) value.Y;
            }
        }

        public Vector2 PositionOld { get; set; }

        public void ApplyForce(Vector2 force)
        {
            Forces.Add(force);
        }

        public virtual void Update() {  }

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract ISprite GetSprite();
    }
}
