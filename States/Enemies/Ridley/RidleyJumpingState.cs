using CSE3902.Interfaces;
using System;
using Microsoft.Xna.Framework.Graphics;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework;

namespace CSE3902.States.Enemies.Ridley
{
    public class RidleyJumpingState : IRidleyState
    {
        readonly double _timeLastJumped;
        private double _currentTime;
        readonly CSE3902.Enemies.Ridley _ridley;
        public ISprite Sprite { get; set; }
        public RidleyJumpingState(CSE3902.Enemies.Ridley ridley)
        {
            _ridley = ridley;
            _ridley.OnGround = false;
            Sprite = EnemySpriteFactory.Instance.CreateRidleyJumpingSprite(_ridley.FacingRight);
            Sprite.X = (int)_ridley.Position.X;
            Sprite.Y = (int)_ridley.Position.Y;
            _ridley.BoundingBox = new Rectangle(0, 0, 20, 48);
            _timeLastJumped = DateTime.Now.TimeOfDay.TotalMilliseconds;
        }

     
        public void TurnRed()
        {
            Sprite = EnemySpriteFactory.Instance.CreateRidleyJumpingRedSprite(_ridley.FacingRight);
        }

        private void TurnOffRed()
        {
            Sprite = EnemySpriteFactory.Instance.CreateRidleyJumpingSprite(_ridley.FacingRight);

        }

        public void Update()
        {
            _currentTime = DateTime.Now.TimeOfDay.TotalMilliseconds;
            UpdateFaceDirection();
            TurnRedUpdate();
            DoJumpAnimation();
        }





        private void DoJumpAnimation()
        {
            Vector2 pos = new Vector2 {X = _ridley.Position.X};
            if (_currentTime >= _timeLastJumped + 800)
            {
                pos.Y = (float)(_ridley.Position.Y + 1.2);
                _ridley.JumpDirectionProp = CSE3902.Enemies.Ridley.JumpDirection.Down;
            }
            else
            {
                pos.Y = (float)(_ridley.Position.Y - 1.2);
                _ridley.JumpDirectionProp = CSE3902.Enemies.Ridley.JumpDirection.Up;
            }
            _ridley.Position = pos;

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

        public void TurnRedUpdate()
        {

            if (_ridley.CurrentlyTakingDamage && _currentTime > _ridley.LastTimeTookDamage + 500)
            {
                _ridley.CurrentlyTakingDamage = false;
                TurnOffRed();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }


    }
}
