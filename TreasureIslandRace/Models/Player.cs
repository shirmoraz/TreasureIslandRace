using System.Drawing;

namespace TreasureIslandRace.Models
{
    public class Player
    {
        public string Name { get; set; }
        public Color TokenColor { get; set; }
        public int Position { get; set; }
        public int Coins { get; set; }
        public bool MissNextTurn { get; set; }
        public bool HasExtraTurn { get; set; }

        public Player(string name, Color tokenColor)
        {
            Name = name;
            TokenColor = tokenColor;
        }
    }
}