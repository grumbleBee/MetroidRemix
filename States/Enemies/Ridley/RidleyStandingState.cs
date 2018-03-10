using CSE3902.Interfaces;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CSE3902.States.Enemies.Ridley
{
    public class RidleyStandingState : IRidleyState
    {
        private readonly CSE3902.Enemies.Ridley _ridley;
        private double _timeLastJumped;
        private double _currentTime;
        public ISprite Sprite { get; set; }

        public RidleyStandingState(CSE3902.Enemies.Ridley ridley)
        {
            _ridley = ridley;
            ridley.OnGround = true;
            Sprite = EnemySpriteFactory.Instance.CreateRidleyStandingSprite(_ridley.FacingRight);
            Sprite.X = (int)_ridley.Position.X;
            Sprite.Y = (int)_ridley.Position.Y;
            _ridley.BoundingBox = new Rectangle(0, 0, 20, 48);
            _timeLastJumped = DateTime.Now.TimeOfDay.TotalMilliseconds;
        }


        public void TurnRed()
        {
            Sprite = EnemySpriteFactory.Instance.CreateRidleyStandingRedSprite(_ridley.FacingRight);
            Sprite.X = (int)_ridley.Position.X;
            Sprite.Y = (int)_ridley.Position.Y;
            _ridley.BoundingBox = new Rectangle(0, 0, 20, 48);

        }

        private void Jump()
        {
            _ridley.State = new RidleyJumpingState(_ridley);
        }

        public void Update()
        {
            _currentTime = DateTime.Now.TimeOfDay.TotalMilliseconds;
            
            UpdateFaceDirection();
            TurnRedUpdate();
            if (_currentTime >= _timeLastJumped + 2000)
            {
                _timeLastJumped = _currentTime;
                Jump();
            }
        }

        public void TurnRedUpdate()
        {

            if (_ridley.CurrentlyTakingDamage && _currentTime > _ridley.LastTimeTookDamage + 500)
            {
                _ridley.CurrentlyTakingDamage = false;
                TurnOffRed();
            }
        }

        private void TurnOffRed()
        {
            Sprite = EnemySpriteFactory.Instance.CreateRidleyStandingSprite(_ridley.FacingRight);
            Sprite.X = (int)_ridley.Position.X;
            Sprite.Y = (int)_ridley.Position.Y;
            _ridley.BoundingBox = new Rectangle(0, 0, 20, 48);
        }

        private void UpdateFaceDirection()
        {
            if (Game1.GetLevel().Players[0].Position.X >= _ridley.Position.X)
            {
                _ridley.FacingRight = true;
            }

            else
            {
                _ridley.FacingRight = false;
            }
            _ridley.GetSprite().FacingRight = _ridley.FacingRight;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }
    }
}
