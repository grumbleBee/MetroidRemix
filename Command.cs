using CSE3902.Interfaces;
using CSE3902.Util;

namespace CSE3902
{
    abstract class Command : ICommandController
    {
        public WorldUtil.WorldState ExecuteAtOrBelowState { get; set; }

        public abstract void BeginExecute(int controllerId);

        public abstract void Execute(int controllerId);

        public abstract void EndExecute(int controllerId);
    }
}
