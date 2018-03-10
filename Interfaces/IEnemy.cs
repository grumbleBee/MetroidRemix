namespace CSE3902.Interfaces
{
    public interface IEnemy : IGameObject
    {
        void Move();
        void TakeDamage();
        void DoItemDrops();
    }
}
