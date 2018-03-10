using CSE3902.Environment;
using CSE3902.Interfaces;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.Environment
{
    class StateDoorClosed : IStateInteractable
    {
        private readonly TileDoor _tile;
        public ISprite Sprite { get; set; }
        public StateDoorClosed(TileDoor tile)
        {
            _tile = tile;
            tile.DoCollisions = true;
            Sprite = EnvironmentSpriteFactory.Instance.CreateDoorSprite(false);
            Sprite.X = (int)tile.Position.X;
            Sprite.Y = (int)tile.Position.Y;
            Sprite.FacingRight = tile.FacingRight;
        }

        public void Interact()
        {
            _tile.State = new StateDoorOpen(_tile);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public void Update()
        {

        }
    }
}
