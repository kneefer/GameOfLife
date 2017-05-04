using Wtto.GameOfLife.Core.Models;

namespace Wtto.GameOfLife.Core.Transformers.Interfaces
{
    public interface ICellTransformer
    {
        Board Board { get; }

        bool GetNextStateOfCell(int x, int y);
    }
}