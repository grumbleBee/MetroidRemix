using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using CSE3902.Sprites;
using Microsoft.Xna.Framework;

namespace CSE3902.States
{
    class SamusJumpingLookUpShootState : AbstractSamusState
    {
        Samus samus;
        public SamusJumpingLookUpShootState(Samus samus)
        {
            this.samus = samus;
            Sprite = PlayerSpriteFactory.Instance.CreateSamusJumpingLookUp(samus.facingRight);
            Sprite.x = (int)samus.Position.X;
            Sprite.y = (int)samus.Position.Y;
            samus.BoundingBox = new Rectangle(Sprite.WorldRect.X + 5, Sprite.WorldRect.Y + 6, 9, 26);
        }

        override public void Draw(SpriteBatch SpriteBatch)
        {
            Sprite.Draw(SpriteBatch);
        }

        override public void JumpRelease()
        {
            samus.State = new SamusStandLookUpState(samus);
        }

        override public void LeftPress()
        {
            samus.facingRight = false;
            samus.State = new SamusJumpingLookUpShootState(samus);
        }

        override public void RightPress()
        {
            samus.facingRight = true;
            samus.State = new SamusJumpingLookUpShootState(samus);
        }

        public override void RightHold()
        {
            samus.ApplyForce(new Vector2(0.5f, 0));
        }

        public override void LeftHold()
        {
            samus.ApplyForce(new Vector2(-0.5f, 0));
        }

        override public void Update()
        {
            Sprite.Update();
        }

        override public void UpRelease()
        {
            samus.State = new SamusJumpingState(samus);
        }
    }
}
