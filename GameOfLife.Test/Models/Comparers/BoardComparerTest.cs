using NUnit.Framework;
using Wtto.GameOfLife.Core.Models;
using Wtto.GameOfLife.Core.Models.Comparers;

namespace Wtto.GameOfLife.Test.Models.Comparers
{
    [TestFixture]
    public class BoardComparerTest
    {
        public void ShouldReturnFalseEqualsWhenBoardsDifferSomewhereInArray()
        {
            // Assign
            var boardComparer = new BoardComparer();

            var board1 = new Board(5, 6);
            board1.SetAlive(3,4);
            var board2 = new Board(5, 6);

            // Act
            var result = boardComparer.Equals(board1, board2);

            // Assert
            Assert.False(result);
        }
    }
}
