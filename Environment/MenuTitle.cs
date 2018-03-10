﻿using CSE3902.Interfaces;
using CSE3902.Sprites.Sprite_Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Environment
{
    class MenuTitle : StandardGameObject
    {
        private ISprite Sprite { get; }
        public MenuTitle(Vector2 pos)
        {
            Sprite = EnvironmentSpriteFactory.Instance.CreateMenuTitleSprite();
            Sprite.LayerOrder = 0f;
            Position = pos;
        }

        public override ISprite GetSprite()
        {
            return Sprite;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }
    }
}
