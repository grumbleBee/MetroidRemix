using CSE3902.Interfaces;
using CSE3902.Util;

namespace CSE3902.Commands.Controller
{
    public class CommandFullScreen : ICommandController
    {
        public WorldUtil.WorldState ExecuteAtOrBelowState { get; set; } = WorldUtil.WorldState.Paused;
        public void BeginExecute(int controllerId)
        {
            Game1.graphics.ToggleFullScreen();
        }

        public void Execute(int controllerId)
        {
            
        }

        public void EndExecute(int controllerId)
        {
            
        }
    }
}