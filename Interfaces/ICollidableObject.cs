using CSE3902.Util;

namespace CSE3902.Interfaces
{
    public interface ICollidableObject : IGameObject
    {
        bool OnGround { get; set; }
        bool DoCollisions { get; set; }
        bool NoOutwardCollisions { get; set; }
        WorldUtil.WorldState CollideDuringLesserState { get; set; }
    }
}
