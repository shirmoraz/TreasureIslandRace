namespace TreasureIslandRace.Models
{
    public class TreasureSquare : TurnEffectSquare
    {
        public int CoinAmount { get; }

        public TreasureSquare(int index, int coinAmount = 1) : base(index) => CoinAmount = coinAmount;

        public override void ApplyEffect(Player player) => player.Coins += CoinAmount;

        public override string Description => $"אוצר: +{CoinAmount} מטבעות";
    }
}