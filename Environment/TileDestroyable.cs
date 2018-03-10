using Microsoft.Xna.Framework;
using CSE3902.States.Environment;
using CSE3902.Interfaces;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Environment
{
    class TileDestroyable : StandardGameObject, ITileInteractable
    {
        public IState State { private get; set; }

        public TileDestroyable(Vector2 pos)
        {
            State = new StateDestroyableUndestroyed(this);
            Position = pos;
            NoOutwardCollisions = true;
        }

        public void OnInteract()
        {
            
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
