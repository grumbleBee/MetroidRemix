using CSE3902.Interfaces;
using CSE3902.Levels;

namespace CSE3902.Commands.Controller
{
    class CommandMoveCursorDown : Command
    {
        private ILevel _currentLevel;
  
        public CommandMoveCursorDown()
        {
        }

        public override void BeginExecute(int controllerId)
        {
            _currentLevel = Game1.GetLevel();
            if (_currentLevel is Menu)
            {
                ((Menu)_currentLevel).MoveDown();
            } else
            {
                (_currentLevel as PlayerSelect)?.MenuDown(controllerId);
            }
        }

        public override void EndExecute(int controllerId)
        {

        }

        public override void Execute(int controllerId)
        {

        }
    }
}
