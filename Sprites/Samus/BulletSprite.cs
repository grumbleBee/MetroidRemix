using CSE3902.Util;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Sprites.Samus
{
    class BulletSprite : Sprite
    {
        public BulletSprite(Texture2D spriteSheet, int width, int height, bool isFacingRight) : base(spriteSheet, width, height, SpriteUtil.SingleFrame, isFacingRight)
        {

        }

        public override void Update()
        {

        }
    }
}
