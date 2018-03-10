using System;
using CSE3902.Interfaces;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.Enemies.Skree
{
    class SkreeDrillingState : ISkreeState
    {
        readonly CSE3902.Enemies.Skree _skree;
        readonly double _skreeTimer;
        public ISprite Sprite { get; set; }

        public SkreeDrillingState(CSE3902.Enemies.Skree skree)
        {
            _skree = skree;
            Sprite = EnemySpriteFactory.Instance.CreateSkreeDrillingSprite();
            Sprite.X = (int)skree.Position.X;
            Sprite.Y = (int)skree.Position.Y;
            _skreeTimer = DateTime.Now.TimeOfDay.TotalMilliseconds;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public void Update()
        {
            Sprite.Update();
            if(DateTime.Now.TimeOfDay.TotalMilliseconds - _skreeTimer > 1000)
            {
                _skree.State = new SkreeExplodingState(_skree);
            }
        }

        public void TurnRed()
        {
            Sprite = EnemySpriteFactory.Instance.CreateSkreeDrillingRedSprite();
        }

        public void Move()
        {
            
        }
    }
}
