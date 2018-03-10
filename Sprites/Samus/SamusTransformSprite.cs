using CSE3902.Util;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Sprites.Samus
{
    internal class SamusTransformSprite : Sprite
    {
        public SamusTransformSprite(Texture2D spriteSheet, int width, int height, bool isFacingRight) : base(spriteSheet, width, height, SpriteUtil.SamustransformFrames, isFacingRight)
        {

        }

        public override void Update()
        {

        }
    }
}