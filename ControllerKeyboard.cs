using CSE3902.Commands.Controller;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using CSE3902.Interfaces;

namespace CSE3902
{
    class ControllerKeyboard : IController
    {
        readonly Dictionary<Keys, ICommandController> _gameCommands = new Dictionary<Keys, ICommandController>();
        readonly Dictionary<Keys, ICommandController> _menuCommands = new Dictionary<Keys, ICommandController>();
        public int Id { get; set; }
        public bool Active { get; set; }
        private Dictionary<Keys, ICommandController> _currentCommands;
        private KeyboardState _oldState;

        public ControllerKeyboard(Game1 game)
        {
            Id = -1;
            Active = true;
            ICommandController quit = new CommandQuit(game);
            ICommandController downPress = new CommandDownPress();
            ICommandController upPress = new CommandUpPress();
            ICommandController leftPress = new CommandLeftPress();
            ICommandController rightPress = new CommandRightPress();
            ICommandController actionPress = new CommandActionPress();
            ICommandController jumpPress = new CommandJumpPress();
            ICommandController toggleVaria = new CommandToggleVaria();
            ICommandController toggleMissile = new CommandToggleMissile();
            ICommandController menuSelect = new CommandMenuSelect(game,this);
            ICommandController pauseGame = new CommandPauseGame();
            ICommandController fullScreen = new CommandFullScreen();
            ICommandController moveCursorUp = new CommandMoveCursorUp();
            ICommandController moveCursorDown = new CommandMoveCursorDown();
            ICommandController cheatUpgrades = new CommandGiveAllPowerUps();
            ICommandController menuLeft = new CommandMenuLeft();
            ICommandController menuRight = new CommandMenuRight();

            _oldState = Keyboard.GetState();

            _gameCommands.Add(Keys.Q, quit);
            _gameCommands.Add(Keys.S, downPress);
            _gameCommands.Add(Keys.Down, downPress);
            _gameCommands.Add(Keys.W, upPress);
            _gameCommands.Add(Keys.Up, upPress);
            _gameCommands.Add(Keys.A, leftPress);
            _gameCommands.Add(Keys.Left, leftPress);
            _gameCommands.Add(Keys.D, rightPress);
            _gameCommands.Add(Keys.Right, rightPress);
            _gameCommands.Add(Keys.J, jumpPress);
            _gameCommands.Add(Keys.X, jumpPress);
            _gameCommands.Add(Keys.K, actionPress);
            _gameCommands.Add(Keys.Z, actionPress);
            _gameCommands.Add(Keys.V, toggleVaria);
            _gameCommands.Add(Keys.M, toggleMissile);
            _gameCommands.Add(Keys.Escape, pauseGame);
            _gameCommands.Add(Keys.F, fullScreen);
            _gameCommands.Add(Keys.P, cheatUpgrades);

            _menuCommands.Add(Keys.F,fullScreen);
            _menuCommands.Add(Keys.Space, menuSelect);
            _menuCommands.Add(Keys.Enter, menuSelect);
            _menuCommands.Add(Keys.Q, quit);
            _menuCommands.Add(Keys.Up, moveCursorUp);
            _menuCommands.Add(Keys.W, moveCursorUp);
            _menuCommands.Add(Keys.Down, moveCursorDown);
            _menuCommands.Add(Keys.S, moveCursorDown);
            _menuCommands.Add(Keys.J, menuSelect);
            _menuCommands.Add(Keys.X, menuSelect);
            _menuCommands.Add(Keys.A,menuLeft);
            _menuCommands.Add(Keys.Left,menuLeft);
            _menuCommands.Add(Keys.D, menuRight);
            _menuCommands.Add(Keys.Right,menuRight);
           
            _currentCommands = _menuCommands;
        }

        public void SwapCommandScheme()
        {
            if (_currentCommands == _gameCommands)
                _currentCommands = _menuCommands;
            else
                _currentCommands = _gameCommands;
        }

        public void Update()
        {
            if (_currentCommands == _gameCommands && Id == -1)
                Active = false;
            if (!Active && _currentCommands == _gameCommands) return;
            KeyboardState state = Keyboard.GetState();
            foreach (KeyValuePair<Keys,ICommandController> pair in _currentCommands)
            {
                if (pair.Value.ExecuteAtOrBelowState < Game1.GetLevel().CurrentWorldState) continue;

                if (state.IsKeyDown(pair.Key) && _oldState.IsKeyUp(pair.Key))
                    pair.Value.BeginExecute(Id);
                else if (state.IsKeyDown(pair.Key) && _oldState.IsKeyDown(pair.Key))
                    pair.Value.Execute(Id);
                else if (state.IsKeyUp(pair.Key) && _oldState.IsKeyDown(pair.Key))
                    pair.Value.EndExecute(Id);
            }
            _oldState = state;
        }
    }
}
