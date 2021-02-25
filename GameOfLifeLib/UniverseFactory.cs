using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GameOfLifeLib
{
    public static class UniverseFactory
    {
        public static Universe GetFromMatrixString(string text)
        {
            var lines = text.Replace("\r", "").Split('\n');
            return GetFromMatrixString(lines);
        }

        public static Universe GetFromMatrixString(string[] lines)
        {
            var universe = new Universe();
            for (var y = 0; y < lines.Length; y++)
            {
                var line = lines[y];
                for (var x = 0; x < line.Length; x++)
                {
                    if (line[x] != ' ')
                        universe.Add(x, y);
                }
            }

            return universe;
        }

        public static string ToRleString(this Universe universe)
        {
            if (universe.IsEmpty) return "";

            var result = new StringBuilder();
            var (xMin, xMax, yMin, yMax) = universe.GetMinMaxValues();

            var xDim = 1 + xMax - xMin;
            var yDim = 1 + yMax - yMin;
            var b = string.Join("", universe.NeighborsToComeAlive.Select(x => x.ToString()));
            var s = string.Join("", universe.NeighborsToStayAlive.Select(x => x.ToString()));
            result.AppendLine($"x = {xDim}, y = {yDim}, rule = B{b}/S{s}");

            var line = "";
            for (var y = yMin; y <= yMax; y++)
            {
                var yy = y;
                var cells = universe.Cells.Where(c => c.Y == yy).Select(c => c.X).OrderBy(x => x).ToList();
                if (cells.Any())
                {
                    var prevX = xMin - 1;
                    var livingCount = 0;
                    var firstCell = true;
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

        private static string AppendWithLengthCheck(string prevText, StringBuilder result, int count, bool living, bool linebreak = false, int maxLength = 120)
        {
            var newText = $"{(count > 1 ? count.ToString() : "")}{(living ? 'o' : 'b')}{(linebreak ? "$" : "")}";

            if (prevText.Length + newText.Length <= maxLength) return prevText + newText;

            result.AppendLine(prevText);
            return newText;
        }

        public static string ToMatrixString(this Universe universe)
        {
            if (universe.IsEmpty) return "";

            var (xMin, xMax, yMin, yMax) = universe.GetMinMaxValues();
            var result = new StringBuilder();
            var line = new char[xMax - xMin + 1];

            for (var y = yMin; y <= yMax; y++)
            {
                Array.Fill(line, ' ');
                for (var x = xMin; x <= xMax; x++)
                {
                    if (universe.IsCellAlive(x, y)) line[x - xMin] = 'x';
                }

                result.AppendLine(new string(line));
            }

            return result.ToString();
        }

        public static Universe GetFromRleString(string text)
        {
            var lines = text.Replace("\r", "").Split('\n');
            return GetFromRleString(lines);
        }

        // https://www.conwaylife.com/wiki/Run_Length_Encoded
        // https://codereview.stackexchange.com/questions/149068/parse-run-length-encoded-file-for-cellular-automaton-data
        public static Universe GetFromRleString(string[] lines)
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

                // normal line with encoded data
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
                            universe.Add(x, y);
                        }
                    }
                }

                if (endReached)
                    break;
            }

            return universe;
        }

        public static Universe GetRandom(int percentFilled = 40, int size = 25)
        {
            var universe = new Universe();
            var rand = new Random();
            for (var x = 0; x < size; x++)
            {
                for (var y = 0; y < size; y++)
                {
                    if (rand.Next(100) <= percentFilled) universe.Add(x, y);
                }
            }

            return universe;
        }
        
        public static byte[] Zip(this Universe universe)
        {
            var bytes = Encoding.UTF8.GetBytes(universe.ToString());

            using var msi = new MemoryStream(bytes);
            using var mso = new MemoryStream();
            using (var gs = new GZipStream(mso, CompressionMode.Compress))
            {
                msi.CopyTo(gs);
            }

            return mso.ToArray();
        }

        public static Universe UnzipToUniverse(this byte[] bytes)
        {
            using var msi = new MemoryStream(bytes);
            using var mso = new MemoryStream();
            using (var gs = new GZipStream(msi, CompressionMode.Decompress))
            {
                gs.CopyTo(mso);
            }

            return new Universe(Encoding.UTF8.GetString(mso.ToArray()));
        }
    }
}