using System.Collections.Generic;
using System.Linq;

namespace GameOfLifeLib
{
    public class Universe
    {
        public SortedSet<(int X, int Y)> Cells { get; private set; }

        public bool IsCellAlive(int x, int y) => Contains(x, y);

        public bool Contains(int x, int y) => Cells.Contains((x, y)); 

        public bool IsEmpty => !Cells.Any();

        public int LivingCellsCount => Cells.Count;

        public bool CellComesAlive(int neighbors) => NeighborsToComeAlive.Contains(neighbors);

        public bool CellStaysAlive(int neighbors) => NeighborsToStayAlive.Contains(neighbors);

        public int[] NeighborsToComeAlive { get; private set; }

        public int[] NeighborsToStayAlive { get; private set; }

        public Universe()
        {
            Init();
        }

        public Universe(int[] neighborsToComeAlive, int[] neighborsToStayAlive)
        {
            Init(neighborsToComeAlive, neighborsToStayAlive);
        }

        public Universe(Universe universe)
        {
            Init(universe.NeighborsToComeAlive, universe.NeighborsToStayAlive);
        }

        private void Init(int[] neighborsToComeAlive = null, int[] neighborsToStayAlive = null)
        {
            Cells = new SortedSet<(int X, int Y)>();
            NeighborsToComeAlive = neighborsToComeAlive ?? new[] {3};
            NeighborsToStayAlive = neighborsToStayAlive ?? new[] {2, 3};
        }

        public (int minX, int maxX, int minY, int maxY) GetDimensions()
        {
            return (Cells.Min(c => c.X), Cells.Max(c => c.X), Cells.Min(c => c.Y), Cells.Max(c => c.Y));
        }
    }
}