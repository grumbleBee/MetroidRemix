using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902.Interfaces;

namespace CSE3902.Sprites
{
    public abstract class Sprite : ISprite
    {
        private int _spriteX;
        private int _spriteY;
        private int _frames;
        public int Frame { get; protected set; }
        private bool _facingRight;
        private Rectangle _worldRect;
        private Rectangle _sourceRect;

        public float LayerOrder { get; set; }
        private float Rotation { get; set; }

        public int Frames
        {
            get
            {
                return _frames;
            }
            set
            {
                _frames = value;
            }
        }

        public bool FacingRight
        {
            get
            {
                return _facingRight;
            }

            set
            {
                _facingRight = value;
            }
        }

        public int Height { get; }

        public Texture2D Texture { get; }

        public int Width { get; }

        public int X
        {
            get
            {
                return _spriteX;
            }

            set
            {
                _spriteX = value;
                _worldRect.X = value;
            }
        }

        public int Y
        {
            get
            {
                return _spriteY;
            }

            set
            {
                _spriteY = value;
                _worldRect.Y = value;
            }
        }

        public bool Visible { get; set; }

        public Rectangle WorldRect
        {
            get
            {
                return _worldRect;
            }

            set
            {
                _worldRect = value;
            }
        }

        public Rectangle SourceRect
        {
            get
            {
                if (_sourceRect.Width == 0 && _sourceRect.Height == 0)
                {
                    _sourceRect.Width = Width;
                    _sourceRect.Height = Height;
                }
                return _sourceRect;
            }

            protected set
            {
                _sourceRect = value;
            }
        }

        public abstract void Update();

        protected Sprite(Texture2D spriteSheet, int spriteWidth, int spriteHeight, int frames, bool isFaceRight)
        {
            LayerOrder = 1f;
            Width = spriteWidth;
            Height = spriteHeight;
            Texture = spriteSheet;
            _facingRight = isFaceRight;
            _frames = frames;
            Frame = 1;
            WorldRect = new Rectangle(X, Y, Width, Height);
            Visible = true;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (!Visible) return;
            SourceRect = new Rectangle((Frame-1) * Width, 0, Width, Height);

            if (!_facingRight)
                spriteBatch.Draw(Texture, WorldRect, SourceRect, Color.White, Rotation, Vector2.Zero, SpriteEffects.FlipHorizontally, LayerOrder);
            else
                spriteBatch.Draw(Texture, WorldRect, SourceRect, Color.White, Rotation, Vector2.Zero, SpriteEffects.None, LayerOrder);
        }

        public virtual void NextFrame()
        {
            Frame++;
            if (Frame > _frames)
                Frame = 1;
        }
    }
}
