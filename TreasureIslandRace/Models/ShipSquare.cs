namespace TreasureIslandRace.Models
{
    public class ShipSquare : MovementSquare
    {
        public int Steps { get; }

        public ShipSquare(int index, int steps) : base(index) => Steps = steps;

        public override void ApplyEffect(Player player) => player.Position += Steps;

        public override string Description => $"ספינה: מקדמת {Steps} משבצות";
    }
}