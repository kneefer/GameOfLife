using System;

namespace Wtto.GameOfLife.Core.Models
{
    public class BoardChangedEventArgs : EventArgs
    {
        public Board NewBoard { get; }

        public BoardChangedEventArgs(Board newBoard)
        {
            NewBoard = newBoard;
        }
    }
}