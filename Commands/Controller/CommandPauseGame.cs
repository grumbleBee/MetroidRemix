using CSE3902.Interfaces;
using CSE3902.Util;

namespace CSE3902.Commands.Controller
{
    class CommandPauseGame : Command
    {
        public CommandPauseGame()
        {
            ExecuteAtOrBelowState = WorldUtil.WorldState.Paused;
        }

        public override void BeginExecute(int controllerId)
        {
            ILevel level = Game1.GetLevel();

            if (level.CurrentWorldState == WorldUtil.WorldState.Paused)
                Game1.GetLevel().SetWorldState(WorldUtil.WorldState.Playing);
            else
            {
                Game1.GetLevel().SetWorldState(WorldUtil.WorldState.Paused);
                foreach (IPlayer player in level.Players)
                {
                    player.DownRelease();
                    player.UpRelease();
                    player.LeftRelease();
                    player.RightRelease();
                }
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
