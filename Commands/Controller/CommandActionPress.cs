using CSE3902.Util;

namespace CSE3902.Commands.Controller
{
    class CommandActionPress : Command
    {
        public CommandActionPress()
        {
            ExecuteAtOrBelowState = WorldUtil.WorldState.Playing;
        }

        public override void BeginExecute(int controllerId)
        {
            Game1.GetLevel().Players[controllerId].ActionPress();
        }

        public override void EndExecute(int controllerId)
        {
            Game1.GetLevel().Players[controllerId].ActionRelease();
        }

        public override void Execute(int controllerId)
        {
            Game1.GetLevel().Players[controllerId].ActionHold();
        }
    }
}
