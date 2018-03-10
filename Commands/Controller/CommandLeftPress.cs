using CSE3902.Util;

namespace CSE3902.Commands.Controller
{
    class CommandLeftPress : Command
    {

        public CommandLeftPress()
        {
            ExecuteAtOrBelowState = WorldUtil.WorldState.Playing;
        }

        public override void BeginExecute(int controllerId)
        {
            Game1.GetLevel().Players[controllerId].LeftPress();
            
        }

        public override void EndExecute(int controllerId)
        {
            Game1.GetLevel().Players[controllerId].LeftRelease();
        }

        public override void Execute(int controllerId)
        {
            Game1.GetLevel().Players[controllerId].LeftHold();
        }
    }
}
