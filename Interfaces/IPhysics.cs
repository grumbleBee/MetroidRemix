using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CSE3902.Interfaces
{
    public interface IPhysics
    {
        void DoPhysics(ICollection<IPhysicsObject> gameObjects, GameTime gameTime);
    }
}
