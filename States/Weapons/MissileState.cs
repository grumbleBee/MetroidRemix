using CSE3902.Interfaces;
using CSE3902.Players;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902.States.SamusStates;

namespace CSE3902.States.Weapons
{
    public class MissileState : IState
    {
        private readonly Missile _missile;
        readonly Samus _samus;
        private bool _directionIsSet;
        readonly int _speed;
        
        public ISprite Sprite
        { get; set; }
        public MissileState(Missile missile, IPlayer samus)
        {
            _missile = missile;
            if (missile.IsUp)
            {
                Sprite = PlayerSpriteFactory.Instance.CreateVerticalMissile(samus.FacingRight);
            }
            else
            {
                Sprite = PlayerSpriteFactory.Instance.CreateHorizontalMissile(samus.FacingRight);
            }
            Sprite.X = (int)missile.Position.X;
            Sprite.Y = (int)missile.Position.Y;
            _speed = 5;
            Sprite.Visible = true;
            _directionIsSet = false;
            _samus = (Samus)samus;
        }

        private void UpdateMissileVelocity(ISamusState samusState)
        {
            if (samusState is SamusStandLookUpState || samusState is SamusJumpingLookUpState)
            {
                _missile.Velocity = new Vector2(0, -_speed);

            }
            else
            {
                _missile.Velocity = _missile.PlayerCharacter.FacingRight ? new Vector2(_speed, 0) : new Vector2(-_speed, 0);

            }
            _directionIsSet = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public void Update()
        {
                if (!_directionIsSet) UpdateMissileVelocity(_samus.State);
                _missile.Position = new Vector2(_missile.Position.X + _missile.Velocity.X, _missile.Position.Y + _missile.Velocity.Y);
                if (_missile.Velocity.X != 0)
                {
                    _missile.DistanceTraveled += _missile.Velocity.X;
                }

                else if (_missile.Velocity.Y != 0)
                {
                    _missile.DistanceTraveled += _missile.Velocity.Y;
                }
            }
        }

    }


