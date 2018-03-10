using CSE3902.Util;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Sprites.Enemies.Ridley
{
    class StandingRidleySprite : Sprite
    {
        public StandingRidleySprite(Texture2D spriteSheet, int spriteWidth, int spriteHeight, bool isFacingRight) : base(spriteSheet, spriteWidth, spriteHeight, SpriteUtil.RidleyFrames,isFacingRight)
        {

        }

        public override void Update()
        {

        }
    }
}
