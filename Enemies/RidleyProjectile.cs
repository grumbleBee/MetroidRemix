using CSE3902.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using CSE3902.States.Enemies.Ridley;
using Microsoft.Xna.Framework;
using CSE3902.Util;

namespace CSE3902.Enemies
{
    public class RidleyProjectile : StandardGameObject
    {
        private readonly IState _state;

        public Ridley Ridley { get; set; }

        public RidleyProjectile(Ridley ridley)
        {
            var ridley1 = ridley;
            _state = new RidleyProjectileState(this, ridley1);
            Mass = EnemyConstants.RidleyProjectileMass;
            GetSprite().X = (int)Position.X;
            GetSprite().Y = (int)Position.Y;
            IsKinematic = false;
            int xFactor = ridley1.FacingRight ? 1 : -1;
            ApplyForce(new Vector2(EnemyConstants.RidleyProjectileHorFar * xFactor, EnemyConstants.RidleyProjectileVer));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _state.Draw(spriteBatch);
        }

        public override void Update()
        {
            _state.Update();
        }

        public override ISprite GetSprite()
        {
            return _state.Sprite;
        }

    }
}
