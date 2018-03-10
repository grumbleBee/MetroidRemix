using CSE3902.Effects;
using CSE3902.Interfaces;
using CSE3902.States.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Power_Ups
{
    public class Bomb : StandardGameObject, IPowerUp
    {
        private IState State { get; }
        public Bomb(Vector2 pos)
        {
            State = new BombState(this);
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
            SoundManager.Instance.PlaySong("rocket_ammo");
        }

        public override ISprite GetSprite()
        {
            return State.Sprite;
        }
    }
}
