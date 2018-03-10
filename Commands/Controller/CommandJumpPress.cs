using CSE3902.Util;

namespace CSE3902.Commands.Controller
{
    class CommandJumpPress : Command
    {

        public CommandJumpPress()
        {
            ExecuteAtOrBelowState = WorldUtil.WorldState.Playing;
        }

        public override void BeginExecute(int controllerId)
        {
            Game1.GetLevel().Players[controllerId].JumpPress();
        }

        public override void EndExecute(int controllerId)
        {
            Game1.GetLevel().Players[controllerId].JumpRelease();
        }

        public override void Execute(int controllerId)
        {
            Game1.GetLevel().Players[controllerId].JumpHold();
        }
    }
}
