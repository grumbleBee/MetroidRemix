using CSE3902.Interfaces;
using CSE3902.Power_Ups;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.Items
{
    public class BombState : IItemState
    {
        readonly Bomb _bomb;
        public ISprite Sprite
        { get; set; }
        public BombState(Bomb bomb)
        {
            _bomb = bomb;
            Sprite = ItemSpriteFactory.Instance.CreateBombSprite();
            Sprite.X = (int)bomb.Position.X;
            Sprite.Y = (int)bomb.Position.Y;
            Sprite.Visible = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public void PickUp()
        {
            _bomb.Obtain();
        }

        public void Update()
        {
          
        }
    }
}
