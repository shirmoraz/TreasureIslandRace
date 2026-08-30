using System.Collections.Generic;

namespace TreasureIslandRace.Persistence
{
    public class GameStateData
    {
        public List<PlayerData> Players { get; set; } = new List<PlayerData>();
        public List<SquareData> Squares { get; set; } = new List<SquareData>();
        public int CurrentPlayerIndex { get; set; }
    }

    public class PlayerData
    {
        public string Name { get; set; }
        public int ColorArgb { get; set; }
        public int Position { get; set; }
        public int Coins { get; set; }
        public bool MissNextTurn { get; set; }
        public bool HasExtraTurn { get; set; }
    }

    public class SquareData
    {
        public int Index { get; set; }
        public string Type { get; set; }
        public int Param { get; set; }
    }
}