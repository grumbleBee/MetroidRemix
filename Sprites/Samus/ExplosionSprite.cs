using CSE3902.Util;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Sprites.Samus
{
    class ExplosionSprite : Sprite
    {
        public ExplosionSprite(Texture2D spriteSheet, int width, int height, bool isFacingRight) : base(spriteSheet, width, height, SpriteUtil.ExplosionFrames, isFacingRight)
        {
            
        }

        public override void Update()
        {

        }
    }
}
