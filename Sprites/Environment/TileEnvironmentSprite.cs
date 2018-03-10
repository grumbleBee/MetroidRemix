using CSE3902.Util;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Sprites.Environment
{
    class TileEnvironmentSprite : Sprite
    {
        private readonly int _tileId;
        public TileEnvironmentSprite(Texture2D texture, int width, int height, int tileId) : base(texture, width, height, SpriteUtil.SingleFrame, true)
        {
            _tileId = tileId;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Frame != _tileId)
                Frame = _tileId;
            base.Draw(spriteBatch);
        }

        public override void Update()
        {

        }
    }
}
