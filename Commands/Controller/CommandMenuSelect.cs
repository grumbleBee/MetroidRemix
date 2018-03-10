using CSE3902.Interfaces;
using CSE3902.Levels;
using CSE3902.Util;

namespace CSE3902.Commands.Controller
{
    class CommandMenuSelect : Command
    {
        private readonly Game1 _game;
        private readonly IController _controller;

        public CommandMenuSelect(Game1 game, IController controller)
        {
            _controller = controller;
            _game = game;
            ExecuteAtOrBelowState = WorldUtil.WorldState.Paused;
        }

        public override void BeginExecute(int controllerId)
        {
            ILevel level = Game1.GetLevel();
            if (level is Menu)
            {
                ((Menu)level).Select(_game);
            } else if (level is PlayerSelect)
            {
                ((PlayerSelect) level).Select(_controller,_game);
            } else if (level is TitleScreen)
            {
                _game.SetLevel(new Menu());
            }
        }

        public override void EndExecute(int controllerId)
        {

        }

        public override void Execute(int controllerId)
        {

        }
    }
}

