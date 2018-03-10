namespace CSE3902.Commands.Controller
{
    class CommandRightPress : Command
    {
        public override void BeginExecute(int controllerId)
        {
            Game1.GetLevel().Players[controllerId].RightPress();
        }

        public override void EndExecute(int controllerId)
        {
            Game1.GetLevel().Players[controllerId].RightRelease();
        }

        public override void Execute(int controllerId)
        {
            Game1.GetLevel().Players[controllerId].RightHold();
        }
    }
}
