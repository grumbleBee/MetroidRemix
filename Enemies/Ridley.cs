using CSE3902.Interfaces;
using System;
using Microsoft.Xna.Framework.Graphics;
using CSE3902.Power_Ups;
using CSE3902.Effects;
using CSE3902.States.Enemies.Ridley;
using Microsoft.Xna.Framework;

namespace CSE3902.Enemies
{
    public class Ridley : StandardGameObject, IEnemy
    {
        public IRidleyState State { private get; set; }
        public bool FacingRight { get; set; }
        private int Health { get; set; } = 100;
        private double _timeLastFiredRound = DateTime.Now.TimeOfDay.TotalMilliseconds;
        private double _currentTime = DateTime.Now.TimeOfDay.TotalMilliseconds;
        private int _shotCounter;
        private int _shotDelay = 1000;
        private bool _bossHurtSongStarted;



        public bool CurrentlyTakingDamage { get; set; }

        public double LastTimeTookDamage { get; set; }


        public enum JumpDirection
        {
            Up, Down
        }

        public JumpDirection JumpDirectionProp { get; set; }

        public Ridley(Vector2 position)
        {
            State = new RidleyStandingState(this);
            Position = position;
            FacingRight = true;
        }

        public void DoItemDrops()
        {
            ILevel level = Game1.GetLevel();
            level.Spawn(new EnergyRefill(Position), Position);  
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch);
        }

        public override void Update()
        {
            _currentTime = DateTime.Now.TimeOfDay.TotalMilliseconds;
            ShootUpdate();
            State.Update();
            SongUpdate();
        }

        public override ISprite GetSprite()
        {
            return State.Sprite;
        }

        public void Move()
        {
        }

        private void SongUpdate()
        {
            if(Health <= 20 && !_bossHurtSongStarted)
            {
                SoundManager.Instance.PlaySong("boss_hurt");
                _bossHurtSongStarted = true;
            }
        }

        private void Shoot()
        {
            int xFactor = FacingRight ? 30 : -10;
            int yFactor = -10;
            Game1.GetLevel().Spawn(new RidleyProjectile(this), new Vector2(Position.X + xFactor, Position.Y + yFactor));
            SoundManager.Instance.PlaySong("short_beam");
        }

        private void ShootUpdate()
        {
            
            if (_currentTime > _timeLastFiredRound + 2000 && _shotCounter != 5)
            {
                if (_shotDelay % 10 == 0) {
                    Shoot();
                    _shotCounter++;
                }

                _shotDelay++;
            }
            else
            {
                if (_shotCounter == 5)
                {
                    _timeLastFiredRound = DateTime.Now.TimeOfDay.TotalMilliseconds;
                    _shotCounter = 0;
                    _shotDelay = 0;
                }
            }


        }

        private void TurnRed()
        {
            State.TurnRed();
        }

        public void TakeDamage()
        {
            Health -= 5;
            LastTimeTookDamage = DateTime.Now.TimeOfDay.TotalMilliseconds;
            CurrentlyTakingDamage = true;
            TurnRed();
            
            if (Health <= 0)
            {
                Game1.GetLevel().Destroy(this);
                SoundManager.Instance.PauseSong("boss_hurt");
                DoItemDrops();
            }
            SoundManager.Instance.PlaySong("enemy_die1");
            
        }
    }
}
