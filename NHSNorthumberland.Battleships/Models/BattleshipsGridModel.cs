
namespace NHSNorthumberland.Battleships.Models
{
    internal class BattleshipsGridModel
    {
        private readonly int width;
        private readonly int height;
        private IList<ShipModel> _ships;
        private IList<GridPosition> _userStrikes;

        public IEnumerable<GridPosition> UserStrikes { get => _userStrikes; }

        public BattleshipsGridModel(int width, int height)
        {
            this.width = width;
            this.height = height;
            _ships = new List<ShipModel>();
            _userStrikes = new List<GridPosition>();
        }

        public bool AddShip(ShipModel ship)
        {
            // Run bounds checks
            if (ExceedsGridBounds(ship))
            {
                return false;
            }
            foreach (var existingShip in _ships)
            {
                // Check collisions with existing ships
                // Return early with "false" value if ship collides with any other existing ships
                if (ship.CollidesWith(existingShip))
                {
                    return false;
                }
            }
            _ships.Add(ship);
            return true;
        }

        public bool ExceedsGridBounds(ShipModel ship)
        {
            return ship.Position.xCoordinate < 0 || ship.Position.yCoordinate < 0 || ship.ComputedEndPosition.xCoordinate >= width || ship.ComputedEndPosition.yCoordinate >= height;
        }

        public (bool, CellStrikeEnum) StrikePosition(GridPosition strikePosition)
        {
            // Check strike is within bounds
            if (strikePosition.xCoordinate < 0 || strikePosition.yCoordinate < 0 || strikePosition.xCoordinate >= width || strikePosition.yCoordinate >= height)
            {
                return (false, CellStrikeEnum.None);
            }
            // Check position has not been hit yet
            if (_userStrikes.Any(strike => strikePosition.xCoordinate == strike.xCoordinate && strikePosition.yCoordinate == strike.yCoordinate))
            {
                return (false, CellStrikeEnum.None);
            }

            bool hit = false;
            // Check presence of ships
            foreach (var ship in _ships)
            {
                hit = IsStrikePositionHit(strikePosition, ship);
                // Break from loop if ship has been hit
                if (hit)
                {
                    ship.ShipHitCount++;
                    break;
                }
            }
            _userStrikes.Add(strikePosition);
            return (true, hit ? CellStrikeEnum.ShipHit : CellStrikeEnum.Water);
        }

        public CellStrikeEnum[,] GetHitGrid()
        {
            // Initialise a new grid, where all elements will default to enum value 0 (None)
            CellStrikeEnum[,] _grid = new CellStrikeEnum[width, height];

            foreach (var strikePosition in _userStrikes)
            {
                // grid[row, column] = grid[y, x]
                if (_ships.Any(ship => IsStrikePositionHit(strikePosition, ship)))
                {
                    _grid[strikePosition.yCoordinate, strikePosition.xCoordinate] = CellStrikeEnum.ShipHit;
                } else
                {
                    _grid[strikePosition.yCoordinate, strikePosition.xCoordinate] = CellStrikeEnum.Water;
                }
            }

            return _grid;
        }

        private static bool IsStrikePositionHit(GridPosition strikePosition, ShipModel ship)
        {
            bool hit;
            if (ship.Orientation == OrientationEnum.Horizontal)
            {
                hit = ship.Position.yCoordinate == strikePosition.yCoordinate
                    && ShipModel.PointWithinBounds(strikePosition.xCoordinate, ship.Position.xCoordinate, ship.ComputedEndPosition.xCoordinate);
            } else
            {
                hit = ship.Position.xCoordinate == strikePosition.xCoordinate
                    && ShipModel.PointWithinBounds(strikePosition.yCoordinate, ship.Position.yCoordinate, ship.ComputedEndPosition.yCoordinate);
            }

            return hit;
        }
    }
}
