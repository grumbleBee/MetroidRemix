namespace CSE3902.Interfaces
{
    public interface IPlayer : IGameObject
    {
        int Health { get; }
        bool FacingRight { get; }
        bool HasMissileUpgrade { get; }
        int Missiles { get; set; }
        void DownPress();
        void DownRelease();
        void DownHold();
        void UpPress();
        void UpRelease();
        void UpHold();
        void RightPress();
        void RightRelease();
        void RightHold();
        void LeftPress();
        void LeftRelease();
        void LeftHold();
        void ActionPress();
        void ActionRelease();
        void ActionHold();
        void JumpPress();
        void JumpRelease();
        void JumpHold();
        int Id { get; set; }
    }
}
