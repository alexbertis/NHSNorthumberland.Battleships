namespace NHSNorthumberland.Battleships.Models
{
    internal class ShipModel
    {
        /// <summary>
        /// The type of ship this object is.
        /// </summary>
        public ShipTypeEnum ShipType { get; set; }

        public int ShipLength { get => ShipType.GetShipLengthAttribute(); }

        /// <summary>
        /// The location of the ship, expressed as a pair of integers describing the index of the top-left extreme of the ship.
        /// </summary>
        public GridPosition Position { get; set; }

        /// <summary>
        /// The direction (vertical or horizontal) that the ship is aligned to.
        /// </summary>
        public OrientationEnum Orientation { get; set; }
    }
}
