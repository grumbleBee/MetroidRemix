using Microsoft.Xna.Framework.Graphics;
using CSE3902.Util;

namespace CSE3902.Sprites.Environment
{
    class TileDoorSprite : Sprite
    {
        private readonly bool _isOpening;
        public TileDoorSprite(Texture2D spriteSheet, int spriteWidth, int spriteHeight, bool isFaceRight, bool isOpening) : base(spriteSheet, spriteWidth, spriteHeight, SpriteUtil.DoorFrames, isFaceRight)
        {
            LayerOrder = 0.1f;
            if (isOpening)
            {
                Frame = 1;
            } else
            {
                Frame = 3;
            }
            _isOpening = isOpening;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_isOpening && Frame < Frames)
            {
                Frame++;
            }
            if (!_isOpening && Frame > 1)
            {
                Frame--;
            }
            base.Draw(spriteBatch);
        }

        public override void NextFrame()
        {
            
        }

        public override void Update()
        {

        }
    }
}
