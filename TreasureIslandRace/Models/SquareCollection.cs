using System.Collections;
using System.Collections.Generic;

namespace TreasureIslandRace.Models
{
    public class SquareCollection : IEnumerable<Square>
    {
        private readonly List<Square> squares = new List<Square>();

        public int Count => squares.Count;

        public Square this[int index] => squares[index];

        public void Add(Square square) => squares.Add(square);

        public void ReplaceAt(int index, Square newSquare) => squares[index] = newSquare;

        public IEnumerator<Square> GetEnumerator() => squares.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}