namespace CSE3902.Interfaces
{
    interface ICommandCollision
    {
        void Execute(IGameObject gameObject, IGameObject collidedWith);
    }
}
