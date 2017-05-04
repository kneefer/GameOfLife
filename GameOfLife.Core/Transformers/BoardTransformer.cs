using System;
using Wtto.GameOfLife.Core.Models;
using Wtto.GameOfLife.Core.Transformers.Interfaces;

namespace Wtto.GameOfLife.Core.Transformers
{
    public class BoardTransformer : IBoardTransformer
    {
        private readonly ICellTransformer _cellTransformer;
        private Board Board => _cellTransformer.Board;

        public BoardTransformer(ICellTransformer cellTransformer)
        {
            if (cellTransformer == null)
                throw new InvalidOperationException(
                    $"Cannot initialize {nameof(BoardTransformer)} class with {nameof(CellTransformer)} of null value");

            _cellTransformer = cellTransformer;
        }

        public Board GetBoardForNextEpoch()
        {
            var nextBoard = new Board(Board.SizeX, Board.SizeY);

            for (int x = 0; x < Board.SizeX; x++)
            {
                for (int y = 0; y < Board.SizeY; y++)
                {
                    var nextStateOfCell = _cellTransformer.GetNextStateOfCell(x, y);
                    if (nextStateOfCell)
                        nextBoard.SetAlive(x, y);
                    else
                        nextBoard.SetDead(x, y);
                }
            }

            return nextBoard;
        }
    }
}
