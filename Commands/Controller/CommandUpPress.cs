namespace CSE3902.Commands.Controller
{
    class CommandUpPress : Command
    {
        public override void BeginExecute(int controllerId)
        {
            Game1.GetLevel().Players[controllerId].UpPress();
        }

        public override void EndExecute(int controllerId)
        {
            Game1.GetLevel().Players[controllerId].UpRelease();
        }

        public override void Execute(int controllerId)
        {
            Game1.GetLevel().Players[controllerId].UpHold();
        }
    }
}
