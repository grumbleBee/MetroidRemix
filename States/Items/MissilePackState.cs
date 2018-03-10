using CSE3902.Interfaces;
using CSE3902.Power_Ups;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.Items
{
    public class MissilePackState : IItemState
    {
        readonly MissilePack _pack;
        public ISprite Sprite
        { get; set; }
        public MissilePackState(MissilePack pack)
        {
            _pack = pack;
            Sprite = ItemSpriteFactory.Instance.CreateMisslePackSprite();
            Sprite.X = (int)pack.Position.X;
            Sprite.Y = (int)pack.Position.Y;
            Sprite.Visible = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public void PickUp()
        {
            _pack.Obtain();
        }

        public void Update()
        {

        }
    }
}
