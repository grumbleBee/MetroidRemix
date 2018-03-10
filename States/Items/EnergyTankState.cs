using CSE3902.Interfaces;
using CSE3902.Power_Ups;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.Items
{
    public class EnergyTankState : IItemState
    {
        readonly EnergyTank _tank;
        public ISprite Sprite
        { get; set; }
        public EnergyTankState(EnergyTank tank)
        {
            _tank = tank;
            Sprite = ItemSpriteFactory.Instance.CreateEnergyTankSprite();
            Sprite.X = (int)tank.Position.X;
            Sprite.Y = (int)tank.Position.Y;
            Sprite.Visible = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public void PickUp()
        {
            _tank.Obtain();
        }

        public void Update()
        {

        }
    }
}
