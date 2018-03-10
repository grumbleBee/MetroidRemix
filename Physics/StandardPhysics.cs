using CSE3902.Interfaces;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CSE3902.Physics
{
    class StandardPhysics : IPhysics
    {
        public static float Gravity { get; set; }
        public float Drag { get; set; }
        public StandardPhysics()
        {
            Gravity = 1f;
            Drag = 0.4f;
        }

        public void DoPhysics(ICollection<IPhysicsObject> gameObjects, GameTime gameTime)
        {
           foreach (IPhysicsObject gameObject in gameObjects.Where(e => !e.IsKinematic && e.Mass != 0))
            {
                gameObject.ApplyForce(new Vector2(-Drag * gameObject.Velocity.X, Gravity));
                Vector2 sumOfForces = Vector2.Zero;
                foreach (Vector2 force in gameObject.Forces)
                    sumOfForces += force;
                gameObject.Forces.Clear();

                gameObject.Acceleration = sumOfForces / gameObject.Mass;
                gameObject.Velocity += gameObject.Acceleration * gameTime.ElapsedGameTime.Milliseconds;
                CheckTerminalVelocity(gameObject);
                gameObject.Position += gameObject.Velocity;
                gameObject.Acceleration = Vector2.Zero;
            }
        }

        private static void CheckTerminalVelocity(IPhysicsObject gameObject)
        {
            if (gameObject.MaxVelocity.X != 0 && gameObject.Velocity.X > gameObject.MaxVelocity.X)
                gameObject.Velocity = new Vector2(gameObject.MaxVelocity.X, gameObject.Velocity.Y);
            else if (gameObject.MaxVelocity.X != 0 && gameObject.Velocity.X < -gameObject.MaxVelocity.X)
                gameObject.Velocity = new Vector2(-gameObject.MaxVelocity.X, gameObject.Velocity.Y);

            if (gameObject.MaxVelocity.Y != 0 && gameObject.Velocity.Y > gameObject.MaxVelocity.Y)
                gameObject.Velocity = new Vector2(gameObject.Velocity.X, gameObject.MaxVelocity.Y);
            else if (gameObject.MaxVelocity.Y != 0 && gameObject.Velocity.Y < -gameObject.MaxVelocity.Y)
                gameObject.Velocity = new Vector2(gameObject.Velocity.X, -gameObject.MaxVelocity.Y);
        }
    }
}
