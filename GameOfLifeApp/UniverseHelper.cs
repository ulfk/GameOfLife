using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GameOfLifeLib;

namespace GameOfLifeApp
{
    public static class UniverseHelper
    {
        private const string DataDir = "data";

        public static IList<string> GetListOfUniverses()
        {
            var dataDir = Path.Combine(Directory.GetCurrentDirectory(), DataDir);
            var files = Directory.GetFiles(dataDir, BuildFilename("*")).ToList();
            files.AddRange(Directory.GetFiles(dataDir, BuildFilename("*", true)));
            var values = files
                .Select(Path.GetFileName)
                .Where(f => f != null)
                .Select(f => f[9..^4])
                .OrderBy(f => f)
                .ToList();

            if (!values.Any())
                values.Add("NO FILES FOUND");
            return values;
        }

        public static Universe GetFromFile(string filenamePart)
        {
            var (lines,isRle) = GetFileContent(filenamePart);
            return isRle ? UniverseFactory.GetFromRle(lines) : UniverseFactory.GetFromString(lines);
        }

        private static string BuildFilename(string part, bool isRle = false) => $"Universe_{part}.{(isRle ? "rle" : "txt")}";

        private static (string[] lines,bool isRle) GetFileContent(string filenamePart)
        {
            string[] result = null;
            var message = "";
            var isRleFormat = false;

            foreach (var isRle in new []{false, true})
            {
                try
                {
                    var filename = Path.Combine(DataDir, BuildFilename(filenamePart, isRle));
                    result = File.ReadAllLines(filename);
                    isRleFormat = isRle;
                    break;
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
            }

            if (result != null) return (result, isRleFormat);

            MessageBox.Show($"Failed to load data from file!\n\n{message}", "Error");
            return (new[] { "" }, isRleFormat);
        }
    }
}