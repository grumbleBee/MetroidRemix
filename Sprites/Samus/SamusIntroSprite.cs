using CSE3902.Util;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Sprites.Samus
{
    class SamusIntroSprite : Sprite
    {
        private readonly int _delay;
        private int _frameCount;
        public SamusIntroSprite(Texture2D spriteSheet, int width, int height) : base(spriteSheet, width, height, SpriteUtil.SamusintroFrames, true)
        {
            _delay = 5;
            _frameCount = 0;
        }

        public override void Update()
        {

        }

        public override void NextFrame()
        {
            _frameCount++;
            if (_frameCount > _delay)
            {
                _frameCount = 0;
                base.NextFrame();
            }
        }
    }
}
