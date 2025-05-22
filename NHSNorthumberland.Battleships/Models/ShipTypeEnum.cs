using NHSNorthumberland.Battleships.Extensions;

namespace NHSNorthumberland.Battleships.Models
{
    public enum ShipTypeEnum
    {
        [ShipLength(5)]
        Battleship,
        [ShipLength(4)]
        Destroyer
    }

    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    sealed class ShipLengthAttribute(int shipLength) : Attribute
    {

        /// <summary>
        /// The length of the type of ship, in squares.
        /// </summary>
        public int ShipLength { get; } = shipLength;
    }

    public static class ShipEnumExtensions
    {
        public static int GetShipLengthAttribute(this ShipTypeEnum enumValue)
        {
            var attribute = enumValue.GetAttributeOfType<ShipLengthAttribute>();
            return attribute == null ? 0 : attribute.ShipLength;
        }
    }
}
