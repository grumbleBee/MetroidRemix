using CSE3902.Util;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Sprites.Samus
{
    class SamusWalkLookUpSprite : Sprite
    {
        public SamusWalkLookUpSprite(Texture2D spriteSheet, int spriteWidth, int spriteHeight, bool isFaceRight) : base(spriteSheet, spriteWidth, spriteHeight, SpriteUtil.SamuswalklookupFrames, isFaceRight)
        {
        }


        public override void Update()
        {
            
        }
    }
}
