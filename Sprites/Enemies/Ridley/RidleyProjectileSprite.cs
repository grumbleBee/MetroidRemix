using CSE3902.Util;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Sprites.Enemies.Ridley
{
    public class RidleyProjectileSprite : Sprite
    {
        public RidleyProjectileSprite(Texture2D spriteSheet, int spriteWidth, int spriteHeight, bool isFacingRight) : base(spriteSheet, spriteWidth, spriteHeight, SpriteUtil.RidleyProjectileFrames, isFacingRight)
        {

        }

        public override void Update()
        {

        }
    }
}
