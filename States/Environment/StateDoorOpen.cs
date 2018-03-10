using CSE3902.Environment;
using CSE3902.Interfaces;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.Environment
{
    class StateDoorOpen : IStateInteractable
    {
        private readonly TileDoor _tile;
        public ISprite Sprite { get; set; }
        private int _timer;
        public StateDoorOpen(TileDoor tile)
        {
            _tile = tile;
            tile.DoCollisions = false;
            Sprite = EnvironmentSpriteFactory.Instance.CreateDoorSprite(true);
            Sprite.X = (int)tile.Position.X;
            Sprite.Y = (int)tile.Position.Y;
            Sprite.FacingRight = tile.FacingRight;
        }

        public void Interact()
        {
            _tile.State = new StateDoorClosed(_tile);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public void Update()
        {
            _timer++;
            if (_timer <= 160) return;
            if (CollisionHandler.Instance.BlockedBelow(_tile.BoundingBox, 5, "Player"))
                return;
            Interact();
        }
    }
}
