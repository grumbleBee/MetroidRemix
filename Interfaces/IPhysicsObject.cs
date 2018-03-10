using CSE3902.Util;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CSE3902.Interfaces
{
    public interface IPhysicsObject : IGameObject
    {
        Vector2 Velocity { get; set; }
        Vector2 MaxVelocity { get; set; }
        Vector2 Acceleration { get; set; }
        ICollection<Vector2> Forces { get; }
        float Mass { get; set; }
        bool IsKinematic { get; set; }
        WorldUtil.WorldState PhysicsDuringLesserState { get; set; }
        void ApplyForce(Vector2 force);
    }
}
