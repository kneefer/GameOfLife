using Moq;
using NUnit.Framework;
using Wtto.GameOfLife.Core.Models;
using Wtto.GameOfLife.Core.Transformers;
using Wtto.GameOfLife.Core.Transformers.Interfaces;

namespace Wtto.GameOfLife.Test.Transformers
{
    [TestFixture]
    public class BoardTransformerTest
    {
        [Test]
        public void ShouldGetBoardForNextEpochReturnAppropriateNewBoard()
        {
            // Assign
            var mockedCurrentBoard = new Board(3, 3);
            var expectedNewBoard = new Board(3, 3);
            for (int x = 0; x < expectedNewBoard.SizeX; x++)
            {
                for (int y = 0; y < expectedNewBoard.SizeY; y++)
                {
                    expectedNewBoard.SetAlive(x, y);
                }
            }

            var cellTransformerMock = new Mock<ICellTransformer>();
            cellTransformerMock
                .SetupGet(x => x.Board)
                .Returns(mockedCurrentBoard);
            cellTransformerMock
                .Setup(x => x.GetNextStateOfCell(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(true);

            var cellTransformer = cellTransformerMock.Object;
            var boardTransformer = new BoardTransformer(cellTransformer);

            // Act
            var givenNewBoard = boardTransformer.GetBoardForNextEpoch();

            // Assert
            Assert.AreEqual(expectedNewBoard.SizeX, givenNewBoard.SizeX);
            Assert.AreEqual(expectedNewBoard.SizeY, givenNewBoard.SizeY);

            for (int x = 0; x < expectedNewBoard.SizeX; x++)
            {
                for (int y = 0; y < expectedNewBoard.SizeY; y++)
                {
                    Assert.AreEqual(expectedNewBoard.GetState(x, y), givenNewBoard.GetState(x, y));
                }
            }
        }
    }
}
