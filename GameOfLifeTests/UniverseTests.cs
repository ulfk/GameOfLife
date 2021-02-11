using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using GameOfLifeLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UniverseTests
    {
        [TestMethod]
        public void UniverseFactory_WithText_ReturnsValidUniverse()
        {
            var lines = new[]
            {
                "  x xx x",
                "xxxxxxxx",
                "x       ",
                "        ",
                "       x"
            };
            var text = string.Join('\n', lines);
            var universe = UniverseFactory.GetFromString(text);
            for (var y = 0; y < lines.Length; y++)
            {
                var line = lines[y];
                for (var x = 0; x < line.Length; x++)
                {
                    var shouldBeAlive = line[x] != ' ';
                    var isAlive = universe.IsCellAlive(x, y);
                    shouldBeAlive.Should().Be(isAlive);
                }
            }
        }

        [TestMethod]
        public void UniverseFactory_WithLineArray_ReturnsValidUniverse()
        {
            var lines = new[]
            {
                "  x xx x",
                "xxxxxxxx",
                "x       ",
                "        ",
                "       x"
            };
            var universe = UniverseFactory.GetFromString(lines);
            for (var y = 0; y < lines.Length; y++)
            {
                var line = lines[y];
                for (var x = 0; x < line.Length; x++)
                {
                    var shouldBeAlive = line[x] != ' ';
                    var isAlive = universe.IsCellAlive(x, y);
                    shouldBeAlive.Should().Be(isAlive);
                }
            }
        }

        [DataTestMethod]
        [DataRow(42, 1337, true)]
        [DataRow(41, 1337, false)]
        [DataRow(42, 1336, false)]
        [DataRow(41, 1336, false)]
        [DataRow(0, 0, false)]
        [DataRow(123, 321, false)]
        public void Universe_IsCellAlive_Succeeds(long x, long y, bool result)
        {
            var universe = new Universe();
            universe.Cells.Add((42, 1337));

            universe.IsCellAlive(x, y).Should().Be(result);
        }

        [DataTestMethod]
        [DataRow(42, 1337, true)]
        [DataRow(41, 1337, false)]
        [DataRow(42, 1336, false)]
        [DataRow(41, 1336, false)]
        [DataRow(0, 0, false)]
        [DataRow(123, 321, false)]
        public void Universe_Contains_Succeeds(long x, long y, bool result)
        {
            var universe = new Universe();
            universe.Cells.Add((42, 1337));

            universe.Contains(x, y).Should().Be(result);
        }
        
        [TestMethod]
        public void Universe_IsEmpty_Succeeds()
        {
            var universe = new Universe();
            universe.IsEmpty.Should().BeTrue();

            universe.Cells.Add((42, 1337));
            universe.IsEmpty.Should().BeFalse();
        }
    }
}