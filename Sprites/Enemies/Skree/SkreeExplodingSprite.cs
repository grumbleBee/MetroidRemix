using CSE3902.Util;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Sprites.Enemies.Skree
{
    class SkreeExplodingSprite : Sprite
    {

        public SkreeExplodingSprite(Texture2D spriteSheet, int width, int height, bool isVisible) : base(spriteSheet, width, height, SpriteUtil.SkreeFrames, isVisible)
        {
        }

        public override void Update()
        {

        }
    }
}
