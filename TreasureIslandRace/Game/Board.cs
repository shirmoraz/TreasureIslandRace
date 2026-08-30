using System;
using TreasureIslandRace.Models;

namespace TreasureIslandRace.Game
{
    public class SquareTriggeredEventArgs : EventArgs
    {
        public Square Square { get; }
        public Player Player { get; }

        public SquareTriggeredEventArgs(Square square, Player player)
        {
            Square = square;
            Player = player;
        }
    }

    public class Board
    {
        public const int TotalSquares = 36;

        public SquareCollection Squares { get; } = new SquareCollection();

        public event EventHandler<SquareTriggeredEventArgs> SpecialSquareTriggered;

        public Board()
        {
            for (int i = 0; i < TotalSquares; i++)
                Squares.Add(new NormalSquare(i));
        }

        public void MovePlayer(Player player, int diceRoll)
        {
            player.Position = Math.Min(player.Position + diceRoll, TotalSquares - 1);

            Square landedSquare = Squares[player.Position];
            landedSquare.ApplyEffect(player);

            if (!(landedSquare is NormalSquare))
                SpecialSquareTriggered?.Invoke(this, new SquareTriggeredEventArgs(landedSquare, player));
        }
    }
}