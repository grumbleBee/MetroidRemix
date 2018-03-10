namespace CSE3902.Interfaces
{
    public interface ICrawlerState : IState
    {
        void Move();
        void TurnRed();
    }
}
