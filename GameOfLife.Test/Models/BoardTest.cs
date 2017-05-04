using System;
using NUnit.Framework;
using Wtto.GameOfLife.Core.Models;

namespace Wtto.GameOfLife.Test.Models
{
    [TestFixture]
    public class BoardTest
    {
        [Test]
        public void ShouldThrowErrorIfOneOfDimensionsIsLessThan3()
        {
            // Assign
            const int xSize = 2;
            const int ySize = 3;

            // Act
            Board board = null;
            Assert.Throws<InvalidOperationException>(() => board = new Board(xSize, ySize));

            // Assert
            Assert.IsNull(board);
        }

        [Test]
        public void ShouldInitializeAllCellsWithNulls()
        {
            // Assign
            const int xSize = 5;
            const int ySize = 6;

            // Act
            var board = new Board(xSize, ySize);

            // Assert
            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    bool state = true;
                    Assert.DoesNotThrow(() => state = board.GetState(x, y));
                    Assert.IsFalse(state);
                }
            }
        }

        [Test]
        public void ShouldThrowExceptionIfGetsStateOutOfRange()
        {
            // Assign
            const int xSize = 5;
            const int ySize = 6;

            // Act
            var board = new Board(xSize, ySize);

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => board.GetState(5, 6));
        }
    }
}
