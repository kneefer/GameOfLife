using System;

namespace Wtto.GameOfLife.Core.Models
{
    public class Board
    {
        private const int MinX = 3;
        private const int MinY = 3;

        public int SizeX { get; }
        public int SizeY { get; }

        private readonly bool[][] _cells;

        public Board(int sizeX, int sizeY)
        {
            if(sizeX < MinX)
                throw new InvalidOperationException($"{nameof(Board)} X size cannot be less than {MinX}");
            if (sizeY < MinY)
                throw new InvalidOperationException($"{nameof(Board)} Y size cannot be less than {MinY}");

            SizeX = sizeX;
            SizeY = sizeY;

            _cells = new bool[sizeX][];
            for (int i = 0; i < sizeX; i++)
            {
                _cells[i] = new bool[sizeY];
            }
        }

        public void SetAlive(int x, int y)
        {
            ThrowIfOutOfRange(x, y);
            _cells[x][y] = true;
        }

        public void SetDead(int x, int y)
        {
            ThrowIfOutOfRange(x, y);
            _cells[x][y] = false;
        }

        public bool GetState(int x, int y)
        {
            ThrowIfOutOfRange(x, y);
            return _cells[x][y];
        }

        private void ThrowIfOutOfRange(int x, int y)
        {
            if(x < 0)
                throw new IndexOutOfRangeException($"X coordinate is negative: {x}");
            if (y < 0)
                throw new IndexOutOfRangeException($"Y coordinate is negative: {x}");
            if(x > SizeX - 1)
                throw new IndexOutOfRangeException($"X coordinate ({x}) exceeds actual ({SizeX}) X dimension");
            if (y > SizeY - 1)
                throw new IndexOutOfRangeException($"Y coordinate ({y}) exceeds actual ({SizeY}) Y dimension");
        }
    }
}
