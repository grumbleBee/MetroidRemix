using CSE3902.Interfaces;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.Enemies.Skree
{
    class SkreeHangingState : ISkreeState
    {
        readonly CSE3902.Enemies.Skree _skree;

        public ISprite Sprite { get; set; }
        public SkreeHangingState(CSE3902.Enemies.Skree skree)
        {
            _skree = skree;
            Sprite = EnemySpriteFactory.Instance.CreateSkreeHangingSprite(true);
            Sprite.X = (int)skree.Position.X;
            Sprite.Y = (int)skree.Position.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public void Update()
        {
            Sprite.Update();
            if(CollisionHandler.Instance.BlockedBelow(_skree.BoundingBox, 300, "Samus"))
            {
                _skree.Move();
            }
        }

        public void TurnRed()
        {
            Sprite = EnemySpriteFactory.Instance.CreateSkreeHangingRedSprite(true);
        }

        public void Move()
        {
            _skree.State = new SkreeDivingState(_skree);
        }
    }
}
