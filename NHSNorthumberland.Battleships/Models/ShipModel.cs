
namespace NHSNorthumberland.Battleships.Models
{
    internal class ShipModel
    {
        public ShipModel(ShipTypeEnum shipType, GridPosition position, OrientationEnum orientation)
        {
            ShipType = shipType;
            Position = position;
            Orientation = orientation;
        }

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
        /// The location of the ship, expressed as a pair of integers describing the index of the top-left extreme of the ship.
        /// </summary>
        public GridPosition ComputedEndPosition { 
            get
            {
                return Orientation == OrientationEnum.Horizontal
                    ? new GridPosition(Position.xCoordinate + ShipLength - 1, Position.yCoordinate)
                    : new GridPosition(Position.xCoordinate, Position.yCoordinate + ShipLength - 1);
            } 
        }

        /// <summary>
        /// The direction (vertical or horizontal) that the ship is aligned to.
        /// </summary>
        public OrientationEnum Orientation { get; set; }

        public bool CollidesWith(ShipModel otherShip)
        {
            if (otherShip == null) return false;

            int thisMinX = Position.xCoordinate;
            int thisMaxX = ComputedEndPosition.xCoordinate;
            int thisMinY = Position.yCoordinate;
            int thisMaxY = ComputedEndPosition.yCoordinate;
            int otherMinX = otherShip.Position.xCoordinate;
            int otherMaxX = otherShip.ComputedEndPosition.xCoordinate;
            int otherMinY = otherShip.Position.yCoordinate;
            int otherMaxY = otherShip.ComputedEndPosition.yCoordinate;


            if (Orientation == otherShip.Orientation)
            {
                if (Orientation == OrientationEnum.Horizontal)
                {
                    // If both are horizontal, they collide if they are on the same row and they overlap
                    return thisMinY == otherMinY
                        && (StartPointWithinBounds(thisMinX, otherMinX, otherMaxX) || StartPointWithinBounds(otherMinX, thisMinX, thisMaxX));
                } else
                {
                    // If both are vertical, they collide if they are on the same column and they overlap
                    return thisMinX == otherMinX
                        && (StartPointWithinBounds(thisMinY, otherMinY, otherMaxY) || StartPointWithinBounds(otherMinY, thisMinY, thisMaxY));
                }
            } else
            {
                // Ships have different orientation - do a crossing check
                if (Orientation == OrientationEnum.Horizontal)
                {
                    return Crosses(this, otherShip);
                } else
                {
                    return Crosses(otherShip, this);
                }
            }
        }

        private static bool StartPointWithinBounds(int startCoord, int otherShipStart, int otherShipEnd)
        {
            return startCoord >= otherShipStart && startCoord <= otherShipEnd;
        }

        private static bool Crosses(ShipModel horizontal, ShipModel vertical)
        {
            return StartPointWithinBounds(vertical.Position.xCoordinate, horizontal.Position.xCoordinate, horizontal.ComputedEndPosition.xCoordinate)
                && StartPointWithinBounds(horizontal.Position.yCoordinate, vertical.Position.yCoordinate, vertical.ComputedEndPosition.yCoordinate);
        }
    }
}
