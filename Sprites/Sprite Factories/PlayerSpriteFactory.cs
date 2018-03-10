using System;
using System.Collections.Generic;
using CSE3902.Interfaces;
using CSE3902.Sprites.Samus;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Sprites.Sprite_Factories
{
   public class PlayerSpriteFactory
    {
        public struct PlayerColorScheme
        {
            public bool IsZeroSuit;
            public Color SuitBaseColor;
            public Color AccentBaseColor;
            public Color SuitVariaColor;
            public Color SuitVariaMissileColor;
            public Color AccentMissileColor;
            public Color HelmetColor;
        }

        private struct Textures
        {
            public Texture2D SamusJumpingSpriteSheet;
            public Texture2D SamusWalkJumpingSpriteSheet;
            public Texture2D SamusRunSpriteSheet;
            public Texture2D SamusStandSpriteSheet;
            public Texture2D SamusTransformSpriteSheet;
            public Texture2D SamusBallSpriteSheet;
            public Texture2D SamusRunLookUpSpriteSheet;
            public Texture2D SamusStandLookUpSpriteSheet;
            public Texture2D SamusRunShootSpriteSheet;
            public Texture2D SamusJumpingShootUpSpriteSheet;
            public Texture2D SamusJumpingShootSpriteSheet;
            public Texture2D BulletSpriteSheet;
            public Texture2D VerticalMissileSpriteSheet;
            public Texture2D HorizontalMissileSpriteSheet;
            public Texture2D DeathParticleSpriteSheet;
            public Texture2D BombSpriteSheet;
            public Texture2D ExplosionSpriteSheet;
            public Texture2D IntroSpriteSheet;
            public List<Texture2D> TextureList;
        }

        private readonly PlayerColorScheme _standardColorScheme = new PlayerColorScheme()
        {
            SuitBaseColor = new Color(252, 152, 56),
            AccentBaseColor = new Color(0, 148, 0),
            SuitVariaColor = new Color(252, 196, 216),
            SuitVariaMissileColor = new Color(244, 120, 252),
            AccentMissileColor = new Color(0, 232, 216),
            HelmetColor = new Color(216,40,0)
        };

        private readonly PlayerColorScheme _zSuitColorScheme = new PlayerColorScheme()
        {
            IsZeroSuit = true,
            SuitBaseColor = new Color(228, 0, 88),
            AccentBaseColor = new Color(200, 76, 12),
            SuitVariaColor = new Color(255, 159, 196),
            SuitVariaMissileColor = new Color(151, 44, 86),
            AccentMissileColor = new Color(61, 239, 255),
            HelmetColor =  new Color(200,76,12)
        };

        private readonly PlayerColorScheme _standardColorSchemePlayer2 = new PlayerColorScheme()
        {
            SuitVariaColor = new Color(227, 56, 252),
            AccentBaseColor = new Color(148, 57, 0),
            SuitBaseColor = new Color(196, 198, 252),
            SuitVariaMissileColor = new Color(120, 209, 252),
            AccentMissileColor = new Color(159, 232, 0),
            HelmetColor = new Color(122,0,216)
        };

        private readonly PlayerColorScheme _zSuitColorSchemePlayer2 = new PlayerColorScheme()
        {
            IsZeroSuit = true,
            SuitBaseColor = new Color(0, 0, 228),
            AccentBaseColor = new Color(148, 12, 200),
            SuitVariaColor = new Color(122, 0, 216),
            SuitVariaMissileColor = new Color(178, 0, 216),
            AccentMissileColor = new Color(240, 60, 222),
            HelmetColor = new Color(148, 12, 200)
        };

        private Textures _defaultTextures;
        private Textures _defaultZSuitTextures;
        private readonly Textures[] _playerTextures = new Textures[4];
        public readonly PlayerColorScheme[] DefaultSchemes;

        public static PlayerSpriteFactory Instance { get; } = new PlayerSpriteFactory();

        private PlayerSpriteFactory()
        {
            DefaultSchemes = new[]
                {_standardColorScheme, _standardColorSchemePlayer2, _zSuitColorScheme, _zSuitColorSchemePlayer2};
        }

        public void LoadAllTextures(GraphicsDevice graphicsDevice, ContentManager content)
        {
            _defaultTextures.SamusRunSpriteSheet = content.Load<Texture2D>("SamusRun");
            _defaultTextures.SamusJumpingSpriteSheet = content.Load<Texture2D>("SamusJump");
            _defaultTextures.SamusStandSpriteSheet = content.Load<Texture2D>("SamusStand");
            _defaultTextures.SamusTransformSpriteSheet = content.Load<Texture2D>("SamusTransform");
            _defaultTextures.SamusBallSpriteSheet = content.Load<Texture2D>("SamusRoll");
            _defaultTextures.SamusWalkJumpingSpriteSheet = content.Load<Texture2D>("SamusWalkJumping");
            _defaultTextures.SamusRunLookUpSpriteSheet = content.Load<Texture2D>("SamusRunLookUp");
            _defaultTextures.SamusStandLookUpSpriteSheet = content.Load<Texture2D>("SamusStandLookUp");
            _defaultTextures.SamusRunShootSpriteSheet = content.Load<Texture2D>("SamusRunShoot");
            _defaultTextures.SamusJumpingShootUpSpriteSheet = content.Load<Texture2D>("SamusJumpAimUp");
            _defaultTextures.SamusJumpingShootSpriteSheet = content.Load<Texture2D>("SamusJumpShoot");
            _defaultTextures.IntroSpriteSheet = content.Load<Texture2D>("SamusIntro");
            _defaultTextures.BulletSpriteSheet = content.Load<Texture2D>("bullet");
            _defaultTextures.VerticalMissileSpriteSheet = content.Load<Texture2D>("verticalMissile");
            _defaultTextures.HorizontalMissileSpriteSheet = content.Load<Texture2D>("horizontalMissile");
            _defaultTextures.DeathParticleSpriteSheet = content.Load<Texture2D>("SamusDeathParticles");
            _defaultTextures.BombSpriteSheet = content.Load<Texture2D>("BombInstance");
            _defaultTextures.ExplosionSpriteSheet = content.Load<Texture2D>("explosion");
            _defaultZSuitTextures.SamusRunSpriteSheet = content.Load<Texture2D>("SamusRunZSuit");
            _defaultZSuitTextures.SamusJumpingSpriteSheet = content.Load<Texture2D>("SamusJumpZSuit");
            _defaultZSuitTextures.SamusStandSpriteSheet = content.Load<Texture2D>("SamusStandZSuit");
            _defaultZSuitTextures.SamusTransformSpriteSheet = content.Load<Texture2D>("SamusTransformZSuit");
            _defaultZSuitTextures.SamusBallSpriteSheet = content.Load<Texture2D>("SamusRollZSuit");
            _defaultZSuitTextures.SamusWalkJumpingSpriteSheet = content.Load<Texture2D>("SamusWalkJumpingZSuit");
            _defaultZSuitTextures.SamusRunLookUpSpriteSheet = content.Load<Texture2D>("SamusRunLookUpZSuit");
            _defaultZSuitTextures.SamusStandLookUpSpriteSheet = content.Load<Texture2D>("SamusStandLookUpZSuit");
            _defaultZSuitTextures.SamusRunShootSpriteSheet = content.Load<Texture2D>("SamusRunShootZSuit");
            _defaultZSuitTextures.SamusJumpingShootUpSpriteSheet = content.Load<Texture2D>("SamusJumpAimUpZSuit");
            _defaultZSuitTextures.SamusJumpingShootSpriteSheet = content.Load<Texture2D>("SamusJumpShoot");
            _defaultZSuitTextures.BulletSpriteSheet = content.Load<Texture2D>("bullet");
            _defaultZSuitTextures.VerticalMissileSpriteSheet = content.Load<Texture2D>("verticalMissile");
            _defaultZSuitTextures.HorizontalMissileSpriteSheet = content.Load<Texture2D>("horizontalMissile");
            _defaultZSuitTextures.DeathParticleSpriteSheet = content.Load<Texture2D>("SamusDeathParticles");
            _defaultZSuitTextures.BombSpriteSheet = content.Load<Texture2D>("BombInstance");
            _defaultZSuitTextures.ExplosionSpriteSheet = content.Load<Texture2D>("explosion");
            _defaultZSuitTextures.IntroSpriteSheet = content.Load<Texture2D>("SamusZSuitIntro");
            
            
            _defaultTextures.TextureList = new List<Texture2D>
            {
                _defaultTextures.SamusRunSpriteSheet,
                _defaultTextures.SamusJumpingSpriteSheet,
                _defaultTextures.SamusStandSpriteSheet,
                _defaultTextures.SamusTransformSpriteSheet,
                _defaultTextures.SamusBallSpriteSheet,
                _defaultTextures.SamusWalkJumpingSpriteSheet,
                _defaultTextures.SamusRunLookUpSpriteSheet,
                _defaultTextures.SamusStandLookUpSpriteSheet,
                _defaultTextures.SamusRunShootSpriteSheet,
                _defaultTextures.SamusJumpingShootUpSpriteSheet,
                _defaultTextures.SamusJumpingShootSpriteSheet,
                _defaultTextures.IntroSpriteSheet
            };
            _defaultZSuitTextures.TextureList = new List<Texture2D>
            {
                _defaultZSuitTextures.SamusRunSpriteSheet,
                _defaultZSuitTextures.SamusJumpingSpriteSheet,
                _defaultZSuitTextures.SamusStandSpriteSheet,
                _defaultZSuitTextures.SamusTransformSpriteSheet,
                _defaultZSuitTextures.SamusBallSpriteSheet,
                _defaultZSuitTextures.SamusWalkJumpingSpriteSheet,
                _defaultZSuitTextures.SamusRunLookUpSpriteSheet,
                _defaultZSuitTextures.SamusStandLookUpSpriteSheet,
                _defaultZSuitTextures.SamusRunShootSpriteSheet,
                _defaultZSuitTextures.SamusJumpingShootUpSpriteSheet,
                _defaultZSuitTextures.SamusJumpingShootSpriteSheet,
                _defaultZSuitTextures.IntroSpriteSheet
            };

            for (int i = 0; i < _playerTextures.Length; i++)
            {
                var textures = new Textures()
                {
                    SamusRunSpriteSheet = new Texture2D(graphicsDevice,_defaultTextures.SamusRunSpriteSheet.Width,_defaultTextures.SamusRunSpriteSheet.Height),
                    SamusJumpingSpriteSheet = new Texture2D(graphicsDevice, _defaultTextures.SamusJumpingSpriteSheet.Width, _defaultTextures.SamusJumpingSpriteSheet.Height),
                    SamusStandSpriteSheet = new Texture2D(graphicsDevice, _defaultTextures.SamusStandSpriteSheet.Width, _defaultTextures.SamusStandSpriteSheet.Height),
                    SamusTransformSpriteSheet = new Texture2D(graphicsDevice, _defaultTextures.SamusTransformSpriteSheet.Width, _defaultTextures.SamusTransformSpriteSheet.Height),
                    SamusBallSpriteSheet = new Texture2D(graphicsDevice, _defaultTextures.SamusBallSpriteSheet.Width, _defaultTextures.SamusBallSpriteSheet.Height),
                    SamusWalkJumpingSpriteSheet = new Texture2D(graphicsDevice, _defaultTextures.SamusWalkJumpingSpriteSheet.Width, _defaultTextures.SamusWalkJumpingSpriteSheet.Height),
                    SamusRunLookUpSpriteSheet = new Texture2D(graphicsDevice, _defaultTextures.SamusRunLookUpSpriteSheet.Width, _defaultTextures.SamusRunLookUpSpriteSheet.Height),
                    SamusStandLookUpSpriteSheet = new Texture2D(graphicsDevice, _defaultTextures.SamusStandLookUpSpriteSheet.Width, _defaultTextures.SamusStandLookUpSpriteSheet.Height),
                    SamusRunShootSpriteSheet = new Texture2D(graphicsDevice, _defaultTextures.SamusRunShootSpriteSheet.Width, _defaultTextures.SamusRunShootSpriteSheet.Height),
                    SamusJumpingShootUpSpriteSheet = new Texture2D(graphicsDevice, _defaultTextures.SamusJumpingShootUpSpriteSheet.Width, _defaultTextures.SamusJumpingShootUpSpriteSheet.Height),
                    SamusJumpingShootSpriteSheet = new Texture2D(graphicsDevice, _defaultTextures.SamusJumpingShootSpriteSheet.Width, _defaultTextures.SamusJumpingShootSpriteSheet.Height),
                    IntroSpriteSheet = new Texture2D(graphicsDevice, _defaultTextures.IntroSpriteSheet.Width, _defaultTextures.IntroSpriteSheet.Height)
                };
                textures.TextureList = new List<Texture2D>
                {
                    textures.SamusRunSpriteSheet,
                    textures.SamusJumpingSpriteSheet,
                    textures.SamusStandSpriteSheet,
                    textures.SamusTransformSpriteSheet,
                    textures.SamusBallSpriteSheet,
                    textures.SamusWalkJumpingSpriteSheet,
                    textures.SamusRunLookUpSpriteSheet,
                    textures.SamusStandLookUpSpriteSheet,
                    textures.SamusRunShootSpriteSheet,
                    textures.SamusJumpingShootUpSpriteSheet,
                    textures.SamusJumpingShootSpriteSheet,
                    textures.IntroSpriteSheet
                };
                _playerTextures[i] = textures;
            }
        }

        public void SetPlayerToCustomTextures(int playerId, PlayerColorScheme scheme)
        {
            Textures textures = _playerTextures[playerId];
            foreach (Texture2D texture in textures.TextureList)
                texture.SetData(new Color[texture.Width*texture.Height]);
            if (!scheme.IsZeroSuit)
            {
                TextureDataReplacement(textures.SamusRunSpriteSheet, _defaultTextures.SamusRunSpriteSheet, scheme,
                    _standardColorScheme);
                TextureDataReplacement(textures.SamusBallSpriteSheet, _defaultTextures.SamusBallSpriteSheet, scheme,
                    _standardColorScheme);
                TextureDataReplacement(textures.SamusJumpingShootSpriteSheet,
                    _defaultTextures.SamusJumpingShootSpriteSheet, scheme, _standardColorScheme);
                TextureDataReplacement(textures.SamusRunLookUpSpriteSheet, _defaultTextures.SamusRunLookUpSpriteSheet,
                    scheme, _standardColorScheme);
                TextureDataReplacement(textures.SamusRunShootSpriteSheet, _defaultTextures.SamusRunShootSpriteSheet,
                    scheme, _standardColorScheme);
                TextureDataReplacement(textures.SamusStandLookUpSpriteSheet,
                    _defaultTextures.SamusStandLookUpSpriteSheet, scheme, _standardColorScheme);
                TextureDataReplacement(textures.SamusTransformSpriteSheet, _defaultTextures.SamusTransformSpriteSheet,
                    scheme, _standardColorScheme);
                TextureDataReplacement(textures.SamusWalkJumpingSpriteSheet,
                    _defaultTextures.SamusWalkJumpingSpriteSheet, scheme, _standardColorScheme);
                TextureDataReplacement(textures.SamusStandSpriteSheet, _defaultTextures.SamusStandSpriteSheet, scheme,
                    _standardColorScheme);
                TextureDataReplacement(textures.SamusJumpingSpriteSheet, _defaultTextures.SamusJumpingSpriteSheet,
                    scheme, _standardColorScheme);
                TextureDataReplacement(textures.SamusJumpingShootUpSpriteSheet,
                    _defaultTextures.SamusJumpingShootUpSpriteSheet, scheme, _standardColorScheme);
                TextureDataReplacement(textures.IntroSpriteSheet, _defaultTextures.IntroSpriteSheet, scheme, _standardColorScheme);
            }
            else
            {
                TextureDataReplacement(textures.SamusRunSpriteSheet, _defaultZSuitTextures.SamusRunSpriteSheet, scheme,
                    _zSuitColorScheme);
                TextureDataReplacement(textures.SamusBallSpriteSheet, _defaultZSuitTextures.SamusBallSpriteSheet, scheme,
                    _zSuitColorScheme);
                TextureDataReplacement(textures.SamusJumpingShootSpriteSheet,
                    _defaultZSuitTextures.SamusJumpingShootSpriteSheet, scheme, _zSuitColorScheme);
                TextureDataReplacement(textures.SamusRunLookUpSpriteSheet, _defaultZSuitTextures.SamusRunLookUpSpriteSheet,
                    scheme, _zSuitColorScheme);
                TextureDataReplacement(textures.SamusRunShootSpriteSheet, _defaultZSuitTextures.SamusRunShootSpriteSheet,
                    scheme, _zSuitColorScheme);
                TextureDataReplacement(textures.SamusStandLookUpSpriteSheet,
                    _defaultZSuitTextures.SamusStandLookUpSpriteSheet, scheme, _zSuitColorScheme);
                TextureDataReplacement(textures.SamusTransformSpriteSheet, _defaultZSuitTextures.SamusTransformSpriteSheet,
                    scheme, _zSuitColorScheme);
                TextureDataReplacement(textures.SamusWalkJumpingSpriteSheet,
                    _defaultZSuitTextures.SamusWalkJumpingSpriteSheet, scheme, _zSuitColorScheme);
                TextureDataReplacement(textures.SamusStandSpriteSheet, _defaultZSuitTextures.SamusStandSpriteSheet, scheme,
                    _zSuitColorScheme);
                TextureDataReplacement(textures.SamusJumpingSpriteSheet, _defaultZSuitTextures.SamusJumpingSpriteSheet,
                    scheme, _zSuitColorScheme);
                TextureDataReplacement(textures.SamusJumpingShootUpSpriteSheet,
                    _defaultZSuitTextures.SamusJumpingShootUpSpriteSheet, scheme, _zSuitColorScheme);
                TextureDataReplacement(textures.IntroSpriteSheet, _defaultZSuitTextures.IntroSpriteSheet, scheme, _zSuitColorScheme);
            }
        }

        public ISprite CreateSamusWalkSprite(int playerId, bool isFacingRight)
        {
            return new SamusWalkSprite(_playerTextures[playerId].SamusRunSpriteSheet, 21, 32, isFacingRight);
        }

        public ISprite CreateSamusStandSprite(int playerId, bool isFacingRight)
        {
            return new SamusStandSprite(_playerTextures[playerId].SamusStandSpriteSheet, 20, 32, isFacingRight);
        }
        public ISprite CreateSamusJumpingSprite(int playerId, bool isFacingRight)
        {
            return new SamusJumpingSprite(_playerTextures[playerId].SamusJumpingSpriteSheet, 21, 32, isFacingRight);
        }

        public ISprite CreateSamusWalkJumpingSprite(int playerId, bool isFacingRight)
        {
            return new SamusWalkJumpingSprite(_playerTextures[playerId].SamusWalkJumpingSpriteSheet, 20, 32,
                isFacingRight);
        }


        public ISprite CreateSamusTransformSprite(int playerId, bool isFacingRight)
        {
            return new SamusTransformSprite(_playerTextures[playerId].SamusTransformSpriteSheet, 20, 32,
                isFacingRight);
        }

        public ISprite CreateSamusBallSprite(int playerId, bool isFacingRight)
        {
            return new SamusBallSprite(_playerTextures[playerId].SamusBallSpriteSheet, 14, 13, isFacingRight);
        }

        public ISprite CreateSamusStandLookUpSprite(int playerId, bool isFacingRight)
        {
            return new SamusStandLookUpSprite(_playerTextures[playerId].SamusStandLookUpSpriteSheet, 20, 38,
                isFacingRight);
        }

        public ISprite CreateSamusWalkLookUp(int playerId, bool isFacingRight)
        {
            return new SamusWalkLookUpSprite(_playerTextures[playerId].SamusRunLookUpSpriteSheet, 20, 38,
                isFacingRight);
        }

        public ISprite CreateSamusWalkShoot(int playerId, bool isFacingRight)
        {
            return new SamusWalkShootSprite(_playerTextures[playerId].SamusRunShootSpriteSheet, 25, 32, isFacingRight);
        }

        public ISprite CreateSamusJumpingShoot(int playerId, bool isFacingRight)
        {
            return new SamusJumpingShootSprite(_playerTextures[playerId].SamusJumpingSpriteSheet, 25, 27,
                isFacingRight);
        }

        public ISprite CreateSamusJumpingLookUp(int playerId, bool isFacingRight)
        {
            return new SamusJumpingShootUpSprite(_playerTextures[playerId].SamusJumpingShootUpSpriteSheet, 21, 41,
                isFacingRight);
        }

        public ISprite CreateBullet(bool isFacingRight)
        {
            return new BulletSprite(_defaultTextures.BulletSpriteSheet, 8, 8, isFacingRight);
        }

        public ISprite CreateVerticalMissile(bool isFacingRight)
        {
            return new MissileSprite(_defaultTextures.VerticalMissileSpriteSheet, 10, 10, isFacingRight);
        }

        public ISprite CreateHorizontalMissile(bool isFacingRight)
        {
            return new MissileSprite(_defaultTextures.HorizontalMissileSpriteSheet, 10, 10, isFacingRight);
        }

        public ISprite CreateBombInstance()
        {
            return new BombInstanceSprite(_defaultTextures.BombSpriteSheet, 16, 16, true);
        }

        public ISprite CreateExplosion()
        {
            return new ExplosionSprite(_defaultTextures.ExplosionSpriteSheet, 32, 32, true);
        }

        public ISprite CreateDeathParticles()
        {
            return new SamusDeathParticlesSprite(_defaultTextures.DeathParticleSpriteSheet, 8, 8, true);
        }

        public ISprite CreateSamusIntro(int playerId)
        {
                return new SamusIntroSprite(_playerTextures[playerId].IntroSpriteSheet, 18, 32);
        }

        private static bool IsSimilar(Color data, Color desired, int rDelta, int gDelta, int bDelta)
        {
            return Math.Abs(data.R - desired.R) < rDelta && Math.Abs(data.G - desired.G) < gDelta && Math.Abs(data.B - desired.B) < bDelta;
        }

        private void TextureDataReplacement(Texture2D toTexture, Texture2D fromTexture, PlayerColorScheme toScheme,
            PlayerColorScheme fromScheme)
        {
            Color[] data = new Color[fromTexture.Width*fromTexture.Height];
            fromTexture.GetData(data);
            data = SchemeReplacement(fromScheme, toScheme, data);
            toTexture.SetData(data);
        }

        private Color[] SchemeReplacement(PlayerColorScheme fromScheme, PlayerColorScheme toScheme,
            Color[] fromData)
        {
            fromData = ColorReplacement(fromScheme.SuitBaseColor, toScheme.SuitBaseColor, fromData);
            fromData = ColorReplacement(fromScheme.HelmetColor, toScheme.HelmetColor, fromData);
            fromData = ColorReplacement(fromScheme.AccentMissileColor, toScheme.AccentMissileColor, fromData);
            return ColorReplacement(fromScheme.AccentBaseColor, toScheme.AccentBaseColor, fromData);
        }

        private Color[] ColorReplacement(Color fromColor, Color toColor, Color[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (IsSimilar(data[i], fromColor, 2, 2, 2))
                    data[i] = toColor;
            }
            return data;
        }

        public void SetSamusColors(int playerId, bool isVariaOn, bool isMissileOn, PlayerColorScheme scheme)
        {
            var accentColor = scheme.AccentBaseColor;
            var suitColor = scheme.SuitBaseColor;
            
            if (isVariaOn)
            {
                if (isMissileOn)
                    suitColor = scheme.SuitVariaMissileColor;
                else
                    suitColor = scheme.SuitVariaColor;
            }
            if (isMissileOn)
                accentColor = scheme.AccentMissileColor;

            foreach (Texture2D texture in _playerTextures[playerId].TextureList)
            {
                Color[] data = new Color[texture.Width * texture.Height];
                texture.GetData(data);

                ColorReplacement(scheme.SuitBaseColor, suitColor, data);
                ColorReplacement(scheme.SuitVariaColor, suitColor, data);
                ColorReplacement(scheme.SuitVariaMissileColor, suitColor, data);
                ColorReplacement(scheme.AccentBaseColor, accentColor, data);
                ColorReplacement(scheme.AccentMissileColor, accentColor, data);

                texture.SetData(data);
            }
        }
    }
}
