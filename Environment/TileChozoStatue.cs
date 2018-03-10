using CSE3902.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CSE3902.Sprites.Sprite_Factories;

namespace CSE3902.Environment
{
    class TileChozoStatue : StandardGameObject, ITileInteractable
    {
        ISprite _sprite;
        private bool _broken;
        private readonly bool _facingRight;
        private Vector2 _pos;
        public TileChozoStatue(Vector2 pos, bool facingRight, bool broken)
        {
            _sprite = EnvironmentSpriteFactory.Instance.CreateChozoStatueSprite(facingRight, broken);
            _facingRight = facingRight;
            _broken = broken;
            _pos = pos;
            _sprite.X = (int)pos.X;
            _sprite.Y = (int)pos.Y;
            BoundingBox = new Rectangle((int)pos.X, (int)pos.Y, _sprite.Width, _sprite.Height);
            NoOutwardCollisions = true;
        }

        public void OnInteract()
        {
            _broken = !_broken;
            _sprite = EnvironmentSpriteFactory.Instance.CreateChozoStatueSprite(_facingRight, _broken);
            _sprite.X = (int)_pos.X;
            _sprite.Y = (int)_pos.Y;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _sprite.Draw(spriteBatch);
        }

        public override void Update()
        {
            _sprite.Update();
        }

        public override ISprite GetSprite()
        {
            return _sprite;
        }
    }
}
