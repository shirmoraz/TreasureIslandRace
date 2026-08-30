namespace TreasureIslandRace.Models
{
    public class CompassSquare : TurnEffectSquare
    {
        public CompassSquare(int index) : base(index) { }

        public override void ApplyEffect(Player player) => player.HasExtraTurn = true;

        public override string Description => "מצפן: תור נוסף";
    }
}