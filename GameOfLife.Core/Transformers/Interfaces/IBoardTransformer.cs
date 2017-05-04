using Wtto.GameOfLife.Core.Models;

namespace Wtto.GameOfLife.Core.Transformers.Interfaces
{
    public interface IBoardTransformer
    {
        Board GetBoardForNextEpoch();
    }
}