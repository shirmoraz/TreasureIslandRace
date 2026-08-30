using System;

namespace TreasureIslandRace.Models
{
    public class Dice
    {
        private readonly Random random = new Random();

        public int LastRoll { get; private set; }

        public event EventHandler<int> Rolled;

        public int Roll()
        {
            LastRoll = random.Next(1, 7);
            Rolled?.Invoke(this, LastRoll);
            return LastRoll;
        }
    }
}