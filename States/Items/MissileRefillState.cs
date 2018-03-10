using CSE3902.Interfaces;
using CSE3902.Power_Ups;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.Items
{
    public class MissileRefillState : IItemState
    {
        readonly MissileRefill _refill;
        public ISprite Sprite
        { get; set; }
        public MissileRefillState(MissileRefill refill)
        {
            _refill = refill;
            Sprite = ItemSpriteFactory.Instance.CreateMissileRefillSprite();
            Sprite.X = (int)refill.Position.X;
            Sprite.Y = (int)refill.Position.Y;
            Sprite.Visible = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public void PickUp()
        {
            _refill.Obtain();
        }

        public void Update()
        {

        }
    }
}
