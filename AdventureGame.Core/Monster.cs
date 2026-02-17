using System;

namespace AdventureGame.Core
{
    public class Monster : ICharacter
    {
        private const int BaseDamage = 10;

        public int Health { get; private set; }

        public bool IsAlive => Health > 0;

        public Monster(Random random)
        {
            Health = random.Next(30, 51); // 30–50 HP
        }
        // Set at 51 to make it inclusive of 50
        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0)
                Health = 0;
        }

        public int Attack()
        {
            return BaseDamage;
        }
    }
}
