using CSE3902.Effects;
using CSE3902.Interfaces;
using CSE3902.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CSE3902.Sprites.Sprite_Factories;

namespace CSE3902
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphics;
        public static List<IController> Controllers = new List<IController>();
        SpriteBatch spriteBatch;
        LevelLoader _levelLoader;

        private static ILevel CurrentLevel { get; set; }


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Controllers.Add(new ControllerKeyboard(this));
            Controllers.Add(new ControllerGamepad(this,0));
            Controllers.Add(new ControllerGamepad(this,1));
            Controllers.Add(new ControllerGamepad(this,2));
            Controllers.Add(new ControllerGamepad(this,3));
            spriteBatch = new SpriteBatch(GraphicsDevice);
            base.Initialize();

        }

        protected override void LoadContent()
        {
            PlayerSpriteFactory.Instance.LoadAllTextures(graphics.GraphicsDevice,Content);
            EnvironmentSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            SoundManager.Instance.LoadAllSongs(Content, @"Content/SongList.csv");
            FontManager.Instance.LoadAllFonts(Content);
            CurrentLevel = new TitleScreen();
            _levelLoader = new LevelLoader();
            CurrentLevel.LoadContent(_levelLoader);
        }

        protected override void UnloadContent()
        {
        }

        public static ILevel GetLevel()
        {
            return CurrentLevel;
        }

        public void SetLevel(ILevel level)
        {
            CurrentLevel = level;
            CurrentLevel.LoadContent(_levelLoader);
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in Controllers) controller.Update();
            CurrentLevel.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            CurrentLevel.Draw(gameTime, spriteBatch);
        }
    }
}
