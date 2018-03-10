﻿using CSE3902.Util;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Sprites.Samus
{
    class SamusStandLookUpSprite : Sprite
    {
        public SamusStandLookUpSprite(Texture2D texture, int width, int height, bool isFaceRight) : base(texture, width, height, SpriteUtil.SingleFrame, isFaceRight)
        {

        }

        public override void Update()
        {
        }
    }
}