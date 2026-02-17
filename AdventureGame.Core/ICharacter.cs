namespace AdventureGame.Core
{
    public interface ICharacter
    {
        int Health { get; }
        void TakeDamage(int amount);
        int Attack();
        bool IsAlive { get; }
    }
}
