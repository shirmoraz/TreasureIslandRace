namespace TreasureIslandRace.Models
{
    public class NormalSquare : Square
    {
        public NormalSquare(int index) : base(index) { }

        public override void ApplyEffect(Player player) { }

        public override string Description => "משבצת רגילה";
    }
}