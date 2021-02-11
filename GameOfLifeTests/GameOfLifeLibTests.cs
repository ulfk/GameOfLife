using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using GameOfLifeLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class GameOfLifeLibTests
    {
        [TestMethod]
        public void GameOfLife_WithFlipper_Succeeds()
        {
            var startUniverse = UniverseFactory.GetFromString(new[]
            {
                " x ",
                " x ",
                " x "
            });
            var expectedUniverse = UniverseFactory.GetFromString(new[]
            {
                "   ",
                "xxx",
                "   "
            });

            var result = GameOfLife.CalculateStep(startUniverse);
            result.Cells.Should().BeEquivalentTo(expectedUniverse.Cells);
        }
        
        [TestMethod]
        public void GameOfLife_WithExpectedNewborn_Succeeds()
        {
            var startUniverse = UniverseFactory.GetFromString(new[]
            {
                " x ",
                " xx"
            });
            var expectedUniverse = UniverseFactory.GetFromString(new[]
            {
                " xx",
                " xx"
            });

            var result = GameOfLife.CalculateStep(startUniverse);
            result.Cells.Should().BeEquivalentTo(expectedUniverse.Cells);
        }

        [TestMethod]
        public void GameOfLife_WithOvercrowdedDeath_Succeeds()
        {
            var startUniverse = UniverseFactory.GetFromString(new[]
            {
                " x ",
                "xxx",
                " x "
            });
            var expectedUniverse = UniverseFactory.GetFromString(new[]
            {
                "xxx",
                "x x",
                "xxx"
            });

            var result = GameOfLife.CalculateStep(startUniverse);
            result.Cells.Should().BeEquivalentTo(expectedUniverse.Cells);
        }

        [TestMethod]
        public void GameOfLife_With_Succeeds()
        {
            var lines = new[]
            {
                "         xx",
                "         xx",
                "   xx  ",
                "   xx         xx ",
                "              xx",
                "xx",
                "xx"
            };
            var startUniverse = UniverseFactory.GetFromString(lines);

            var result = GameOfLife.CalculateStep(startUniverse);
            result.Cells.Should().BeEquivalentTo(startUniverse.Cells);
        }
    }
}
