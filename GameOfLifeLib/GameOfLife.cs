using System.Collections.Generic;

namespace GameOfLifeLib
{
    public static class GameOfLife
    {
        // https://de.wikipedia.org/wiki/Conways_Spiel_des_Lebens

        // bad solution if cells are widely spread over universe because then we iterate over lots of empty cells without eny benefit
        /*
        public static Universe CalculateStep(Universe universe)
        {
            var nextGen = new Universe();
            if (!universe.Cells.Any()) return nextGen;


            var minX = universe.MinX - 1;
            var minY = universe.MinY - 1;
            var maxX = universe.MaxX + 1;
            var maxY = universe.MaxY + 1;

            for (var x = minX; x <= maxX; x++)
            {
                for (var y = minY; y <= maxY; y++)
                {
                    var isAlive = universe.IsCellAlive(x, y);
                    var neighbors = CountNeighbors(universe, x, y);
                    if (CellWillLive(isAlive, neighbors))
                        nextGen.Cells.Add((x, y));
                }
            }

            return nextGen;
        }
        */

        public static Universe CalculateStep(Universe universe)
        {
            if (universe.IsEmpty) return universe;

            var nextGen = new Universe(universe);
            var empties = new Universe();

            // process every living cell
            foreach (var cell in universe.Cells)
            {
                CalculateNewCellState(universe, cell, true, nextGen);
                CollectEmptyNeighbors(universe, cell.X, cell.Y, empties);
            }

            // process every dead neighbor of any living cell
            foreach (var cell in empties.Cells)
            {
                CalculateNewCellState(universe, cell, false, nextGen);
            }

            return nextGen;
        }

        private static void CalculateNewCellState(Universe universe, (long X, long Y) cell, bool isAlive, Universe nextGen)
        {
            var neighborsCount = CountNeighbors(universe, cell.X, cell.Y);
            if (CellWillLive(universe, isAlive, neighborsCount))
                nextGen.Cells.Add(cell);
        }

        private static IEnumerable<(long X, long Y)> SurroundingCells(long cellX, long cellY) => new[]
        {
            (cellX - 1, cellY - 1), (cellX, cellY - 1), (cellX + 1, cellY - 1),
            (cellX - 1, cellY),                         (cellX + 1, cellY),
            (cellX - 1, cellY + 1), (cellX, cellY + 1), (cellX + 1, cellY + 1)
        };

        private static void CollectEmptyNeighbors(Universe universe, long cellX, long cellY, Universe empties)
        {
            foreach (var (x, y) in SurroundingCells(cellX, cellY))
            {
                if(!universe.IsCellAlive(x, y) && !empties.Contains(x, y))
                    empties.Cells.Add((x, y));
            }
        }

        private static bool CellWillLive(Universe universe, bool isAlive, int neighbors)
        {
            return isAlive 
                ? universe.CellStaysAlive(neighbors) 
                : universe.CellComesAlive(neighbors);
        }

        private static int CountNeighbors(Universe universe, long checkX, long checkY)
        {
            var neighbors = 0;
            foreach (var (x, y) in SurroundingCells(checkX, checkY))
            {
                if (universe.Contains(x, y)) neighbors++;
            }

            return neighbors;
        }
    }
}
