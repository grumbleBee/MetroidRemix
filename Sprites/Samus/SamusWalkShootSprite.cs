using CSE3902.Util;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Sprites.Samus
{
    class SamusWalkShootSprite : Sprite
    {
        public SamusWalkShootSprite(Texture2D spriteSheet, int spriteWidth, int spriteHeight, bool isFaceRight) : base(spriteSheet, spriteWidth, spriteHeight, SpriteUtil.SamuswalkshootFrames, isFaceRight)
        {
        }

        public override void Update()
        {
            
        }
    }
}
