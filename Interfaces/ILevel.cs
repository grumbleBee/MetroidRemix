using CSE3902.Cameras;
using CSE3902.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Interfaces
{
    public interface ILevel
    {
        IPlayer[] Players { get; set; }
        IPhysics Physics { get; set; }
        WorldUtil.WorldState CurrentWorldState { get; set; }
        void LoadContent(LevelLoader levelLoader);
        void Update(GameTime gameTime);
        void Destroy(IGameObject gameObject);
        IGameObject Spawn(IGameObject gameObject, Vector2 pos);
        Camera GetCamera();
        void SetCamera(Camera camera);
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        void UpdateFrames();
        void SetWorldState(WorldUtil.WorldState worldState);
    }
}
