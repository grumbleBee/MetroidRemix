using CSE3902.Interfaces;
using CSE3902.States.Weapons;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Players
{
    public class Missile : StandardGameObject
    {
        IPlayer _playerCharacter;
        private readonly IState _state;

        public bool IsUp { get; }

        public IPlayer PlayerCharacter
        {

            get
            {
                return _playerCharacter;

            }

            set
            {
                _playerCharacter = value;
            }


        }

        public float DistanceTraveled { get; set; }

        public Missile(IPlayer player, bool isUp)
        {
            _playerCharacter = player;
            DistanceTraveled = 0;
            IsUp = isUp;
            _state = new MissileState(this, _playerCharacter);
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
