using System.IO;
using System.Text.RegularExpressions;

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

        public static Universe GetFromRle(string text)
        {
            var lines = text.Replace("\r", "").Split('\n');
            return GetFromRle(lines);
        }

        // https://www.conwaylife.com/wiki/Run_Length_Encoded
        // https://codereview.stackexchange.com/questions/149068/parse-run-length-encoded-file-for-cellular-automaton-data
        public static Universe GetFromRle(string[] lines)
        {
            var universe = new Universe();
            var y = 0;
            var x = 0;
            var endReached = false;
            var lineLength = 0;
            foreach (var line in lines)
            {
                // ignore comments
                if (line.StartsWith("#")) 
                    continue;

                // 'header'-line containing x/y-dimensions and rule for Game of Life
                if (Regex.IsMatch(line, @"(?:x\s?=\s?).+"))
                {   // currently we are only interested in the value of x (the line-length)
                    var match = Regex.Match(line, @"(?:x\s?=\s?)(\d+)(?:,\s?y\s?=\s?)(\d+)(?:,\s?rule\s?=\s?\w)(\d+)(?:\/\w)(\d+)");
                    if (match.Groups.Count != 5 
                        || !int.TryParse(match.Groups[1].Value, out lineLength))
                    {
                        throw new InvalidDataException($"Failed to extract x and y values form this line: '{line}'");
                    }

                    continue;
                }

                var matches = Regex.Matches(line, @"(\d*[bo!\$])");
                foreach (Match match in matches)
                {
                    var num = 1;
                    var type = match.Value[^1..];
                    if (match.Value.Length > 1)
                    {   // get counter
                        num = int.Parse(match.Value[..^1]);
                    }

                    if (type == "$" || x >= lineLength)
                    {   // new line
                        x = 0;
                        y++;
                    }

                    if (type == "b")
                    {   // dead cell(s)
                        x += num;
                    }
                    else if (type == "!")
                    {   // end of transmission
                        endReached = true;
                        break;
                    }
                    else if (type == "o")
                    {   // living cell(s)
                        for (var idx = 0; idx < num; idx++, x++)
                        {
                            universe.Cells.Add((x, y));
                        }
                    }
                }

                if (endReached)
                    break;
            }

            return universe;
        }
    }
}