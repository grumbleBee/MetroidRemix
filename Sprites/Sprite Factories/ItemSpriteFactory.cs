using CSE3902.Interfaces;
using CSE3902.Sprites.Items;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Sprites.Sprite_Factories
{
    class ItemSpriteFactory
    {
        private Texture2D _energyRefill;
        private Texture2D _energyTank;
        private Texture2D _bomb;
        private Texture2D _maruMari;
        private Texture2D _missileRefill;
        private Texture2D _missilePack;
        public static ItemSpriteFactory Instance { get; } = new ItemSpriteFactory();

        private ItemSpriteFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            _bomb = content.Load<Texture2D>("bombs");
            _energyRefill = content.Load<Texture2D>("energyRefill");
            _energyTank = content.Load<Texture2D>("energyTank");
            _maruMari = content.Load<Texture2D>("maruMari");
            _missileRefill = content.Load<Texture2D>("missileRefill");
            _missilePack = content.Load<Texture2D>("missilePack");
        }

       public ISprite CreateMaruMariSprite()
        {
            return new MaruMariSprite(_maruMari, 20, 20);
        }

        public ISprite CreateBombSprite()
        {
            return new BombSprite(_bomb, 20, 20);
        }
        public ISprite CreateEnergyTankSprite()
        {
            return new EnergyTankSprite(_energyTank, 20, 20);
        }
        public ISprite CreateMisslePackSprite()
        {
            return new MisslePackSprite(_missilePack, 20, 20);
        }

        public ISprite CreateMissileRefillSprite()
        {
            return new MissileRefillSprite(_missileRefill, 20, 20);
        }

        public ISprite CreateEnergyRefillSprite()
        {
            return new EnergyRefillSprite(_energyRefill, 20, 20);
        }
    }
}
