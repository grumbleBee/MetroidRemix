using CSE3902.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Sprites.Environment
{
    class TileChozoStatueSprite : Sprite
    {
        private readonly bool _isBreaking;

        public TileChozoStatueSprite(Texture2D spriteSheet, int spriteWidth, int spriteHeight, bool isFaceRight, bool isBreaking) : base(spriteSheet,spriteWidth,spriteHeight,SpriteUtil.ChozoFrames,isFaceRight)
        {
            if (isBreaking)
            {
                Frame = 1;
            }
            else
            {
                Frame = 3;
            }
            _isBreaking = isBreaking;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!Visible) return;
            SourceRect = new Rectangle((Frame - 1) * Width, 0, Width, Height);
            WorldRect = new Rectangle(X, Y, Width, Height);
            if (!FacingRight)
                spriteBatch.Draw(Texture, WorldRect, SourceRect, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0f);
            else
                spriteBatch.Draw(Texture, WorldRect, SourceRect, Color.White, 0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0f);
            if (_isBreaking && Frame < Frames)
            {
                Frame++;
            }
            if (!_isBreaking && Frame > 1)
            {
                Frame--;
            }
        }

        public override void Update()
        {

        }
    }
}
