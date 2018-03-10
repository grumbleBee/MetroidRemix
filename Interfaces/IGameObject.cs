using CSE3902.Util;
using Microsoft.Xna.Framework;

namespace CSE3902.Interfaces
{
    public interface IGameObject
    {
        Rectangle BoundingBox { get; set; }
        Vector2 Position { get; set; }
        Vector2 PositionOld { get; set; }
        WorldUtil.WorldState UpdateDuringLesserState { get; set; }
        void Update();
    }
}
