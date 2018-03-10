using CSE3902.Interfaces;
using CSE3902.Power_Ups;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.Items
{
    public class EnergyRefillState : IItemState
    {
        readonly EnergyRefill _refill;
        public ISprite Sprite
        { get; set; }
        public EnergyRefillState(EnergyRefill refill)
        {
            _refill = refill;
            Sprite = ItemSpriteFactory.Instance.CreateEnergyRefillSprite();
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
