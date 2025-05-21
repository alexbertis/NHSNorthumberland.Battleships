namespace NHSNorthumberland.Battleships.Models
{
    internal enum ShipTypeEnum
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

    }
}
