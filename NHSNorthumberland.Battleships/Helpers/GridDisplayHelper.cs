using NHSNorthumberland.Battleships.Extensions;
using NHSNorthumberland.Battleships.Models;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NHSNorthumberland.Battleships.Helpers
{
    internal class GridDisplayHelper
    {
        private static readonly string rowLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string CreateConsoleDisplayFromGrid(CellStrikeEnum[,] cellStrikeGrid)
        {
            int height = cellStrikeGrid.GetLength(0);
            int width = cellStrikeGrid.GetLength(1);
            StringBuilder sb = new StringBuilder();
            
            PrintGridHeader(width, sb);

            for (int row = 0; row < height; row++)
            {
                // Print a row and a divider
                PrintHorizontalDivider(width, sb);
                var rowArray = GetRow(cellStrikeGrid, row).Select(element => element.GetAttributeOfType<DisplayAttribute>().Name);
                PrintRow(sb, row, rowArray);
            }

            return sb.ToString();
        }

        private static void PrintRow(StringBuilder sb, int row, IEnumerable<string> rowArray)
        {
            sb.AppendLine($"{rowLetters[row],3} |  {string.Join("  |  ", rowArray)}");
        }

        private static void PrintGridHeader(int width, StringBuilder sb)
        {
            sb.Append("    ");
            for (int col = 0; col < width; col++)
            {
                sb.Append($"| {col + 1, 3} ");
            }
            sb.AppendLine();
        }

        private static void PrintHorizontalDivider(int width, StringBuilder sb)
        {
            sb.Append("----");
            for (int col = 0; col < width; col++)
            {
                sb.Append("+-----");
            }
            sb.AppendLine();
        }

        private static CellStrikeEnum[] GetRow(CellStrikeEnum[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }


        public static GridPosition? ParseCoordinates(string coordinates)
        {
            var row = rowLetters.IndexOf(coordinates[0]);
            bool parseCorrect = int.TryParse(coordinates.Substring(1), out int col);
            if (!parseCorrect)
            {
                return null;
            }
            return new GridPosition(col - 1, row);
        }
    }
}
