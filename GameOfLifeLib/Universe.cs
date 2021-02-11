using System.Collections.Generic;
using System.Linq;

namespace GameOfLifeLib
{
    public class Universe
    {
        public SortedSet<(long X, long Y)> Cells { get; }

        public bool IsCellAlive(long x, long y) => Contains(x, y);

        public bool Contains(long x, long y) => Cells.Contains((x, y)); 

        public bool IsEmpty => !Cells.Any();

        public Universe()
        {
            Cells = new SortedSet<(long X, long Y)>();
        }
    }
}