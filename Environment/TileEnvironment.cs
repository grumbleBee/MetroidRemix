using CSE3902.Interfaces;
using CSE3902.States.Environment;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Environment
{
    class TileEnvironment : StandardGameObject
    {
        private IState State { get; }
        public TileEnvironment(Vector2 pos, int tileId)
        {
            State = new StateEnvironment(this,tileId);
            Position = pos;
            NoOutwardCollisions = true;
        }

        public override ISprite GetSprite()
        {
            return State.Sprite;
        }

        public override void Update()
        {
            State.Update();
            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch);
        }
    }
}
