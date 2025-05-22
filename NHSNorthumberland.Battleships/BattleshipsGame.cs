
using NHSNorthumberland.Battleships.Helpers;
using NHSNorthumberland.Battleships.Models;

namespace NHSNorthumberland.Battleships
{
    internal class BattleshipsGame
    {
        private readonly int width;
        private readonly int height;

        public BattleshipsGridModel EnemyShipsGrid { get; set; }

        public BattleshipsGame(int width = 10, int height = 10)
        {
            this.width = width;
            this.height = height;
        }

        public void StartGame()
        {
            EnemyShipsGrid = new BattleshipsGridModel(width, height);
            GenerateEnemyGrid(1, 2);

            Console.WriteLine("Welcome to the Battleships game. ");
            Console.WriteLine();
            PrintGridToConsole();

            while (true)
            {
                PlayRound();
            }
        }

        private void PlayRound()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter the coordinates for the next strike (for example, C7):");
            string? input = Console.ReadLine();
            var coords = GridDisplayHelper.ParseCoordinates(input.ToUpper());
            var (hit, strikeType) = EnemyShipsGrid.StrikePosition(coords);
            if (!hit)
            {
                Console.WriteLine(new String('=', 10));
                Console.WriteLine("ERROR! Please verify that you have not already hit that coordinate, and that it is within the grid bounds.");
                return;
            }

            PrintGridToConsole();

            if (strikeType == CellStrikeEnum.ShipHit)
            {
                Console.WriteLine();
                Console.WriteLine("You have hit a ship!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Water");
            }
        }


        private void GenerateEnemyGrid(int battleshipsToAdd, int destroyersToAdd)
        {
            int battleshipsAdded = 0;
            var rand = new Random();
            while (battleshipsAdded < battleshipsToAdd)
            {
                int positionX = rand.Next(width);
                int positionY = rand.Next(height);
                OrientationEnum orientation = rand.NextDouble() >= 0.5 ? OrientationEnum.Horizontal : OrientationEnum.Vertical;
                battleshipsAdded += EnemyShipsGrid.AddShip(new ShipModel(ShipTypeEnum.Battleship, (positionX, positionY), orientation)) ? 1 : 0;
            }
            int destroyersAdded = 0;
            while (destroyersAdded < destroyersToAdd)
            {
                int positionX = rand.Next(width);
                int positionY = rand.Next(height);
                OrientationEnum orientation = rand.NextDouble() >= 0.5 ? OrientationEnum.Horizontal : OrientationEnum.Vertical;
                destroyersAdded += EnemyShipsGrid.AddShip(new ShipModel(ShipTypeEnum.Destroyer, (positionX, positionY), orientation)) ? 1 : 0;
            }
        }

        private void PrintGridToConsole()
        {
            Console.WriteLine();
            Console.WriteLine(GridDisplayHelper.CreateConsoleDisplayFromGrid(EnemyShipsGrid.GetHitGrid()));
            Console.WriteLine();
        }
    }
}
