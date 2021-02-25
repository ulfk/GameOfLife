using System.Diagnostics.CodeAnalysis;
using System.IO;
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
            var universe = UniverseFactory.GetFromMatrixString(text);
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
            var universe = UniverseFactory.GetFromMatrixString(lines);
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
        public void Universe_IsCellAlive_Succeeds(int x, int y, bool result)
        {
            var universe = new Universe();
            universe.Add(42, 1337);

            universe.IsCellAlive(x, y).Should().Be(result);
        }

        [DataTestMethod]
        [DataRow(42, 1337, true)]
        [DataRow(41, 1337, false)]
        [DataRow(42, 1336, false)]
        [DataRow(41, 1336, false)]
        [DataRow(0, 0, false)]
        [DataRow(123, 321, false)]
        public void Universe_Contains_Succeeds(int x, int y, bool result)
        {
            var universe = new Universe();
            universe.Add(42, 1337);

            universe.Contains(x, y).Should().Be(result);
        }
        
        [TestMethod]
        public void Universe_IsEmpty_Succeeds()
        {
            var universe = new Universe();
            universe.IsEmpty.Should().BeTrue();

            universe.Add(42, 1337);
            universe.IsEmpty.Should().BeFalse();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void Universe_GetFromRleWithInvalidValue_Throws()
        {
            var _ = UniverseFactory.GetFromRleString(new[]
            {
                "#C Hello World",
                "#N Name",
                "x = a, y = 17, rule = S3/B23",
                @"o3b2o$2o3bo!"
            });
        }

        [TestMethod]
        public void Universe_GetFromRle_Succeeds()
        {
            var universe = UniverseFactory.GetFromRleString(new []
            {
                "#C Hello World", 
                "#N Name",
                "x = 12, y = 17, rule = S3/B23", 
                @"o3b2o$2o3bo!"
            });
            universe.Cells.Count.Should().Be(6);
            universe.Contains(0, 0).Should().BeTrue();
            universe.Contains(4, 0).Should().BeTrue();
            universe.Contains(5, 0).Should().BeTrue();
            universe.Contains(0, 1).Should().BeTrue();
            universe.Contains(1, 1).Should().BeTrue();
            universe.Contains(5, 1).Should().BeTrue();
        }

        [TestMethod]
        public void Universe_GetFromRleWithLargeFile_Succeeds()
        {
            var data = @"#N diehard1760.rle
#C http://conwaylife.com/wiki/Die_hard
#C http://www.conwaylife.com/patterns/diehard1760.rle
x = 32, y = 32, rule = B3/S23
bo4bo3bo2bob6obo3b2obo$b2o2bobo3b2o3bobo2bob5o2b2o$obo3bob4o2bo2bobob
4obo2b2o$4bobob2o2b3o4bob2obob2o$2obo2bob2obo2b2o5b3ob2obo$6obo4bo4bob
obobo2bo3bo$bo2bo4b4o2b2obobo6b3obo$b3o3bo2b4o4bobob3obo3bo$b2ob2obobo
2bobo2b2o2b2o4b3o$ob3o2b4o3b2o2b6obob3o$b5o2b4o2bo2bobob2ob2o3bobo$o5b
2obo4bob2o3bo2b2obob2o$ob2obo3b2ob5o2bo3b4obobo$2o4b4o3b2o2b3o4bo3bo2b
o$obo2bo2bob2obob2ob6o3b3o$2o4bo4b2ob4obo2bo2bobo3bo$o3bobo2bo2bob4ob
2o4bo4b2o$2b3o3b6ob2obob2obo2bo2bobo$o2bo3bo4b3o2b2o3b4o4b2o$bobob4o3b
o2b5ob2o3bob2obo$b2obob2o2bo3b2obo4bob2o5bo$obo3b2ob2obobo2bo2b4o2b5o$
2b3obob6o2b2o3b4o2b3obo$2b3o4b2o2b2o2bobo2bobob2ob2o$bo3bob3obobo4b4o
2bo3b3o$ob3o6bobob2o2b4o4bo2bo$bo3bo2bobobobo4bo4bob6o$3bob2ob3o5b2o2b
ob2obo2bob2o$4b2obob2obo4b3o2b2obobo$b2o2bob4obobo2bo2b4obo3bobo$2o2b
5obo2bobo3b2o3bobo2b2o$2bob2o3bob6obo2bo3bo4bo!";

            var universe = UniverseFactory.GetFromRleString(data);
            universe.Cells.Count.Should().Be(496);
            universe.IsCellAlive(1, 0).Should().BeTrue();
        }

        [TestMethod]
        public void Universe_GetFromRleGliderGun_Succeeds()
        {
            var rleData = 
@"x = 36, y = 9, rule = B3/S23
24bo$22bobo$12b2o6b2o12b2o$11bo3bo4b2o12b2o$2o8bo5bo3b2o$2o8bo3bob2o4bobo$10bo5bo7bo$11bo3bo$12b2o!";
            var plainData = 
@"                        x           
                      x x           
            xx      xx            xx
           x   x    xx            xx
xx        x     x   xx              
xx        x   x xx    x x           
          x     x       x           
           x   x                    
            xx                      ";

            var universeFromRle = UniverseFactory.GetFromRleString(rleData);
            var universeFromText = UniverseFactory.GetFromMatrixString(plainData);
            universeFromRle.Should().BeEquivalentTo(universeFromText);
        }

        [TestMethod]
        public void Universe_ToRleString_Succeeds()
        {
            var plainData = new[]
            {
                "xx  x ",
                "  xxxx",
                "    xx",
                " x x x",
                "x x x ",
                "  xx  ",
                "      ",
                "   x  "
            };
            var universe = UniverseFactory.GetFromMatrixString(plainData);
            var rle = universe.ToRleString();
            var result = UniverseFactory.GetFromRleString(rle);
            result.Should().BeEquivalentTo(universe);
        }

        [TestMethod]
        public void Universe_ToRleStringWithEmptyUniverse_Succeeds()
        {
            var universe =new Universe();
            var rle = universe.ToRleString();
            rle.Should().Be("");
        }

        [TestMethod]
        public void Universe_ToMatrixString_Succeeds()
        {
            var plainData = new[]
            {
                "xx  x ",
                "  xxxx",
                "    xx",
                " x x x",
                "x x x ",
                "  xx  ",
                "      ",
                "   x  "
            };
            var universe = UniverseFactory.GetFromMatrixString(plainData);
            var text = universe.ToMatrixString();
            var result = UniverseFactory.GetFromMatrixString(text);
            result.Should().BeEquivalentTo(universe);
        }


        [TestMethod]
        public void Universe_ToMatrixStringWithEmptyUniverse_Succeeds()
        {
            var universe = new Universe();
            var text = universe.ToMatrixString();
            text.Should().Be("");
        }

        [TestMethod]
        public void Universe_ToStringFormString_Succeeds()
        {
            var plainData = new[]
            {
                "xx  x ",
                "  xxxx",
                "    xx",
                " x x x",
                "x x x ",
                "  xx  ",
                "      ",
                "   x  "
            };
            var universe = UniverseFactory.GetFromMatrixString(plainData);
            var text = universe.ToString();
            var result = new Universe(text);
            result.Should().BeEquivalentTo(universe);
        }
        
        [TestMethod]
        public void Universe_ZipUnzipUniverse_Succeeds()
        {
            var plainData = new[]
            {
                "xx  x ",
                "  xxxx",
                "    xx",
                " x x x",
                "x x x ",
                "  xx  ",
                "      ",
                "   x  "
            };
            var universe = UniverseFactory.GetFromMatrixString(plainData);
            var zipped = universe.Zip();
            var result = zipped.UnzipToUniverse();
            result.Should().BeEquivalentTo(universe);
        }

        [TestMethod]
        public void Universe_ZipUnzipEmptyUniverse_Succeeds()
        {
            var universe = new Universe();
            var zipped = universe.Zip();
            var result = zipped.UnzipToUniverse();
            result.Should().BeEquivalentTo(universe);
        }
    }
}