using NHSNorthumberland.Battleships.Models;
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
                var rowArray = GetRow(cellStrikeGrid, row);
                PrintRow(sb, row, rowArray);
            }

            return sb.ToString();
        }

        private static void PrintRow(StringBuilder sb, int row, CellStrikeEnum[] rowArray)
        {
            sb.AppendLine($"{rowLetters[row]}\t| {string.Join(" | ", rowArray)}");
        }

        private static void PrintGridHeader(int width, StringBuilder sb)
        {
            sb.Append($"\t|");
            for (int col = 0; col < width; col++)
            {
                sb.Append($" {col + 1} ");
            }
            sb.AppendLine();
        }

        private static void PrintHorizontalDivider(int width, StringBuilder sb)
        {
            sb.Append("----");
            for (int col = 0; col < width; col++)
            {
                sb.Append("+---");
            }
            sb.AppendLine();
        }

        private static CellStrikeEnum[] GetRow(CellStrikeEnum[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }
    }
}
