using CSE3902.Environment;
using CSE3902.Interfaces;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.Environment
{
    class StateDestroyableUndestroyed : IStateInteractable
    {
        private readonly TileDestroyable _tile;
        public ISprite Sprite { get; set; }

        public StateDestroyableUndestroyed(TileDestroyable tile)
        {
            _tile = tile;
            Sprite = EnvironmentSpriteFactory.Instance.CreateDestroyableBlockSprite();
            Sprite.X = (int)tile.Position.X;
            Sprite.Y = (int)tile.Position.Y;
            Sprite.Visible = true;
        }

        public void Interact()
        {
            _tile.State = new StateDestroyableDestroyed(_tile);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite.Texture, Sprite.WorldRect, Color.White);
        }

        public void Update() { }
    }
}
