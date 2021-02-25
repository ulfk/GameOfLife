using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

        public Universe(Universe universe)
        {
            Init(universe.NeighborsToComeAlive, universe.NeighborsToStayAlive);
        }

        public Universe(string text)
        {
            Init();
            FromString(text);
        }

        private void Init(int[] neighborsToComeAlive = null, int[] neighborsToStayAlive = null)
        {
            Cells = new SortedSet<(int X, int Y)>();
            NeighborsToComeAlive = neighborsToComeAlive ?? new[] {3};
            NeighborsToStayAlive = neighborsToStayAlive ?? new[] {2, 3};
        }

        public (int minX, int maxX, int minY, int maxY) GetMinMaxValues()
        {
            return IsEmpty ? (0, 0, 0, 0) : (Cells.Min(c => c.X), Cells.Max(c => c.X), Cells.Min(c => c.Y), Cells.Max(c => c.Y));
        }

        public void ToggleCell(int x, int y)
        {
            if (IsCellAlive(x, y))
                Remove(x, y);
            else
                Add(x, y);
        }

        public void Add(int x, int y) => Cells.Add((x, y));

        public void Add((int, int) cell) => Cells.Add(cell);

        public void Remove(int x, int y) => Cells.Remove((x, y));

        public override string ToString()
        {
            return string.Join(";",Cells.Select(c => $"{c.X},{c.Y}"));
        }

        public void FromString(string values)
        {
            Cells.Clear();
            var matches = Regex.Matches(values, @"((-?\d+)(?:,)(-?\d+))(?:;?)");
            var cells = matches.Select(m => (int.Parse(m.Groups[2].Value), int.Parse(m.Groups[3].Value)));
            foreach (var cell in cells)
            {
                Cells.Add(cell);
            }
        }
    }
}