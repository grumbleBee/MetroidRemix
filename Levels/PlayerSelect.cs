using System;
using System.Collections.Generic;
using System.Linq;
using CSE3902.Cameras;
using CSE3902.Effects;
using CSE3902.Environment;
using CSE3902.Interfaces;
using CSE3902.Players;
using CSE3902.Sprites.Sprite_Factories;
using CSE3902.States.SamusStates;
using CSE3902.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902.Levels
{
    public class PlayerSelect : ILevel
    {
        public IPlayer[] Players { get; set; }
        public IPhysics Physics { get; set; }
        public WorldUtil.WorldState CurrentWorldState { get; set; }
        private readonly SpriteFont _font;
        public int NumPlayers;
        private string[] _gamePadStrings;
        private readonly List<string[]> _menuStrings = new List<string[]>();
        private readonly List<int> _pointerPositions = new List<int>();
        private readonly List<Cursor> _cursors = new List<Cursor>();
        private readonly List<int[]> _colorSelections = new List<int[]>();
        private readonly List<bool> _playerReady = new List<bool>();

        private readonly List<Color> _helmetColors = new List<Color>()
        {
            new Color(216, 40, 0),
            new Color(216, 168, 0),
            new Color(91, 216, 0),
            new Color(0, 97, 216),
            new Color(137, 0, 216),
            new Color(216, 0, 193)
        };

        private readonly List<Color> _suitColors = new List<Color>()
        {
            new Color(252,152,56),
            new Color(252,250,56),
            new Color(79,252,56),
            new Color(56,252,231),
            new Color(162,56,252),
            new Color(252,56,171),
            new Color(252,56,56)
        };

        private readonly List<Color> _suitAccentColors = new List<Color>()
        {
            new Color(0,148,0),
            new Color(0,139,148),
            new Color(108,0,148),
            new Color(148,0,91),
            new Color(148,0,0),
            new Color(148,77,0),
            new Color(146,148,0)
        };

        private readonly List<Color> _hairColors = new List<Color>()
        {
            new Color(200,76,12),
            new Color(198,200,12),
            new Color(61,200,12),
            new Color(12,200,180),
            new Color(12,52,200),
            new Color(180,12,200),
            new Color(200,12,12)
        };

        private readonly List<Color> _zSuitColors = new List<Color>()
        {
            new Color(228,0,88),
            new Color(228,145,0),
            new Color(220,228,0),
            new Color(86,228,0),
            new Color(0,228,215),
            new Color(0,16,228),
            new Color(172,0,228)
        };

        private readonly List<Color> _zSuitAccentColors = new List<Color>()
        {
            new Color(200,76,12),
            new Color(0, 148, 0),
            new Color(0, 139, 148),
            new Color(108, 0, 148),
            new Color(148, 0, 91),
            new Color(148, 0, 0),
            new Color(148, 77, 0),
            new Color(146, 148, 0)
        };

        public PlayerSelect()
        {
            _font = FontManager.Instance.CreateNewDefaultFont();
        }

        public void LoadContent(LevelLoader levelLoader)
        {
            Players = new IPlayer[4];
            _gamePadStrings = new string[4];
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Destroy(IGameObject gameObject)
        {
            
        }

        public IGameObject Spawn(IGameObject gameObject, Vector2 pos)
        {
            return null;
        }

        public Camera GetCamera()
        {
            return null;
        }

        public void SetCamera(Camera camera)
        {
            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(_font, "PRESS A/JUMP TO JOIN", new Vector2(25, 20), Color.White);
            for (int i = 0; i < _gamePadStrings.Length; i++)
            {
                if (_gamePadStrings[i] != null)
                    spriteBatch.DrawString(_font,_gamePadStrings[i],new Vector2(200 * (i+1) - 170f,120),Color.White);
            }
            for (int playerIndex = 0; playerIndex < NumPlayers; playerIndex++)
            {
                for (int stringIndex = 0; stringIndex < _menuStrings[playerIndex].Length; stringIndex++)
                {
                    if (_menuStrings[playerIndex][stringIndex].Equals("READY") && _playerReady[playerIndex])
                        spriteBatch.DrawString(_font, _menuStrings[playerIndex][stringIndex], new Vector2(200 * playerIndex + 50, 300 + (25 * stringIndex)), Color.Green);
                    else
                        spriteBatch.DrawString(_font, _menuStrings[playerIndex][stringIndex],
                            new Vector2(200 * playerIndex + 50, 300 + (25 * stringIndex)), Color.White);
                }
                Cursor cursor = _cursors[playerIndex];
                cursor.Position = new Vector2(200 * playerIndex + 12, 300 + (25 * _pointerPositions[playerIndex]));
                cursor.Draw(spriteBatch);
            }
            spriteBatch.End();
            spriteBatch.Begin(sortMode: SpriteSortMode.BackToFront, samplerState: SamplerState.PointClamp, transformMatrix: Matrix.CreateScale(4f,4f,1));
            foreach (IVisibleObject player in Players)
                player?.Draw(spriteBatch);
            spriteBatch.End();
        }

        internal void LoadLevel(Game1 game)
        {
            PlayerSpriteFactory.PlayerColorScheme[] schemes = new PlayerSpriteFactory.PlayerColorScheme[NumPlayers];
            int index = 0;
            foreach (Samus player in Players)
            {
                if (player == null) continue;
                schemes[index] = ((Samus) player).ColorScheme;
                index++;
            }
            ILevel multiplayerBrinstar = new MultiplayerBrinstar(NumPlayers, schemes);
            foreach (IController controller in Game1.Controllers)
                controller.SwapCommandScheme();
            game.SetLevel(multiplayerBrinstar);
        }

        public void Select(IController controller, Game1 game)
        {
            if (controller.Id == -1)
            {
                if (NumPlayers < 5)
                {
                    controller.Id = NumPlayers;
                    AddPlayer();
                }
            }
            else
            {
                if (_menuStrings[controller.Id][_pointerPositions[controller.Id]].Equals("READY"))
                {
                    _playerReady[controller.Id] = !_playerReady[controller.Id];
                    if (!_playerReady.Exists(e => !e))
                        LoadLevel(game);
                }
            }
        }

        public void AddPlayer()
        {
            IPlayer newPlayer = new Samus(new Vector2(50 * (NumPlayers+1) - 37, 40), NumPlayers);
            ((Samus) newPlayer).ColorScheme = PlayerSpriteFactory.Instance.DefaultSchemes[NumPlayers];
            ((Samus) newPlayer).State = new SamusStandState((Samus) newPlayer);
            Players[NumPlayers] = newPlayer;
            PlayerSpriteFactory.Instance.SetPlayerToCustomTextures(NumPlayers,PlayerSpriteFactory.Instance.DefaultSchemes[NumPlayers]);
            IController controller = Game1.Controllers.First(e => e.Id == NumPlayers);
            if (controller is ControllerKeyboard)
                _gamePadStrings[NumPlayers] = "KEYBOARD";
            else
                _gamePadStrings[NumPlayers] = "GAMEPAD" + (((ControllerGamepad) controller).GetControllerNum() + 1);
            AddMenuOptions(((Samus)newPlayer).ColorScheme.IsZeroSuit);
            NumPlayers++;
        }

        private void AddMenuOptions(bool zSuit)
        {
            if (!zSuit)
                _menuStrings.Add(new [] {"< Zero Suit >","< Helmet >","< Suit >", "< Accent >", "READY" });
            else
                _menuStrings.Add(new[] { "< Zero Suit >", "< Hair >", "< Suit >", "READY"});
            _pointerPositions.Add(0);
            _cursors.Add(new Cursor(new Vector2()));
            _colorSelections.Add(new [] {0,0,0,0});
            _playerReady.Add(false);
        }

        public void MenuLeft(int playerId)
        {
            if (playerId == -1 || _pointerPositions[playerId] == _menuStrings[playerId].Length - 1) return;
            Samus player = (Samus) Players[playerId];
            PlayerSpriteFactory.PlayerColorScheme newScheme = new PlayerSpriteFactory.PlayerColorScheme()
            {
                AccentMissileColor = player.ColorScheme.AccentMissileColor,
                HelmetColor = player.ColorScheme.HelmetColor,
                AccentBaseColor = player.ColorScheme.AccentBaseColor,
                IsZeroSuit = player.ColorScheme.IsZeroSuit,
                SuitBaseColor = player.ColorScheme.SuitBaseColor,
                SuitVariaColor = player.ColorScheme.SuitVariaColor,
                SuitVariaMissileColor = player.ColorScheme.SuitVariaMissileColor
            };

            int selectedColor = --_colorSelections[playerId][_pointerPositions[playerId]];

            switch (_pointerPositions[playerId])
            {
                case 0:
                    newScheme.IsZeroSuit = !player.ColorScheme.IsZeroSuit;
                    if (newScheme.IsZeroSuit)
                    {
                        _menuStrings[playerId] = new[] { "< Zero Suit >", "< Hair >", "< Suit >", "READY" };
                    }
                    else
                    {
                        _menuStrings[playerId] = new[] { "< Zero Suit >", "< Helmet >", "< Suit >", "< Accent >", "READY" };
                    }
                    break;
                case 1:
                    if (!player.ColorScheme.IsZeroSuit)
                    {
                        if (selectedColor < 0)
                            selectedColor = _helmetColors.Count-1;
                        newScheme.HelmetColor =
                            _helmetColors[selectedColor];
                    }
                    else
                    {
                        if (selectedColor < 0)
                            selectedColor = _hairColors.Count-1;
                        newScheme.HelmetColor =
                            _hairColors[selectedColor];
                    }
                    break;

                case 2:
                    if (!player.ColorScheme.IsZeroSuit)
                    {
                        if (selectedColor < 0)
                            selectedColor = _suitColors.Count - 1;
                        newScheme.SuitBaseColor =
                            _zSuitColors[selectedColor];
                    }
                    else
                    {
                        if (selectedColor < 0)
                            selectedColor = _suitColors.Count-1;
                        newScheme.SuitBaseColor =
                            _suitColors[selectedColor];
                    }
                    break;

                case 3:
                    if (_menuStrings[playerId].Length == 4)
                        break;
                    if (!player.ColorScheme.IsZeroSuit)
                    {
                        if (selectedColor < 0)
                            selectedColor = _zSuitAccentColors.Count-1;
                        newScheme.AccentBaseColor =
                            _zSuitAccentColors[selectedColor];
                    }
                    else
                    {
                        if (selectedColor < 0)
                            selectedColor = _suitAccentColors.Count-1;
                        newScheme.AccentBaseColor =
                            _suitAccentColors[selectedColor];
                    }
                    break;
            }
            _colorSelections[playerId][_pointerPositions[playerId]] = selectedColor;
            player.ColorScheme = newScheme;
            PlayerSpriteFactory.Instance.SetPlayerToCustomTextures(playerId,newScheme);
        }

        public void MenuRight(int playerId)
        {
            if (playerId == -1 || _pointerPositions[playerId] == _menuStrings[playerId].Length-1) return;
            Samus player = (Samus)Players[playerId];
            PlayerSpriteFactory.PlayerColorScheme newScheme = new PlayerSpriteFactory.PlayerColorScheme()
            {
                AccentMissileColor = player.ColorScheme.AccentMissileColor,
                HelmetColor = player.ColorScheme.HelmetColor,
                AccentBaseColor = player.ColorScheme.AccentBaseColor,
                IsZeroSuit = player.ColorScheme.IsZeroSuit,
                SuitBaseColor = player.ColorScheme.SuitBaseColor,
                SuitVariaColor = player.ColorScheme.SuitVariaColor,
                SuitVariaMissileColor = player.ColorScheme.SuitVariaMissileColor
            };

            int selectedColor = ++_colorSelections[playerId][_pointerPositions[playerId]];

            switch (_pointerPositions[playerId])
            {
                case 0:
                    newScheme.IsZeroSuit = !player.ColorScheme.IsZeroSuit;
                    if (newScheme.IsZeroSuit)
                    {
                        _menuStrings[playerId] = new[] {"< Zero Suit >", "< Hair >", "< Suit >", "READY"};
                    }
                    else
                    {
                        _menuStrings[playerId] = new[] { "< Zero Suit >", "< Helmet >", "< Suit >", "< Accent >", "READY" };
                    }
                    break;
                case 1:
                    if (!player.ColorScheme.IsZeroSuit)
                    {
                        if (selectedColor >=
                            _helmetColors.Count)
                            selectedColor = 0;
                        newScheme.HelmetColor =
                            _helmetColors[selectedColor];
                    }
                    else
                    {
                        if (selectedColor >= _hairColors.Count)
                            selectedColor = 0;
                        newScheme.HelmetColor =
                            _hairColors[selectedColor];
                    }
                    break;

                case 2:
                    if (!player.ColorScheme.IsZeroSuit)
                    {
                        if (selectedColor >= _zSuitColors.Count)
                            selectedColor = 0;
                        newScheme.SuitBaseColor =
                            _zSuitColors[selectedColor];
                    }
                    else
                    {
                        if (selectedColor >= _suitColors.Count)
                            selectedColor = 0;
                        newScheme.SuitBaseColor =
                            _suitColors[selectedColor];
                    }
                    break;

                case 3:
                    if (_menuStrings[playerId].Length == 4)
                        break;
                    if (!player.ColorScheme.IsZeroSuit)
                    {
                        if (selectedColor >= _zSuitAccentColors.Count)
                            selectedColor = 0;
                        newScheme.AccentBaseColor =
                            _zSuitAccentColors[selectedColor];
                    }
                    else
                    {
                        if (selectedColor >= _suitAccentColors.Count)
                            selectedColor = 0;
                        newScheme.AccentBaseColor =
                            _suitAccentColors[selectedColor];
                    }
                    break;
            }
            _colorSelections[playerId][_pointerPositions[playerId]] = selectedColor;
            player.ColorScheme = newScheme;
            PlayerSpriteFactory.Instance.SetPlayerToCustomTextures(playerId, newScheme);
        }

        public void MenuUp(int playerId)
        {
            if (playerId == -1) return;
            if (--_pointerPositions[playerId] < 0)
                _pointerPositions[playerId] = 0;
        }

        public void MenuDown(int playerId)
        {
            if (playerId == -1) return;
            if (++_pointerPositions[playerId] >= _menuStrings[playerId].Length)
                _pointerPositions[playerId]--;
        }

        public void UpdateFrames()
        {
            
        }

        public void SetWorldState(WorldUtil.WorldState worldState)
        {
            
        }
    }
}