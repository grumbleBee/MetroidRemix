using CSE3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902.Effects;
using CSE3902.Environment;
using CSE3902.Util;
using CSE3902.Cameras;
using System;

namespace CSE3902.Levels
{
    internal class TitleScreen : ILevel
    {
        public IPhysics Physics { get; set; }

        public IPlayer Player1Character { get; set; }
        public IPlayer[] Players { get; set; }

        public WorldUtil.WorldState CurrentWorldState { get; set; }

        private readonly SpriteFont _font;
        private readonly MenuTitle _title;
        private readonly MenuBackground _background;

        public TitleScreen()
        {
            SoundManager.Instance.PlaySong("title");
            _title = new MenuTitle(new Vector2(180, 100));
            _background = new MenuBackground(new Vector2(0,0));
            _font = FontManager.Instance.CreateNewDefaultFont();
        }

        public void Destroy(IGameObject gameObject)
        {
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            _background.Draw(spriteBatch);
            _title.Draw(spriteBatch);
            spriteBatch.DrawString(_font, "PRESS SPACE", new Vector2(320, 250), Color.White);
            spriteBatch.End();
        }

        public void LoadContent(LevelLoader levelLoader)
        {

        }

        public IGameObject Spawn(IGameObject gameObject, Vector2 pos)
        {
            gameObject.Position = pos;
            return gameObject;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void UpdateFrames()
        {

        }

        public void SetWorldState(WorldUtil.WorldState worldState)
        {
            CurrentWorldState = worldState;
        }

        public void SetCamera(Camera camera)
        {

        }

        public Camera GetCamera()
        {
            return null;
        }

        public MenuUtil.CurrentLevel GetSelectedLevel()
        {
            throw new NotImplementedException();
        }
    }
}
