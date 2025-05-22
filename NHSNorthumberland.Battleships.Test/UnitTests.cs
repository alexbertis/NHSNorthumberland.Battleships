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

        [Theory]
        [InlineData(ShipTypeEnum.Battleship, 0, 0, OrientationEnum.Horizontal)]
        [InlineData(ShipTypeEnum.Battleship, 1, 0, OrientationEnum.Horizontal)]
        [InlineData(ShipTypeEnum.Battleship, 2, 0, OrientationEnum.Horizontal)]
        [InlineData(ShipTypeEnum.Battleship, 3, 0, OrientationEnum.Horizontal)]
        [InlineData(ShipTypeEnum.Battleship, 4, 0, OrientationEnum.Horizontal)]
        [InlineData(ShipTypeEnum.Battleship, 0, 0, OrientationEnum.Vertical)]
        [InlineData(ShipTypeEnum.Battleship, 1, 0, OrientationEnum.Vertical)]
        [InlineData(ShipTypeEnum.Battleship, 2, 0, OrientationEnum.Vertical)]
        [InlineData(ShipTypeEnum.Battleship, 3, 0, OrientationEnum.Vertical)]
        [InlineData(ShipTypeEnum.Battleship, 4, 0, OrientationEnum.Vertical)]
        [InlineData(ShipTypeEnum.Destroyer, 0, 0, OrientationEnum.Horizontal)]
        [InlineData(ShipTypeEnum.Destroyer, 1, 0, OrientationEnum.Horizontal)]
        [InlineData(ShipTypeEnum.Destroyer, 2, 0, OrientationEnum.Horizontal)]
        [InlineData(ShipTypeEnum.Destroyer, 3, 0, OrientationEnum.Horizontal)]
        [InlineData(ShipTypeEnum.Destroyer, 4, 0, OrientationEnum.Horizontal)]
        [InlineData(ShipTypeEnum.Destroyer, 0, 0, OrientationEnum.Vertical)]
        [InlineData(ShipTypeEnum.Destroyer, 1, 0, OrientationEnum.Vertical)]
        [InlineData(ShipTypeEnum.Destroyer, 2, 0, OrientationEnum.Vertical)]
        [InlineData(ShipTypeEnum.Destroyer, 3, 0, OrientationEnum.Vertical)]
        [InlineData(ShipTypeEnum.Destroyer, 4, 0, OrientationEnum.Vertical)]
        public void Test_Collision_ShouldDetectCollision1(ShipTypeEnum secondShipType, int startX, int startY, OrientationEnum secondShipOrientation)
        {
            var ship1 = new ShipModel(ShipTypeEnum.Battleship, (0, 0), OrientationEnum.Horizontal);
            var ship2 = new ShipModel(secondShipType, (startX, startY), secondShipOrientation);

            Assert.True(ship1.CollidesWith(ship2));
            Assert.True(ship2.CollidesWith(ship1));
        }

        [Theory]
        [InlineData(ShipTypeEnum.Battleship, 2, 6, OrientationEnum.Horizontal)]
        [InlineData(ShipTypeEnum.Battleship, 4, 6, OrientationEnum.Horizontal)]
        [InlineData(ShipTypeEnum.Battleship, 6, 6, OrientationEnum.Horizontal)]
        [InlineData(ShipTypeEnum.Battleship, 8, 6, OrientationEnum.Horizontal)]
        [InlineData(ShipTypeEnum.Battleship, 9, 6, OrientationEnum.Horizontal)]
        [InlineData(ShipTypeEnum.Battleship, 6, 6, OrientationEnum.Vertical)]
        [InlineData(ShipTypeEnum.Battleship, 8, 6, OrientationEnum.Vertical)]
        [InlineData(ShipTypeEnum.Battleship, 9, 6, OrientationEnum.Vertical)]
        [InlineData(ShipTypeEnum.Battleship, 5, 2, OrientationEnum.Vertical)]
        [InlineData(ShipTypeEnum.Battleship, 5, 3, OrientationEnum.Vertical)]
        [InlineData(ShipTypeEnum.Battleship, 5, 4, OrientationEnum.Vertical)]
        public void Test_Collision_ShouldDetectCollision2(ShipTypeEnum secondShipType, int startX, int startY, OrientationEnum secondShipOrientation)
        {
            var ship1 = new ShipModel(ShipTypeEnum.Battleship, (5, 6), OrientationEnum.Horizontal);
            var ship2 = new ShipModel(secondShipType, (startX, startY), secondShipOrientation);

            Assert.True(ship1.CollidesWith(ship2));
            Assert.True(ship2.CollidesWith(ship1));
        }

        [Theory]
        [InlineData(ShipTypeEnum.Battleship, 0, 6, OrientationEnum.Horizontal)]
        [InlineData(ShipTypeEnum.Battleship, 10, 6, OrientationEnum.Horizontal)]
        [InlineData(ShipTypeEnum.Battleship, 5, 1, OrientationEnum.Vertical)]
        [InlineData(ShipTypeEnum.Battleship, 5, 7, OrientationEnum.Horizontal)]
        [InlineData(ShipTypeEnum.Battleship, 5, 7, OrientationEnum.Vertical)]
        public void Test_Collision_ShouldNotDetectCollision2(ShipTypeEnum secondShipType, int startX, int startY, OrientationEnum secondShipOrientation)
        {
            var ship1 = new ShipModel(ShipTypeEnum.Battleship, (5, 6), OrientationEnum.Horizontal);
            var ship2 = new ShipModel(secondShipType, (startX, startY), secondShipOrientation);

            Assert.False(ship1.CollidesWith(ship2));
            Assert.False(ship2.CollidesWith(ship1));
        }
    }
}