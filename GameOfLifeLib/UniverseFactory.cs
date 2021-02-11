
namespace GameOfLifeLib
{
    public static class UniverseFactory
    {
        public static Universe GetFromString(string text)
        {
            var lines = text.Replace("\r", "").Split('\n');
            return GetFromString(lines);
        }

        public static Universe GetFromString(string[] lines)
        {
            var universe = new Universe();
            for (var y = 0; y < lines.Length; y++)
            {
                var line = lines[y];
                for (var x = 0; x < line.Length; x++)
                {
                    if (line[x] != ' ')
                        universe.Cells.Add((x, y));
                }
            }

            return universe;
        }
    }
}