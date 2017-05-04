using System.Collections.Generic;

namespace Wtto.GameOfLife.Core.Models.Comparers
{
    public class BoardComparer : EqualityComparer<Board>
    {
        public override bool Equals(Board boardX, Board boardY)
        {
            if (boardX == null || boardY == null)
                return false;

            if (boardX.SizeX != boardY.SizeX)
                return false;
            if (boardX.SizeY != boardY.SizeY)
                return false;

            for (int x = 0; x < boardX.SizeX; x++)
            {
                for (int y = 0; y < boardX.SizeY; y++)
                {
                    if (boardX.GetState(x, y) != boardY.GetState(x, y))
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode(Board obj)
        {
            // Not necessary for our needs. We don't have any problems with performance.
            return 1;
        }
    }
}
