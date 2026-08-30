namespace TreasureIslandRace.Models
{
    public class TrapSquare : TurnEffectSquare
    {
        public TrapSquare(int index) : base(index) { }

        public override void ApplyEffect(Player player) => player.MissNextTurn = true;

        public override string Description => "מלכודת: מפספס את התור הבא";
    }
}