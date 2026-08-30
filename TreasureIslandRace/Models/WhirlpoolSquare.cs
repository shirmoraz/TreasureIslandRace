namespace TreasureIslandRace.Models
{
    public class WhirlpoolSquare : MovementSquare
    {
        public int Steps { get; }

        public WhirlpoolSquare(int index, int steps) : base(index) => Steps = steps;

        public override void ApplyEffect(Player player) => player.Position = Math.Max(0, player.Position - Steps);

        public override string Description => $"מערבולת: מחזירה {Steps} משבצות אחורה";
    }
}