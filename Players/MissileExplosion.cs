using CSE3902.Interfaces;
using CSE3902.States.Weapons;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Players
{
    class MissileExplosion : StandardGameObject
    {
        private IState State { get; }
        public MissileExplosion(Missile missile)
        {
            State = new MissileExplosionState(this, missile);
            Position = missile.Position;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch);
        }

        public override void Update()
        {
            State.Update();
        }

        public override ISprite GetSprite()
        {
            return State.Sprite;
        }
    }
}
