using CSE3902.Interfaces;
using CSE3902.Levels;

namespace CSE3902.Commands.Controller
{
    class CommandMoveCursorUp : Command
    {
        private ILevel _currentLevel;

        public CommandMoveCursorUp()
        {
        }

        public override void BeginExecute(int controllerId)
        {
            _currentLevel = Game1.GetLevel();
            if (_currentLevel is Menu)
            {
                ((Menu)_currentLevel).MoveUp();
            }
            else
            {
                (_currentLevel as PlayerSelect)?.MenuUp(controllerId);
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
