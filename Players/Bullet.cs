using CSE3902.Interfaces;
using CSE3902.States.Weapons;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Players
{
    public class Bullet : StandardGameObject
    {
        IPlayer _playerCharacter;
        private readonly IState _state;

        public IPlayer PlayerCharacter {

            get{
                return _playerCharacter;

            }

            set
            {
                _playerCharacter = value;
            }

         
         }

        public float DistanceTraveled { get; set; }

        public Bullet(IPlayer player)
        {
            _playerCharacter = player;
            DistanceTraveled = 0;
            _state = new BulletState(this, _playerCharacter);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _state.Draw(spriteBatch);
        }

        public override void Update()
        {
            _state.Update();
        }

        public override ISprite GetSprite()
        {
            return _state.Sprite;
        }

    }
}
