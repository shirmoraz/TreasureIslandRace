namespace TreasureIslandRace.Models
{
    public abstract class Square
    {
        public int Index { get; }

        protected Square(int index)
        {
            Index = index;
        }

        // הפולימורפיזם של הפרויקט: כל תת-מחלקה מממשת את זה אחרת TODO - delete
        public abstract void ApplyEffect(Player player);

        public abstract string Description { get; }

        public override string ToString() => $"[{Index}] {GetType().Name}: {Description}";
    }
}