using System;
using Wtto.GameOfLife.Core.Models;
using Wtto.GameOfLife.Core.Transformers;
using Wtto.GameOfLife.Core.Transformers.Interfaces;

namespace Wtto.GameOfLife.Core
{
    public class GameController : IGameController
    {
        public Board CurrentBoard { get; private set; }
        public event EventHandler<BoardChangedEventArgs> BoardChanged;

        public GameController()
        {
            // Initialize initial game board
            CurrentBoard = new Board(10, 10);

            // Set some initial active cells
            CurrentBoard.SetAlive(3, 5);
            CurrentBoard.SetAlive(5, 3);

            // ...? Play using this class in GUI library
        }

        public void GoToNextEpoch()
        {
            // We could use Ninject, MEF, Unity etc... instead to use DI
            ICellTransformer cellTransformer = new CellTransformer(CurrentBoard);
            IBoardTransformer boardTransformer = new BoardTransformer(cellTransformer);

            var nextEpochBoard = boardTransformer.GetBoardForNextEpoch();
            CurrentBoard = nextEpochBoard;

            BoardChanged?.Invoke(this, new BoardChangedEventArgs(nextEpochBoard));
        }
    }
}
