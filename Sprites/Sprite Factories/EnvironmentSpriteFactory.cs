using CSE3902.Interfaces;
using CSE3902.Sprites.Environment;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Sprites.Sprite_Factories
{
    class EnvironmentSpriteFactory
    {
        private Texture2D _tileDestroyableBlock;
        private Texture2D _tileDoor;
        private Texture2D _tileChozoStatue;
        private Texture2D _tilesetEnvironmental;
        private Texture2D _menuBackground;
        private Texture2D _menuTitle;
        private Texture2D _energyMarker;
        private Texture2D _missileMarker;
        private Texture2D _cursor;

        public static EnvironmentSpriteFactory Instance { get; } = new EnvironmentSpriteFactory();

        private EnvironmentSpriteFactory() { }

        public void LoadAllTextures(ContentManager content)
        {
            _tileDestroyableBlock = content.Load<Texture2D>("TileDestroyableBlock");
            _tileDoor = content.Load<Texture2D>("TileDoor");
            _tileChozoStatue = content.Load<Texture2D>("ChozoStatue");
            _tilesetEnvironmental = content.Load<Texture2D>("EnvironmentTileSet");
            _menuBackground = content.Load<Texture2D>("menu_background_stretched");
            _menuTitle = content.Load<Texture2D>("menu_title");
            _energyMarker = content.Load<Texture2D>("energy_marker");
            _missileMarker = content.Load<Texture2D>("missile_marker");
            _cursor = content.Load<Texture2D>("cursor");
        }

        public ISprite CreateCursorSprite()
        {
            return new CursorSprite(_cursor, 32, 32);
        }

        public ISprite CreateEnergyMarkerSprite()
        {
            return new EnergyMarkerSprite(_energyMarker, 48, 20);
        }

        public ISprite CreateMissileMarkerSprite()
        {
            return new MissileMarkerSprite(_missileMarker, 27, 20);
        }

        public ISprite CreateMenuBackgroundSprite()
        {
            return new MenuBackgroundSprite(_menuBackground, 800, 480);
        }

        public ISprite CreateMenuTitleSprite()
        {
            return new MenuTitleSprite(_menuTitle, 416, 116);
        }

        public ISprite CreateDestroyableBlockSprite()
        {
            return new TileDestroyableBlockSprite(_tileDestroyableBlock,16,16);
        }

        public ISprite CreateDoorSprite(bool open)
        {
            return new TileDoorSprite(_tileDoor, 24, 48, true, open);
        }

        public ISprite CreateChozoStatueSprite(bool isFacingRight, bool broken)
        {
            return new TileChozoStatueSprite(_tileChozoStatue, 40, 40, isFacingRight, broken);
        }

        public ISprite CreateEnvironmentalTile(int tileId)
        {
            return new TileEnvironmentSprite(_tilesetEnvironmental, 16, 16, tileId);
        }
    }
}
