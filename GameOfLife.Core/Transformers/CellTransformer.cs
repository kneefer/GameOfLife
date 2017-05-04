using System;
using System.Linq;
using Wtto.GameOfLife.Core.Models;
using Wtto.GameOfLife.Core.Transformers.Interfaces;

namespace Wtto.GameOfLife.Core.Transformers
{
    public class CellTransformer : ICellTransformer
    {
        public Board Board { get; }

        public CellTransformer(Board board)
        {
            if (board == null)
                throw new InvalidOperationException(
                    $"Cannot initialize {nameof(CellTransformer)} class with {nameof(Board)} of null value");

            Board = board;
        }

        public bool GetNextStateOfCell(int x, int y)
        {
            if (x < 0 || y < 0)
                throw new IndexOutOfRangeException("Cannot refer to item with negative index");
            if(x > Board.SizeX)
                throw new IndexOutOfRangeException($"Cannot refer to index '{x}' since X size of board is {Board.SizeX}");
            if (y > Board.SizeY)
                throw new IndexOutOfRangeException($"Cannot refer to index '{y}' since Y size of board is {Board.SizeY}");

            var currentState = Board.GetState(x, y);
            var numOfLivingNeighbors = GetNumberOfLivingNeighborsOfCell(x, y);

            if (!currentState)
            {
                // Dead cell with exactly 3 live neighbors comes alive
                return numOfLivingNeighbors == 3;
            }

            // Living cell cases
            switch (numOfLivingNeighbors)
            {
                case 0:
                case 1:
                    return false;
                case 2:
                case 3:
                    return true;
                default:
                    return false;
            }
        }

        private int GetNumberOfLivingNeighborsOfCell(int x, int y)
        {
            if(x > Board.SizeX - 1)
                throw new IndexOutOfRangeException($"X parameter is out of range of board X size ({Board.SizeX})");
            if (y > Board.SizeY - 1)
                throw new IndexOutOfRangeException($"Y parameterer is out of range of board Y size ({Board.SizeY})");

            var xranges = new[] {x, x - 1, x + 1};
            var yranges = new[] {y, y - 1, y + 1};

            var coordsToCheck = xranges.SelectMany(xx => yranges.Select(yy => new Tuple<int, int>(xx, yy)));
            var filteredCoordsToCheck = coordsToCheck
                .Where(p => !(p.Item1 == x && p.Item2 == y))
                .Where(p =>
                    p.Item1 >= 0 && p.Item1 < Board.SizeX &&
                    p.Item2 >= 0 && p.Item2 < Board.SizeY)
                .ToList();

            var numOfLivingNeighbors = filteredCoordsToCheck.Count(p => Board.GetState(p.Item1, p.Item2));
            return numOfLivingNeighbors;
        }
    }
}
