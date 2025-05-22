
namespace NHSNorthumberland.Battleships.Models
{
    internal class BattleshipsGridModel
    {
        private readonly int width;
        private readonly int height;
        private IEnumerable<ShipModel> _ships;
        private IEnumerable<GridPosition> _userStrikes;

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
            _ships.Append(ship);
            return true;
        }

        public bool ExceedsGridBounds(ShipModel ship)
        {
            return ship.Position.xCoordinate < 0 || ship.Position.yCoordinate < 0 || ship.ComputedEndPosition.xCoordinate >= width || ship.ComputedEndPosition.yCoordinate >= height;
        }

        public CellStrikeEnum StrikePosition(GridPosition position)
        {
            // TODO: bounds checks
            // TODO: check position has not been hit yet; check presence of ships. Use early returns
            _userStrikes.Append(position);
            return CellStrikeEnum.None;
        }

        public CellStrikeEnum[,] GetHitGrid()
        {
            // Initialise a new grid, where all elements will default to enum value 0 (None)
            CellStrikeEnum[,] _grid = new CellStrikeEnum[width, height];
            // TODO: get list of ships and list of user strikes
            return _grid;
        }
    }
}
