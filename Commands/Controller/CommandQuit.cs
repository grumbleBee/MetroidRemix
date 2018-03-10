using CSE3902.Util;

namespace CSE3902.Commands.Controller
{
    class CommandQuit : Command
    {
        private readonly Game1 _game;

        public CommandQuit(Game1 game)
        {
            ExecuteAtOrBelowState = WorldUtil.WorldState.Paused;
            _game = game;
        }

        public override void BeginExecute(int controllerId)
        {
            _game.Exit();
        }

        public override void EndExecute(int controllerId)
        {

        }

        public override void Execute(int controllerId)
        {

        }
    }
}
