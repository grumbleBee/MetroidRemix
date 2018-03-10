using CSE3902.Interfaces;
using CSE3902.Players;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.States.Weapons
{
    class MissileExplosionState: IState
    {
        readonly MissileExplosion _missileExp;
        public ISprite Sprite { get; set; }

        public MissileExplosionState(MissileExplosion missileExp, Missile missile)
        {
            _missileExp = missileExp;
            Sprite = PlayerSpriteFactory.Instance.CreateExplosion();
            Sprite.X = (int)missile.Position.X;
            Sprite.Y = (int)missile.Position.Y;
            Sprite.Visible = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public void Update()
        {
            if (Sprite.Frame == Sprite.Frames)
            {
                Game1.GetLevel().Destroy(_missileExp);
            }
        }
    }

 
}
