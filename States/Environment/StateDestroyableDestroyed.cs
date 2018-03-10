using CSE3902.Environment;
using CSE3902.Interfaces;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.Environment
{
    class StateDestroyableDestroyed : IStateInteractable
    {
        public ISprite Sprite { get; set; }
        private readonly TileDestroyable _tile;
        public StateDestroyableDestroyed(TileDestroyable tile)
        {
            _tile = tile;
            Sprite = EnvironmentSpriteFactory.Instance.CreateDestroyableBlockSprite();
            Sprite.X = (int)tile.Position.X;
            Sprite.Y = (int)tile.Position.Y;
            Sprite.Visible = false;
        }

        public void Interact()
        {
            _tile.State = new StateDestroyableUndestroyed(_tile);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite.Texture, Sprite.WorldRect, Color.White);
        }

        public void Update() { }
    }
}
