using CSE3902.Util;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Sprites.Samus
{
    class BombInstanceSprite : Sprite
    {
        public BombInstanceSprite(Texture2D spriteSheet, int width, int height, bool isFacingRight) : base(spriteSheet, width, height, SpriteUtil.SamusbombFrames, isFacingRight)
        {

        }

        public override void Update()
        {

        }
    }
}
