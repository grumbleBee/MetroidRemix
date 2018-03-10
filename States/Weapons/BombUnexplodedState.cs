using CSE3902.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using CSE3902.Players;
using CSE3902.Effects;
using CSE3902.Sprites.Sprite_Factories;

namespace CSE3902.States.Weapons
{
    class BombUnexplodedState : IState
    {
        public ISprite Sprite { get; set; }

        public BombUnexplodedState(BombInstance bomb)
        {
            Sprite = PlayerSpriteFactory.Instance.CreateBombInstance();
            Sprite.X = (int)bomb.Position.X;
            Sprite.Y = (int)bomb.Position.Y;
            Sprite.Visible = true;
            SoundManager.Instance.PlaySong("bomb_set");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public void Update()
        {

        }
    }
}
