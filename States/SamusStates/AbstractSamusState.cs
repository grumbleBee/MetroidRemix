using CSE3902.Interfaces;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.SamusStates
{
    abstract class AbstractSamusState : ISamusState
    {
        public ISprite Sprite { get; set; }

        public virtual void ActionPress() { }
        public virtual void ActionHold() { }
        public virtual void ActionRelease() { }
        public virtual void DownPress() { }
        public virtual void DownRelease() { }
        public abstract void Draw(SpriteBatch spriteBatch);
        public virtual void JumpPress() { }
        public virtual void JumpRelease() { }
        public virtual void LeftPress() { }
        public virtual void LeftRelease() { }
        public virtual void RightPress() { }
        public virtual void RightRelease() { }
        public abstract void Update();
        public virtual void UpPress() { }
        public virtual void UpRelease() { }
        public virtual void RightHold() { }
        public virtual void LeftHold() { }
    }
}
