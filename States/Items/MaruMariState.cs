using CSE3902.Interfaces;
using CSE3902.Power_Ups;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.Items
{
    public class MaruMariState : IItemState
    {
        readonly MaruMari _maruMari;
        public ISprite Sprite
        { get; set; }
        public MaruMariState(MaruMari maruMari)
        {
            _maruMari = maruMari;
            Sprite = ItemSpriteFactory.Instance.CreateMaruMariSprite();
            Sprite.X = (int)maruMari.Position.X;
            Sprite.Y = (int)maruMari.Position.Y;
            Sprite.Visible = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public void PickUp()
        {
            _maruMari.Obtain();
        }

        public void Update()
        {

        }
    }
}
