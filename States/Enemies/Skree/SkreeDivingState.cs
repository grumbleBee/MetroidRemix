using CSE3902.Interfaces;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.Enemies.Skree
{
    class SkreeDivingState : ISkreeState
    {
        readonly CSE3902.Enemies.Skree _skree;
        public ISprite Sprite { get; set; }

        public SkreeDivingState(CSE3902.Enemies.Skree skree)
        {
            _skree = skree;
            Sprite = EnemySpriteFactory.Instance.CreateSkreeDivingSprite(true);
        }

        public void Update()
        {
            _skree.Position = new Vector2(_skree.Position.X, _skree.Position.Y + 1);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public void TurnRed()
        {
            Sprite = EnemySpriteFactory.Instance.CreateSkreeDivingRedSprite(true);
        }

        public void Move()
        {
            _skree.State = new SkreeDrillingState(_skree);
        }
    }
}
