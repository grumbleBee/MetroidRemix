using CSE3902.Util;

namespace CSE3902.Interfaces
{
    interface ICommandController
    {
        WorldUtil.WorldState ExecuteAtOrBelowState { get; set; }
        void BeginExecute(int controllerId);
        void Execute(int controllerId);
        void EndExecute(int controllerId);
    }
}
