namespace CSE3902.Interfaces
{
    public interface ISamusState : IState
    {
        void DownPress();
        void DownRelease();
        void UpPress();
        void UpRelease();
        void RightPress();
        void RightRelease();
        void LeftPress();
        void LeftRelease();
        void ActionPress();
        void ActionRelease();
        void ActionHold();
        void JumpPress();
        void JumpRelease();
        void RightHold();
        void LeftHold();
    }
}
