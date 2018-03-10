using CSE3902.Players;

namespace CSE3902.Commands.Controller
{
    class CommandToggleVaria : Command
    {
        public override void BeginExecute(int controllerId)
        {
            Samus samus = (Samus)Game1.GetLevel().Players[controllerId];
            samus.SetVaria(!samus.Varia);
        }

        public override void EndExecute(int controllerId)
        {

        }

        public override void Execute(int controllerId)
        {

        }
    }
}
