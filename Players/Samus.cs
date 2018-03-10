using CSE3902.Effects;
using CSE3902.Interfaces;
using CSE3902.States.SamusStates;
using CSE3902.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using CSE3902.Sprites.Sprite_Factories;
using static CSE3902.Util.WorldUtil;

namespace CSE3902.Players
{
    public class Samus : StandardGameObject, IPlayer
    {
        private int _missiles = PlayerConstants.SamusResourceEmpty;
        private int _bulletUpdateCounter = PlayerConstants.SamusResourceEmpty;
        private double _timeMissileLastFired;
        private double _timeBulletLastFired;
        private int _missilesFired = PlayerConstants.SamusResourceEmpty;
        private bool _startedNearDeathSound;

        public ISamusState State { get; set; }
        public bool Varia { get; private set; }
        public bool MissilesOn { get; private set; }
        public bool HasMissileUpgrade { get; set; }
        public bool HasBallForm { get; set; }
        public bool HasBombs { get; set; }
        public int MaxHealth { get; set; }
        public bool ZeroSuit { get; set; }
        public int Id { get; set; }
        public PlayerSpriteFactory.PlayerColorScheme ColorScheme { get; set; }
        private readonly int _maxInvulnFrames;
        private int _invulnFrames;

        public int Missiles
        {
            get
            {
                return _missiles;
            }

            set
            {
                _missiles = value;
            }
        }

        public int Health { get; set; } = PlayerConstants.SamusBaseEnergy;

        public bool FacingRight { get; set; }

        public Samus(Vector2 pos, int playerId)
        {
            Id = playerId;
            FacingRight = true;
            MaxHealth = PlayerConstants.SamusBaseMaxEnergy;
            Mass = PlayerConstants.SamusMass;
            MaxVelocity = new Vector2(PlayerConstants.SamusMaxSpeedHor, PlayerConstants.SamusMaxSpeedVert);
            IsKinematic = true;
            State = new SamusIntroState(this);
            UpdateDuringLesserState = WorldState.Paused;
            CollideDuringLesserState = WorldState.Paused;
            Position = pos;
            _maxInvulnFrames = PlayerConstants.SamusInvulnFrames;
            _invulnFrames = 0;
        }

        public void DownPress()
        {
            State.DownPress();

        }

        public void UpPress()
        {
            State.UpPress();

        }

        public void RightPress()
        {
            State.RightPress();

        }

        public void LeftPress()
        {
            State.LeftPress();

        }

        public void ActionPress()
        {
            State.ActionPress();
        }

        public void JumpPress()
        {
            
            if (CollisionHandler.Instance.BlockedBelow(BoundingBox, PlayerConstants.SamusBlockedBelowClose))
            {
                State.JumpPress();
                ApplyForce(new Vector2(0, PlayerConstants.SamusJumpForce));
                OnGround = false;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch);
        }

        public void DownRelease()
        {
            State.DownRelease();
        }

        public void UpRelease()
        {
            State.UpRelease();
        }

        public void RightRelease()
        {
            State.RightRelease();
        }

        public void LeftRelease()
        {
            State.LeftRelease();
        }

        public void ActionRelease()
        {
            State.ActionRelease();
        }

        public void JumpRelease()
        { 
            if (Velocity.Y < 0)
                Velocity = new Vector2(Velocity.X, 0);
            State.JumpRelease();
        }

        public void UpHold()
        {

        }

        public void DownHold()
        {

        }

        public void LeftHold()
        {
            State.LeftHold();
        }

        public void RightHold()
        {
            State.RightHold();
        }

        public void ActionHold()
        {
            State.ActionHold();
        }

        public void JumpHold()
        {
            if (OnGround)
                State.JumpPress();
        }
        public void SetVaria(bool hasVaria)
        {
            Varia = hasVaria;
            PlayerSpriteFactory.Instance.SetSamusColors(Id, Varia, MissilesOn, ColorScheme);
        }

        public void SetMissile(bool missilesOn)
        {
            if (!HasMissileUpgrade) return;
            MissilesOn = missilesOn;
            PlayerSpriteFactory.Instance.SetSamusColors(Id, Varia, missilesOn, ColorScheme);
        }

        public void TakeDamage(IGameObject source)
        {
            if (_invulnFrames == 0)
            {
                Health -= PlayerConstants.SamusDamageAmt;
                _invulnFrames++;
                if (source.Position.X > Position.X)
                    ApplyForce(new Vector2(-PlayerConstants.SamusKnockbackHor, PlayerConstants.SamusKnockbacVer));
                else
                    ApplyForce(new Vector2(PlayerConstants.SamusKnockbackHor, PlayerConstants.SamusKnockbacVer));
            }
            if (Health <= 0)
            {
                ILevel level = Game1.GetLevel();
                level.Destroy(this);
                ((IPhysicsObject)level.Spawn(new SamusDeathParticle(), Position)).ApplyForce(new Vector2(PlayerConstants.SamusDeathparticleHorFar, -PlayerConstants.SamusDeathparticleVer));
                ((IPhysicsObject)level.Spawn(new SamusDeathParticle(), Position)).ApplyForce(new Vector2(PlayerConstants.SamusDeathparticleHorNear, -PlayerConstants.SamusDeathparticleVer));
                ((IPhysicsObject)level.Spawn(new SamusDeathParticle(), Position)).ApplyForce(new Vector2(-PlayerConstants.SamusDeathparticleHorNear, -PlayerConstants.SamusDeathparticleVer));
                ((IPhysicsObject)level.Spawn(new SamusDeathParticle(), Position)).ApplyForce(new Vector2(-PlayerConstants.SamusDeathparticleHorFar, -PlayerConstants.SamusDeathparticleVer));
                if (level.Players.Any(e => e.Health > 0))
                    level.GetCamera().Focus = level.Players.First(e => e.Health > 0);
                SoundManager.Instance.PlaySong(SoundConstants.SamusDie);

            }
            else
            {
                SoundManager.Instance.PlaySong(SoundConstants.SamusDamage);
            }
        }

        public void RefillEnergy()
        {
            Health += PlayerConstants.SamusRefillAmt;
            if (Health > MaxHealth)
                Health = MaxHealth;
        }

        public void RefillMissiles()
        {
            _missiles += PlayerConstants.SamusRefillAmt;
        }

        public void BecomeGrounded()
        {
            if (!OnGround)
            {
                if (!(State is SamusBallState || State is SamusBallTransformState))
                {
                    State = new SamusStandState(this);
                    Position = new Vector2(Position.X, Position.Y - PlayerConstants.SamusGroundedAdjustment);
                }
            } 
            OnGround = true;
        }

        private void CreateBullet()
        {
            float y;
            float x;


            if (State is SamusStandLookUpState || State is SamusWalkLookUpState)
            {
                y = Position.Y;
                if (FacingRight)
                {
                    x = BoundingBox.X + PlayerConstants.SamusBulletOffsetLookUp;
                }
                else
                {
                    x = BoundingBox.X - PlayerConstants.SamusBulletOffsetLookUp;
                }
            }
            else if(State is SamusJumpingLookUpState)
            {
                y = Position.Y;
                if (FacingRight)
                {
                    x = BoundingBox.X + PlayerConstants.SamusBulletOffsetJumpLookUpFaceRight;
                }
                else
                {
                    x = BoundingBox.X + PlayerConstants.SamusBulletOffsetJumpLookUpFaceLeft;
                }
            }
            else
            {
                y = Position.Y + PlayerConstants.SamusBulletOffsetOtherY;
                if (FacingRight)
                {
                    x = BoundingBox.X + PlayerConstants.SamusBulletOffsetOtherX1 * BoundingBox.Width - PlayerConstants.SamusBulletOffsetOtherX2;
                }
                else
                {
                    x = BoundingBox.X - PlayerConstants.SamusBulletOffsetFaceLeft;
                }
            }
            Game1.GetLevel().Spawn(new Bullet(this), new Vector2(x,y));

        }

        private void CreateMissile()
        {
            float y;
            float x;
            bool isUp = false;


            if (State is SamusStandLookUpState || State is SamusWalkLookUpState)
            {
                
                y = Position.Y;
                if (FacingRight)
                {
                    x = BoundingBox.X + 2;
                }
                else
                {
                    x = BoundingBox.X - 2;
                }
                isUp = true;
            }
            else if (State is SamusJumpingLookUpState)
            {
                y = Position.Y;
                if (FacingRight)
                {
                    x = BoundingBox.X + 9;
                }
                else
                {
                    x = BoundingBox.X - 5;
                }
                isUp = true;
            }
            else
            {
                y = Position.Y + 4;
                if (FacingRight)
                {
                    x = BoundingBox.X + 2 * BoundingBox.Width - 4;
                }
                else
                {
                    x = BoundingBox.X - 10;
                }
            }

            Game1.GetLevel().Spawn(new Missile(this, isUp), new Vector2(x, y));
            _missiles -= 1;
            _missilesFired += 1;
        }

        public void BulletCreationUpdate()
        {

            if (_bulletUpdateCounter == 0)
            {
                CreateBullet();
                SoundManager.Instance.PlaySong(SoundConstants.SamusShoot);
                _timeBulletLastFired = DateTime.Now.TimeOfDay.TotalMilliseconds;
            }
            else
            {
                    if (DateTime.Now.TimeOfDay.TotalMilliseconds - _timeBulletLastFired > 300 && _bulletUpdateCounter > 30)
                    {
                    CreateBullet();
                    SoundManager.Instance.PlaySong(SoundConstants.SamusShoot);
                    _timeBulletLastFired = DateTime.Now.TimeOfDay.TotalMilliseconds;
                    }
                
            }
            _bulletUpdateCounter++;

        }

        public void MissileCreationUpdate()
        {
            if (_missilesFired == 0)
            {
                CreateMissile();
                SoundManager.Instance.PlaySong(SoundConstants.SamusShootRocket);
                _timeMissileLastFired = DateTime.Now.TimeOfDay.TotalMilliseconds;
            }
            else
            {
                if (DateTime.Now.TimeOfDay.TotalMilliseconds - _timeMissileLastFired > 1000)
                {
                    CreateMissile();
                    SoundManager.Instance.PlaySong(SoundConstants.SamusShootRocket);
                    _timeMissileLastFired = DateTime.Now.TimeOfDay.TotalMilliseconds;
                }
            }

        }

        public void CreateBomb()
        {
            Game1.GetLevel().Spawn(new BombInstance(this), new Vector2(Position.X, Position.Y));
        }

        public void BonkBlock()
        {

        }

        public override void Update()
        {
            if (Game1.GetLevel().CurrentWorldState == WorldState.Playing && !CollisionHandler.Instance.BlockedBelow(BoundingBox, PlayerConstants.SamusBlockedBelowClose))
            {
                OnGround = false;
                if (State is SamusStandState || State is SamusWalkState || State is SamusWalkLookUpState || State is SamusWalkShootState || State is SamusStandLookUpState)
                    State = new SamusJumpingState(this);
            }
            if (_invulnFrames > 0)
            {
                _invulnFrames++;
                if (_invulnFrames > _maxInvulnFrames)
                    _invulnFrames = 0;
            }

            if(Health < PlayerConstants.SamusPainSoundThreshhold)
            {
                if (!_startedNearDeathSound)
                {
                    SoundManager.Instance.PlaySong(SoundConstants.SamusPain);
                    _startedNearDeathSound = true;
                }
                else
                {
                    SoundManager.Instance.ResumeSong(SoundConstants.SamusPain);
                }
            }
            else
            {
                SoundManager.Instance.PauseSong(SoundConstants.SamusPain);
            }
            State.Update();
        }

        public override ISprite GetSprite()
        {
            return State.Sprite;
        }

        public void ResetBulletUpdateCounter()
        {
            _bulletUpdateCounter = 0;
        }
    }
}


