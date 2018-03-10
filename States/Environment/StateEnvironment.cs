using CSE3902.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using CSE3902.Environment;
using CSE3902.Sprites.Sprite_Factories;

namespace CSE3902.States.Environment
{
    class StateEnvironment : IState
    {
        public ISprite Sprite { get; set; }


        public StateEnvironment(TileEnvironment tile, int tileId)
        {
            Sprite = EnvironmentSpriteFactory.Instance.CreateEnvironmentalTile(tileId);
            Sprite.X = (int)tile.Position.X;
            Sprite.Y = (int)tile.Position.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public void Update()
        {
            Sprite.Update();
        }
    }
}
