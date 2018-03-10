using CSE3902.Effects;
using CSE3902.Interfaces;
using CSE3902.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using CSE3902.Power_Ups;
using CSE3902.States.Enemies.Ripper;

namespace CSE3902.Enemies
{
    class Ripper : StandardGameObject, IEnemy
    {
        private bool _moveRight = true;
        public IRipperState State { private get; set; }
        private int Health { get; set; } = 10;

        private bool MoveRight
        {
            set
            {
                _moveRight = value;
            }
        }

        public override void Update()
        {
            State.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch);
        }

        public Ripper(Vector2 position)
        {
            MoveRight = _moveRight;
            State = new RipperRightState(this);
            Position = position;
        }

        public void TakeDamage()
        {
            Health -= 5;
            TurnRed();
            if (Health <= 0)
            {
                Game1.GetLevel().Destroy(this);
                DoItemDrops();
            }

                SoundManager.Instance.PlaySong("enemy_die1");
            
        }

        public void Move()
        {
            State.Move();
        }

        public override ISprite GetSprite()
        {
            return State.Sprite;
        }

        private void TurnRed()
        {
            State.TurnRed();
        }

        public virtual void DoItemDrops()
        {
            ILevel level = Game1.GetLevel();
            Samus player = level.Players[0] as Samus;
            Random ran = new Random();
            if (ran.Next(100) < 30)
            {
                if (player.HasMissileUpgrade && ran.Next(100) > 50)
                {
                    level.Spawn(new MissileRefill(Position), Position);
                }
                else
                {
                    level.Spawn(new EnergyRefill(Position), Position);
                }
            }
        }
    }
}
