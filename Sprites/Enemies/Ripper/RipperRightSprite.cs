using CSE3902.Util;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Sprites.Enemies.Ripper
{
    class RipperRightSprite : Sprite
    {
        public RipperRightSprite(Texture2D spriteSheet, int spriteWidth, int spriteHeight, bool isFaceRight) : base(spriteSheet, spriteWidth, spriteHeight, SpriteUtil.RipperFrames, isFaceRight)
        {
        }

        public override void Update()
        {

        }
    }
}
