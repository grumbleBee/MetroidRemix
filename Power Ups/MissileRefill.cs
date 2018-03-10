using CSE3902.Interfaces;
using CSE3902.States.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Power_Ups
{
    public class MissileRefill : StandardGameObject, IPowerUp
    {
        private IState State { get; }

        public MissileRefill(Vector2 pos)
        {
            State = new MissileRefillState(this);
            Position = pos;
        }
        public override void Update()
        {
            State.Update();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch);
        }

        public void Obtain()
        {
            Game1.GetLevel().Destroy(this);
        }

        public override ISprite GetSprite()
        {
            return State.Sprite;
        }
    }
}
