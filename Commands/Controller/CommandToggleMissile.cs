using CSE3902.Players;

namespace CSE3902.Commands.Controller
{
    class CommandToggleMissile : Command
    {
        public override void BeginExecute(int controllerId)
        {
            Samus samus = (Samus)Game1.GetLevel().Players[controllerId];
            samus.SetMissile(!samus.MissilesOn);
        }

        public override void EndExecute(int controllerId)
        {

        }

        public override void Execute(int controllerId)
        {

        }
    }
}
