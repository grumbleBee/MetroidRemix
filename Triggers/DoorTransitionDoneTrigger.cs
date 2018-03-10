using CSE3902.Interfaces;
using Microsoft.Xna.Framework;
using static CSE3902.Util.WorldUtil;

namespace CSE3902.Triggers
{
    class DoorTransitionDoneTrigger : ICollidableObject, ITrigger
    {
        public WorldState CollideDuringLesserState { get; set; }
        public DoorTransitionDoneTrigger(int height, Vector2 pos)
        {
            Position = pos;
            BoundingBox = new Rectangle((int)pos.X, (int)pos.Y, 16, height);
            DoCollisions = true;
            NoOutwardCollisions = true;
            UpdateDuringLesserState = WorldState.Playing;
            CollideDuringLesserState = WorldState.Transitioning;
        }

        public Rectangle BoundingBox { get; set; }

        public bool DoCollisions { get; set; }

        public bool NoOutwardCollisions { get; set; }

        public bool OnGround { get; set; }

        public Vector2 Position { get; set; }

        public Vector2 PositionOld { get; set; }

        public WorldState UpdateDuringLesserState { get; set; }

        public void ActivateTrigger()
        {

        }

        public void Update()
        {

        }
    }
}
