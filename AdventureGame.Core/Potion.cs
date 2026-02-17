namespace AdventureGame.Core
{
    public class Potion : Item
    {
        public Potion()
            : base("Potion", "You drank a potion and recovered 20 HP!")
        {
        }

        public override void Apply(Player player)
        {
            player.Heal(20);
        }
    }
}
// Heals palyer by 20 HP when used