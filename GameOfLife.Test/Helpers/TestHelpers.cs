using System;
using System.Collections.Generic;
using System.Linq;
using Wtto.GameOfLife.Core.Models;
using Wtto.GameOfLife.Core.Models.Comparers;

namespace Wtto.GameOfLife.Test.Helpers
{
    public static class TestHelpers
    {
        public static List<Board> Get3X3BoardsWithXLiveNeighbors(int numOfLiveNeighbors)
        {
            var ranges = new[] { 0, 1, 2 };
            var coordsToCheck = ranges.SelectMany(x => ranges.Select(y => new Tuple<int, int>(x, y)));
            var filteredCoordsToCheck = coordsToCheck.Where(p => !(p.Item1 == 1 && p.Item2 == 1)).ToList();

            var listOfListsOfCoords = GetAllCombinationsOfCoords(filteredCoordsToCheck, numOfLiveNeighbors).ToList();

            var boards = new List<Board>();
            foreach (var listOfCoords in listOfListsOfCoords)
            {
                var board = new Board(3, 3);
                foreach (var coords in listOfCoords)
                {
                    board.SetAlive(coords.Item1, coords.Item2);
                }

                boards.Add(board);
            }

            var distinctedBoards = boards.Distinct(new BoardComparer()).ToList();
            return distinctedBoards;
        }

        private static List<List<Tuple<int, int>>> GetAllCombinationsOfCoords(List<Tuple<int, int>> availableCoords, int recurCountdown)
        {
            var cumulativeList = new List<List<Tuple<int, int>>>();
            recurCountdown--;

            foreach (var coords in availableCoords)
            {
                var newAvailableCoords = availableCoords.Where(p => !(p.Item1 == coords.Item1 && p.Item2 == coords.Item2)).ToList();

                if (recurCountdown > 0)
                {
                    var newListOfListsOfCoords = GetAllCombinationsOfCoords(newAvailableCoords, recurCountdown);
                    cumulativeList.AddRange(newListOfListsOfCoords);

                    foreach (var listOfCoords in newListOfListsOfCoords)
                    {
                        listOfCoords.Insert(0, coords);
                    }
                }
                else
                {
                    var newStepsList = new List<Tuple<int, int>> {coords};
                    cumulativeList.Add(newStepsList);
                }
            }

            return cumulativeList;
        }
    }
}
