
namespace NHSNorthumberland.Battleships.Models
{
    public record struct StrikeResult(bool IsValidStrike, CellStrikeEnum StrikeType, ShipModel? SunkenShip)
    {
        public static implicit operator (bool, CellStrikeEnum, ShipModel?)(StrikeResult value)
        {
            return (value.IsValidStrike, value.StrikeType, value.SunkenShip);
        }

        public static implicit operator StrikeResult((bool, CellStrikeEnum, ShipModel?) value)
        {
            return new StrikeResult(value.Item1, value.Item2, value.Item3);
        }
    }
}
