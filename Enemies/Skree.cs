using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CSE3902.Interfaces;
using System;
using CSE3902.Players;
using CSE3902.Effects;
using CSE3902.Power_Ups;
using CSE3902.States.Enemies.Skree;

namespace CSE3902.Enemies
{
    class Skree : StandardGameObject, IEnemy
    {
        private bool IsSamusNearby { get; set; }
        public ISkreeState State { private get; set; }
        private int Health { get; set; } = 10;

        public Skree(Vector2 pos)
        {
            State = new SkreeHangingState(this);
            Position = pos;
            IsSamusNearby = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch);
        }

        public override void Update()
        {
            State.Update();

            if (IsSamusNearby)
            {
                State = new SkreeDivingState(this);
                IsSamusNearby = false;
            }
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

        public void TurnRed()
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
