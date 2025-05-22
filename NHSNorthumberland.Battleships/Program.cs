using NHSNorthumberland.Battleships;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            BattleshipsGame game = new BattleshipsGame();
            game.StartGame();
            Console.WriteLine("Enter 'exit' to leave, or any other text to play another game.");
            string? input = Console.ReadLine();
            if (input != null && input == "exit")
            {
                break;
            }
        }
    }
}