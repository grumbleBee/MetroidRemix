using CSE3902.Util;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Sprites.Enemies.Skree
{
    class SkreeDivingSprite : Sprite
    {
        readonly int _spriteDelay;
        int _passedDelay;
        int _lastFrame;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "isVisible")]
        public SkreeDivingSprite(Texture2D spriteSheet, int width, int height, bool isVisible) : base(spriteSheet, width, height, SpriteUtil.SkreeFrames, isVisible)
        {
            _spriteDelay = 3;
            _passedDelay = 0;
            _lastFrame = 1;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_passedDelay <= _spriteDelay)
            {
                _passedDelay++;
                Frame = _lastFrame;
                base.Draw(spriteBatch);
                return;
            }
            _lastFrame = Frame;
            base.Draw(spriteBatch);
            _passedDelay = 0;
        }

        public override void Update()
        {

        }
    }
}
