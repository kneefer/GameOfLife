using System;
using Wtto.GameOfLife.Core.Models;

namespace Wtto.GameOfLife.Core
{
    public interface IGameController
    {
        Board CurrentBoard { get; }
        event EventHandler<BoardChangedEventArgs> BoardChanged;

        void GoToNextEpoch();
    }
}