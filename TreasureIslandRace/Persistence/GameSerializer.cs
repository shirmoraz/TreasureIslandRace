using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Drawing;
using TreasureIslandRace.Models;
using TreasureIslandRace.Game;

namespace TreasureIslandRace.Persistence
{
    public static class GameSerializer
    {
        public static void Save(string filePath, Board board, List<Player> players, int currentPlayerIndex)
        {
            var data = new GameStateData { CurrentPlayerIndex = currentPlayerIndex };

            foreach (var player in players)
            {
                data.Players.Add(new PlayerData
                {
                    Name = player.Name,
                    ColorArgb = player.TokenColor.ToArgb(),
                    Position = player.Position,
                    Coins = player.Coins,
                    MissNextTurn = player.MissNextTurn,
                    HasExtraTurn = player.HasExtraTurn
                });
            }

            for (int i = 0; i < board.Squares.Count; i++)
                data.Squares.Add(ToSquareData(board.Squares[i]));

            var serializer = new XmlSerializer(typeof(GameStateData));
            using (var writer = new StreamWriter(filePath))
                serializer.Serialize(writer, data);
        }

        public static (List<Player> Players, int CurrentPlayerIndex) Load(string filePath, Board board)
        {
            var serializer = new XmlSerializer(typeof(GameStateData));
            GameStateData data;

            using (var reader = new StreamReader(filePath))
                data = (GameStateData)serializer.Deserialize(reader);

            var players = new List<Player>();
            foreach (var p in data.Players)
            {
                players.Add(new Player(p.Name, Color.FromArgb(p.ColorArgb))
                {
                    Position = p.Position,
                    Coins = p.Coins,
                    MissNextTurn = p.MissNextTurn,
                    HasExtraTurn = p.HasExtraTurn
                });
            }

            foreach (var s in data.Squares)
                board.Squares.ReplaceAt(s.Index, FromSquareData(s));

            return (players, data.CurrentPlayerIndex);
        }

        private static SquareData ToSquareData(Square square)
        {
            switch (square)
            {
                case ShipSquare s: return new SquareData { Index = s.Index, Type = "Ship", Param = s.Steps };
                case WhirlpoolSquare s: return new SquareData { Index = s.Index, Type = "Whirlpool", Param = s.Steps };
                case PortalSquare s: return new SquareData { Index = s.Index, Type = "Portal", Param = s.TargetIndex };
                case TrapSquare s: return new SquareData { Index = s.Index, Type = "Trap" };
                case CompassSquare s: return new SquareData { Index = s.Index, Type = "Compass" };
                case TreasureSquare s: return new SquareData { Index = s.Index, Type = "Treasure", Param = s.CoinAmount };
                default: return new SquareData { Index = square.Index, Type = "Normal" };
            }
        }

        private static Square FromSquareData(SquareData data)
        {
            switch (data.Type)
            {
                case "Ship": return new ShipSquare(data.Index, data.Param);
                case "Whirlpool": return new WhirlpoolSquare(data.Index, data.Param);
                case "Portal": return new PortalSquare(data.Index, data.Param);
                case "Trap": return new TrapSquare(data.Index);
                case "Compass": return new CompassSquare(data.Index);
                case "Treasure": return new TreasureSquare(data.Index, data.Param);
                default: return new NormalSquare(data.Index);
            }
        }
    }
}