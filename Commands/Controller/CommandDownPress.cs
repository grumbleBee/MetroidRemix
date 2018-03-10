using CSE3902.Util;

namespace CSE3902.Commands.Controller
{
    class CommandDownPress : Command
    {
        
        public CommandDownPress()
        {
            ExecuteAtOrBelowState = WorldUtil.WorldState.Playing;
        }

        public override void BeginExecute(int controllerId)
        {
            Game1.GetLevel().Players[controllerId].DownPress();
        }

        public override void EndExecute(int controllerId)
        {
            Game1.GetLevel().Players[controllerId].DownRelease();
        }

        public override void Execute(int controllerId)
        {
            Game1.GetLevel().Players[controllerId].DownHold();
        }
    }
}
