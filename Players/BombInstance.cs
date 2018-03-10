using System;
using Microsoft.Xna.Framework.Graphics;
using CSE3902.Interfaces;
using CSE3902.States.Weapons;
using Microsoft.Xna.Framework;

namespace CSE3902.Players
{
    class BombInstance : StandardGameObject
    {
        readonly IPlayer _playerCharacter;
        readonly double _bombTimer;
        private IState State { get; }
        public BombInstance(IPlayer player)
        {
            _playerCharacter = player;
            State = new BombUnexplodedState(this);
            Position = player.Position;
            _bombTimer = DateTime.Now.TimeOfDay.TotalMilliseconds;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch);
        }

        public override void Update()
        {
            State.Update();
            if(DateTime.Now.TimeOfDay.TotalMilliseconds - _bombTimer > 500)
            {
                Game1.GetLevel().Destroy(this);
                Game1.GetLevel().Spawn(new BombExplosion(_playerCharacter), new Vector2(Position.X - 10, Position.Y - 8));
            }
        }

        public override ISprite GetSprite()
        {
            return State.Sprite;
        }
    }
}
