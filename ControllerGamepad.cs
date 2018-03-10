using CSE3902.Commands.Controller;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using CSE3902.Interfaces;

namespace CSE3902
{
    internal class ControllerGamepad : IController
    {
        readonly Dictionary<Buttons, ICommandController> _gameCommands = new Dictionary<Buttons, ICommandController>();
        readonly Dictionary<Buttons, ICommandController> _menuCommands = new Dictionary<Buttons, ICommandController>();
        Dictionary<Buttons, ICommandController> _currentCommands;
        public int Id { get; set;} 
        public bool Active { get; set; }
        private readonly int _controllerNum;
        private GamePadState _oldState;

        public ControllerGamepad(Game1 game, int controllerNum)
        {
            _controllerNum = controllerNum;
            Id = -1;
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
            ICommandController moveCursorUp = new CommandMoveCursorUp();
            ICommandController moveCursorDown = new CommandMoveCursorDown();
            ICommandController menuLeft = new CommandMenuLeft();
            ICommandController menuRight = new CommandMenuRight();

            _oldState = GamePad.GetState(0);
            _gameCommands.Add(Buttons.Back, quit);
            _gameCommands.Add(Buttons.LeftThumbstickDown, downPress);
            _gameCommands.Add(Buttons.DPadDown, downPress);
            _gameCommands.Add(Buttons.LeftThumbstickUp, upPress);
            _gameCommands.Add(Buttons.DPadUp, upPress);
            _gameCommands.Add(Buttons.LeftThumbstickLeft, leftPress);
            _gameCommands.Add(Buttons.DPadLeft, leftPress);
            _gameCommands.Add(Buttons.LeftThumbstickRight, rightPress);
            _gameCommands.Add(Buttons.DPadRight, rightPress);
            _gameCommands.Add(Buttons.A, jumpPress);
            _gameCommands.Add(Buttons.X, actionPress);
            _gameCommands.Add(Buttons.LeftTrigger, toggleVaria);
            _gameCommands.Add(Buttons.RightTrigger, toggleMissile);
            _gameCommands.Add(Buttons.Start, pauseGame);

            _menuCommands.Add(Buttons.Start, menuSelect);
            _menuCommands.Add(Buttons.DPadUp, moveCursorUp);
            _menuCommands.Add(Buttons.LeftThumbstickUp, moveCursorUp);
            _menuCommands.Add(Buttons.DPadDown, moveCursorDown);
            _menuCommands.Add(Buttons.LeftThumbstickDown, moveCursorDown);
            _menuCommands.Add(Buttons.Back, quit);
            _menuCommands.Add(Buttons.A, menuSelect);
            _menuCommands.Add(Buttons.DPadLeft, menuLeft);
            _menuCommands.Add(Buttons.LeftThumbstickLeft, menuLeft);
            _menuCommands.Add(Buttons.DPadRight, menuRight);
            _menuCommands.Add(Buttons.LeftThumbstickRight, menuRight);

            _currentCommands = _menuCommands;
        }

        public void SwapCommandScheme()
        {
            if (_currentCommands == _gameCommands)
                _currentCommands = _menuCommands;
            else
                _currentCommands = _gameCommands;
        }

        public int GetControllerNum()
        {
            return _controllerNum;
        }

        public void Update()
        {
            if (_currentCommands == _gameCommands && Id == -1)
                Active = false;
            if (GamePad.GetState(_controllerNum).IsConnected)
                Active = true;
            if (!Active && _currentCommands == _gameCommands) return;
            GamePadState state = GamePad.GetState(_controllerNum);
            foreach (KeyValuePair<Buttons, ICommandController> pair in _currentCommands)
            {
                if (state.IsButtonDown(pair.Key) && _oldState.IsButtonUp(pair.Key))
                    pair.Value.BeginExecute(Id);
                else if (state.IsButtonDown(pair.Key) && _oldState.IsButtonDown(pair.Key))
                    pair.Value.Execute(Id);
                else if (state.IsButtonUp(pair.Key) && _oldState.IsButtonDown(pair.Key))
                    pair.Value.EndExecute(Id);
            }
            _oldState = state;
        }
    }
}
