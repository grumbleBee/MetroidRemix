using CSE3902.Util;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Effects
{
    class FontManager
    {
        private SpriteFont _defaultFont;
        public static FontManager Instance { get; } = new FontManager();

        private FontManager()
        {

        }

        public void LoadAllFonts(ContentManager content)
        {
            _defaultFont = content.Load<SpriteFont>(InterfaceListUtil.DefaultFont);
        }

        public SpriteFont CreateNewDefaultFont()
        {
            return _defaultFont;
        }
    }
}
