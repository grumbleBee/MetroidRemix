using CSE3902.Enemies;
using CSE3902.Interfaces;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.Enemies.Ridley
{
    class RidleyProjectileState : IState
    {
        readonly CSE3902.Enemies.Ridley _ridley;
        public ISprite Sprite { get; set; }

        public RidleyProjectileState(RidleyProjectile ridelyProjectile, CSE3902.Enemies.Ridley ridley)
        {
            _ridley = ridley;
            Sprite = EnemySpriteFactory.Instance.CreateRidleyProjectileSprite(_ridley.FacingRight);
            ridelyProjectile.BoundingBox = new Rectangle(0, 0, 9, 10);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public void Update()
        {
                int xFactor = (_ridley.FacingRight) ? 1 : -1;
                _ridley.Velocity*= xFactor;
        }
    }
}
