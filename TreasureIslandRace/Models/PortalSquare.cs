namespace TreasureIslandRace.Models
{
    public class PortalSquare : MovementSquare
    {
        public int TargetIndex { get; }

        public PortalSquare(int index, int targetIndex) : base(index) => TargetIndex = targetIndex;

        public override void ApplyEffect(Player player) => player.Position = TargetIndex;

        public override string Description => $"פורטל: קופץ למשבצת {TargetIndex}";
    }
}