using CSE3902.Interfaces;
using Microsoft.Xna.Framework;
using static CSE3902.Util.WorldUtil;

namespace CSE3902.Triggers
{
    class DoorTransitionTrigger : ICollidableObject, ITrigger
    {
        private bool _pushingPlayer;
        private readonly bool _pushingRight;
        public WorldState CollideDuringLesserState { get; set; }
        public DoorTransitionTrigger(int height, Vector2 pos, bool pushRight)
        {
            Position = pos;
            BoundingBox = new Rectangle((int)pos.X, (int)pos.Y, 16, height);
            DoCollisions = true;
            NoOutwardCollisions = true;
            UpdateDuringLesserState = WorldState.Transitioning;
            CollideDuringLesserState = WorldState.Playing;
            _pushingRight = pushRight;
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
            _pushingPlayer = true;
        }

        public void Update()
        {
            if (_pushingPlayer && Game1.GetLevel().CurrentWorldState == WorldState.Transitioning)
            {
                foreach (IPlayer player in Game1.GetLevel().Players)
                {
                    if (_pushingRight)
                        player.Position += Vector2.UnitX;
                    else
                        player.Position -= Vector2.UnitX;
                }
            }
            else if (Game1.GetLevel().CurrentWorldState == WorldState.Playing)
                _pushingPlayer = false;
        }
    }
}
