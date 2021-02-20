using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public string ToRleString()
        {
            if (IsEmpty) return "";

            var result = new StringBuilder();
            var(xMin,xMax,yMin,yMax) = GetMinMaxValues();
            
            var xDim = 1 + xMax - xMin;
            var yDim = 1 + yMax - yMin;
            var b = string.Join("", NeighborsToComeAlive.Select(x => x.ToString()));
            var s = string.Join("", NeighborsToStayAlive.Select(x => x.ToString()));
            result.AppendLine($"x = {xDim}, y = {yDim}, rule = B{b}/S{s}");

            var line = "";
            for (var y = yMin; y <= yMax; y++)
            {
                var yy = y;
                var cells = Cells.Where(c => c.Y == yy).Select(c => c.X).OrderBy(x => x);
                if (cells.Any())
                {
                    var prevX = xMin - 1;
                    var livingCount = 0;
                    bool firstCell = true;
                    foreach (var x in cells)
                    {
                        if (x - prevX > 1)
                        {
                            var sub = firstCell ? 1 : 0;
                            if (livingCount > 0)
                            {
                                line = AppendWithLengthCheck(line, result, livingCount, true);
                                livingCount = 0;
                                sub = 1;
                            }
                            line = AppendWithLengthCheck(line, result, x - prevX - sub, false);
                        }

                        livingCount++;
                        prevX = x;
                        firstCell = false;
                    }

                    if (livingCount > 0)
                    {
                        line = AppendWithLengthCheck(line, result, livingCount, true);
                    }

                    if (prevX < xMax)
                    {
                        line = AppendWithLengthCheck(line, result, xMax - prevX, false, true);
                    }
                }
                else
                {
                    line = AppendWithLengthCheck(line, result, xDim, false, true);
                }
            }

            if (line.Length > 0) result.Append(line);

            result.Append("!");

            return result.ToString();
        }

        private static string AppendWithLengthCheck(string prevText, StringBuilder result, int count, bool living, bool linebreak = false, int maxLength = 70)
        {
            var newText = $"{(count > 1 ? count.ToString() : "")}{(living ? 'o' : 'b')}{(linebreak ? "$" : "")}";

            if (prevText.Length + newText.Length <= maxLength) return prevText + newText;

            result.AppendLine(prevText);
            return newText;
        }

        public override string ToString()
        {
            if (IsEmpty) return "";

            var (xMin, xMax, yMin, yMax) = GetMinMaxValues();
            var result = new StringBuilder();
            var line = new char[xMax - xMin + 1];

            for (var y = yMin; y <= yMax; y++)
            {
                Array.Fill(line, ' ');
                for (var x = xMin; x <= xMax; x++)
                {
                    if (IsCellAlive(x, y)) line[x - xMin] = 'x';
                }

                result.AppendLine(new string(line));
            }

            return result.ToString();
        }
    }
}