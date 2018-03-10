using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CSE3902.States.Environment;
using CSE3902.Interfaces;
using static CSE3902.Util.WorldUtil;

namespace CSE3902.Environment
{
    class TileDoor : StandardGameObject, ITileInteractable
    {
        public IState State { get; set; }
        public bool FacingRight { get; }
        public TileDoor(Vector2 pos, bool facingRight, bool open)
        {
            if (open)
                State = new StateDoorOpen(this);
            else
                State = new StateDoorClosed(this);
            if (facingRight)
                Position = new Vector2(pos.X - 8, pos.Y);
            else
                Position = new Vector2(pos.X, pos.Y);
            GetSprite().FacingRight = facingRight;
            FacingRight = facingRight;
            NoOutwardCollisions = true;
            UpdateDuringLesserState = WorldState.Transitioning;
            CollideDuringLesserState = WorldState.Transitioning;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch);
        }

        public override void Update()
        {
            State.Update();
        }

        public void OnInteract()
        {
            ((IStateInteractable)State).Interact();
        }

        public sealed override ISprite GetSprite()
        {
            return State.Sprite;
        }
    }
}
