using CSE3902.Levels;

namespace CSE3902.Commands.Controller
{
    class CommandMenuLeft : Command
    {
        public override void BeginExecute(int controllerId)
        {
            if (!(Game1.GetLevel() is PlayerSelect)) return;
            PlayerSelect level = (PlayerSelect) Game1.GetLevel();
            level.MenuLeft(controllerId);
        }

        public override void Execute(int controllerId)
        {

        }

        public override void EndExecute(int controllerId)
        {

        }
    }
}