using CSE3902.Interfaces;
using CSE3902.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902.Effects;
using CSE3902.Environment;
using CSE3902.Cameras;

namespace CSE3902.Levels
{
    internal class Menu : ILevel
    {
        public WorldUtil.WorldState CurrentWorldState{ get; set; }
        public IPhysics Physics{ get; set; }
        public IPlayer Player1Character{ get; set; }
        public IPlayer[] Players { get; set; }
        public MenuUtil.CurrentLevel SelectedLevel { get; set; }
        private readonly SpriteFont _font;
        private readonly Cursor _cursor;

        public Menu()
        {
            _font = FontManager.Instance.CreateNewDefaultFont();
            _cursor = new Cursor(new Vector2(250, 200));
            SelectedLevel = MenuUtil.CurrentLevel.Brinstar;
        }

        public void Destroy(IGameObject gameObject)
        {
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(_font, "SELECT GAME MODE", new Vector2(300, 150), Color.White);
            spriteBatch.DrawString(_font, "STANDARD", new Vector2(300, 200), Color.White);
            spriteBatch.DrawString(_font, "MULTIPLAYER", new Vector2(300, 250), Color.White);
            _cursor.Draw(spriteBatch);
            spriteBatch.End();
        }

        public void MoveUp()
        {
            if (SelectedLevel > MenuUtil.CurrentLevel.Brinstar)
            {
                SelectedLevel--;
                _cursor.Position = new Vector2(_cursor.Position.X, (_cursor.Position.Y - 50));
            }
            else
            {
                SelectedLevel = MenuUtil.CurrentLevel.TwoPlayerBrinstar;
                _cursor.Position = new Vector2(_cursor.Position.X, 250);
            }
        }

        public void MoveDown()
        {
            if (SelectedLevel < MenuUtil.CurrentLevel.TwoPlayerBrinstar)
            {
                SelectedLevel++;
                _cursor.Position = new Vector2(_cursor.Position.X, (_cursor.Position.Y + 50));
            }
            else
            {
                SelectedLevel = MenuUtil.CurrentLevel.Brinstar;
                _cursor.Position = new Vector2(_cursor.Position.X, 200);
            }
        }

        public MenuUtil.CurrentLevel GetSelectedLevel()
        {
            return SelectedLevel;
        }

        public void LoadContent(LevelLoader levelLoader)
        {
        }

        public void SetWorldState(WorldUtil.WorldState worldState)
        {
            CurrentWorldState = worldState;
        }

        public IGameObject Spawn(IGameObject gameObject, Vector2 pos)
        {
            gameObject.Position = pos;
            return gameObject;
        }

        public void Select(Game1 game)
        {
            SoundManager.Instance.PauseSong("title");
            if (SelectedLevel == MenuUtil.CurrentLevel.Brinstar)
            {
                game.SetLevel(new Brinstar());
                foreach (IController cont in Game1.Controllers)
                    cont.SwapCommandScheme();
            }
            else if (SelectedLevel == MenuUtil.CurrentLevel.TwoPlayerBrinstar)
            {
                game.SetLevel(new PlayerSelect());
            }
        }

        public void Update(GameTime gameTime)
        {
        }

        public void UpdateFrames()
        {
        }

        public void SetCamera(Camera camera)
        {

        }

        public Camera GetCamera()
        {
            return null;
        }
    }
}
