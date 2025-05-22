namespace NHSNorthumberland.Battleships.Models
{
    public record struct GridPosition(int xCoordinate, int yCoordinate)
    {
        public static implicit operator (int, int)(GridPosition value)
        {
            return (value.xCoordinate, value.yCoordinate);
        }

        public static implicit operator GridPosition((int, int) value)
        {
            return new GridPosition(value.Item1, value.Item2);
        }
    }
}
