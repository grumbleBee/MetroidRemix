using CSE3902.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using CSE3902.Players;
using Microsoft.Xna.Framework;
using CSE3902.Effects;
using CSE3902.Sprites.Sprite_Factories;

namespace CSE3902.States.Weapons
{
        class ExplosionState : IState
        {
            readonly BombExplosion _bomb;
            readonly Samus _samus;
            public ISprite Sprite { get; set; }

            public ExplosionState(BombExplosion bomb, IPlayer playerCharacter)
            {
                _bomb = bomb;
                _samus = (Samus)playerCharacter;
                Sprite = PlayerSpriteFactory.Instance.CreateExplosion();
                Sprite.X = (int)bomb.Position.X;
                Sprite.Y = (int)bomb.Position.Y;
                Sprite.Visible = true;
                SoundManager.Instance.PlaySong("bomb_explode");

        }

        public void Draw(SpriteBatch spriteBatch)
            {
                Sprite.Draw(spriteBatch);
            }

            public void Update()
            {
                if (_bomb.BoundingBox.Intersects(_samus.BoundingBox)){
                    _samus.ApplyForce(new Vector2(0, -4));
                }
                if (Sprite.Frame == Sprite.Frames){
                    Game1.GetLevel().Destroy(_bomb);
                }
            }
        }
    }
