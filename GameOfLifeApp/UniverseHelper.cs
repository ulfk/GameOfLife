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
        public static IList<string> GetListOfUniverses()
        {
            var values = Directory.GetFiles(Directory.GetCurrentDirectory(), BuildFilename("*"))
                .Select(Path.GetFileName)
                .Where(f => f != null)
                .Select(f => f[9..^4])
                .ToList();
            if (!values.Any())
                values.Add("NO FILES FOUND");
            return values;
        }

        public static Universe GetFromFile(string filenamePart)
        {
            var lines = GetFileContent(filenamePart);
            return UniverseFactory.GetFromString(lines);
        }

        private static string BuildFilename(string part) => $"Universe_{part}.txt";

        private static string[] GetFileContent(string filenamePart)
        {
            var filename = BuildFilename(filenamePart);
            try
            {
                return File.ReadAllLines(filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load data from file!\n\n{ex.Message}", "Error");
                return new[] { "" };
            }
        }
    }
}