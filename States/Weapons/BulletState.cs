using CSE3902.Interfaces;
using CSE3902.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using CSE3902.Sprites.Sprite_Factories;
using CSE3902.States.SamusStates;

namespace CSE3902.States.Weapons
{
    public class BulletState : IState
    {
        readonly Bullet _bullet;
        readonly Samus _samus;
        bool _directionIsSet;
        readonly int _speed;
        public ISprite Sprite
        { get; set; }
        public BulletState(Bullet bullet, IPlayer samus)
        {
            _bullet = bullet;
            Sprite = PlayerSpriteFactory.Instance.CreateBullet(samus.FacingRight);
            _speed = 5;
            _directionIsSet = false;
            _samus = (Samus)samus;
        }

        private void UpdateBulletVelocity(ISamusState samusState)
        {
            if (samusState is SamusStandLookUpState || samusState is SamusJumpingLookUpState || samusState is SamusWalkLookUpState)
            {
                _bullet.Velocity = new Vector2(0, -_speed);

            }
            else
            {
                _bullet.Velocity = _bullet.PlayerCharacter.FacingRight ? new Vector2(_speed, 0) : new Vector2(-_speed, 0);

            }
            _directionIsSet = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public void Update()
        {
            if (Math.Abs(_bullet.DistanceTraveled) > 50)Game1.GetLevel().Destroy(_bullet);
            else
            {
                if (!_directionIsSet) UpdateBulletVelocity(_samus.State);
                _bullet.Position = new Vector2(_bullet.Position.X + _bullet.Velocity.X, _bullet.Position.Y + _bullet.Velocity.Y);
                if (_bullet.Velocity.X != 0)
                {
                    _bullet.DistanceTraveled += _bullet.Velocity.X;
                }

                else if (_bullet.Velocity.Y != 0)
                {
                    _bullet.DistanceTraveled += _bullet.Velocity.Y;
                }
            }
        }

    }

}
