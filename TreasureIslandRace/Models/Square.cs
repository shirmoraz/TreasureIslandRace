namespace TreasureIslandRace.Models
{
    public abstract class Square
    {
        public int Index { get; }

        protected Square(int index)
        {
            Index = index;
        }

        public abstract void ApplyEffect(Player player);

        public abstract string Description { get; }

        public override string ToString() => $"[{Index}] {GetType().Name}: {Description}";
    }
}