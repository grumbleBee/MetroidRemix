using CSE3902.Util;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Sprites.Environment
{
    class CursorSprite : Sprite
    {
        public CursorSprite(Texture2D spriteSheet, int spriteWidth, int spriteHeight) : base(spriteSheet, spriteWidth, spriteHeight, SpriteUtil.SingleFrame, true)
        {
        }

        public override void Update()
        {

        }
    }
}
