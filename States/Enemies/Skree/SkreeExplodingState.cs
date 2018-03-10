using CSE3902.Interfaces;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.Enemies.Skree
{
    class SkreeExplodingState : ISkreeState
    {
        readonly CSE3902.Enemies.Skree _skree;
        public ISprite Sprite { get; set; }

        public SkreeExplodingState(CSE3902.Enemies.Skree skree)
        {
            _skree = skree;
            Sprite = EnemySpriteFactory.Instance.CreateSkreeExplodingSprite(false);
            Sprite.X = (int)skree.Position.X;
            Sprite.Y = (int)skree.Position.Y;
        }

        public void Move()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public void TurnRed()
        {

        }

        public void Update()
        {
            Sprite.Update();
            if(Sprite.Frame == Sprite.Frames)
            {
                Game1.GetLevel().Destroy(_skree);
            }
        }
    }
}
