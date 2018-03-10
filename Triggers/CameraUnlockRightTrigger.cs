using CSE3902.Interfaces;
using CSE3902.Util;
using Microsoft.Xna.Framework;

namespace CSE3902.Triggers
{
    class CameraUnlockRightTrigger : ICollidableObject, ITrigger
    {
        public WorldUtil.WorldState CollideDuringLesserState { get; set; }
        public CameraUnlockRightTrigger(int height, Vector2 pos)
        {
            Position = pos;
            BoundingBox = new Rectangle((int)pos.X, (int)pos.Y, 1, height);
            DoCollisions = true;
            NoOutwardCollisions = true;
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
            Game1.GetLevel().GetCamera().LockedRight = false;
        }

        public void Update()
        {
         
        }
    }
}
