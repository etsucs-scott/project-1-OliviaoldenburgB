namespace AdventureGame.Core
{
// I hope i used the abstract class correctly here, it just seemed like the right way to do it since potions and other items will have different effects but share some common properties
    public abstract class Item
    {
        public string Name { get; }
        public string PickupMessage { get; }

        protected Item(string name, string message)
        {
            Name = name;
            PickupMessage = message;
        }

        public abstract void Apply(Player player);
    }
}
