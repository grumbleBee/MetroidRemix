namespace CSE3902.Interfaces
{
    public interface IController
    {
        void Update();
        void SwapCommandScheme();
        bool Active { get; set; }
        int Id { get; set; }
    }
}
