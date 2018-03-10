using CSE3902.Util;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Sprites.Samus
{
    class SamusBallSprite:Sprite
    {
        public SamusBallSprite(Texture2D spriteSheet, int width, int height, bool isFacingRight) : base(spriteSheet, width, height, SpriteUtil.SamusballFrames, isFacingRight)
        {
        }

        public override void Update()
        {
          
        }
    }
}
