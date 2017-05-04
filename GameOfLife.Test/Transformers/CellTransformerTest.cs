using System.Linq;
using NUnit.Framework;
using Wtto.GameOfLife.Core.Transformers;
using Wtto.GameOfLife.Test.Helpers;

namespace Wtto.GameOfLife.Test.Transformers
{
    [TestFixture]
    public class CellTransformerTest
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        public void ShouldDieLivingCellWithXLiveNeighbors(int numOfLiveNeighbors)
        {
            // Assign
            var boards = TestHelpers.Get3X3BoardsWithXLiveNeighbors(numOfLiveNeighbors);
            boards.ForEach(x => x.SetAlive(1, 1));
            var celltransformers = boards.Select(x => new CellTransformer(x)).ToList();

            // Act
            var givenStates = celltransformers.Select(x => x.GetNextStateOfCell(1, 1)).ToList();

            // Assert
            givenStates.ForEach(Assert.IsFalse);
        }

        [TestCase(2)]
        [TestCase(3)]
        public void ShouldLiveLivingCellWithXLiveNeighbors(int numOfLiveNeighbors)
        {
            // Assign
            var boards = TestHelpers.Get3X3BoardsWithXLiveNeighbors(numOfLiveNeighbors);
            boards.ForEach(x => x.SetAlive(1, 1));
            var celltransformers = boards.Select(x => new CellTransformer(x)).ToList();

            // Act
            var givenStates = celltransformers.Select(x => x.GetNextStateOfCell(1, 1)).ToList();

            // Assert
            givenStates.ForEach(Assert.IsTrue);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        public void ShouldStayDeadCellWithXLiveNeighbors(int numOfLiveNeighbors)
        {
            // Assign
            var boards = TestHelpers.Get3X3BoardsWithXLiveNeighbors(numOfLiveNeighbors);
            var celltransformers = boards.Select(x => new CellTransformer(x)).ToList();

            // Act
            var givenStates = celltransformers.Select(x => x.GetNextStateOfCell(1, 1)).ToList();

            // Assert
            givenStates.ForEach(Assert.IsFalse);
        }

        [TestCase(3)]
        public void ShouldComeAliveDeadCellWithXLiveNeighbors(int numOfLiveNeighbors)
        {
            // Assign
            var boards = TestHelpers.Get3X3BoardsWithXLiveNeighbors(numOfLiveNeighbors);
            var celltransformers = boards.Select(x => new CellTransformer(x)).ToList();

            // Act
            var givenStates = celltransformers.Select(x => x.GetNextStateOfCell(1, 1)).ToList();

            // Assert
            givenStates.ForEach(Assert.IsTrue);
        }
    }
}
