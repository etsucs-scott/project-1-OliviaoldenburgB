namespace AdventureGame.Core
{
    public class Weapon : Item
    {
        public int AttackModifier { get; }

        public Weapon(string name, int modifier)
            : base(name, $"You picked up {name}!")
        {
            AttackModifier = modifier;
        }

        public override void Apply(Player player)
        {
            player.AddWeapon(this);
        }
    }
}
