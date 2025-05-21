using NHSNorthumberland.Battleships.Helpers;
using NHSNorthumberland.Battleships.Models;

namespace NHSNorthumberland.Battleships.Test
{
    public class UnitTests
    {
        [Fact]
        public void Test_CoordinatesConversion_D10()
        {
            // X=9, Y=3 -> D10
            var coords = new GridPosition(9, 3);
            var result = GridDisplayHelper.ParseCoordinates("D10");
            Assert.Equal(coords.xCoordinate, result.xCoordinate);
            Assert.Equal(coords.yCoordinate, result.yCoordinate);
        }
    }
}