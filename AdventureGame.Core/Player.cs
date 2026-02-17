using System.Collections.Generic;
using System.Linq;

namespace AdventureGame.Core
{
    public class Player : ICharacter
    {
        // Health is set to 100 by default, but can be increased with potions up to a max of 150
        private const int BaseDamage = 10;
        private const int MaxHealth = 150;

        public int Health { get; private set; } = 100;

        public bool IsAlive => Health > 0;

        public List<Weapon> Inventory { get; } = new List<Weapon>();

        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0)
                Health = 0;
        }

        public int Attack()
        {
            int bestWeaponBonus = Inventory.Count > 0
                ? Inventory.Max(w => w.AttackModifier)
                : 0;

            return BaseDamage + bestWeaponBonus;
        }

        public void Heal(int amount)
        {
            Health += amount;
            if (Health > MaxHealth)
                Health = MaxHealth;
        }

        public void AddWeapon(Weapon weapon)
        {
            Inventory.Add(weapon);
        }
    }
}
