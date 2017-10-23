using System;
using Battleships.Player.Interface;

namespace BattleshipBot
{
    class ShipStart : IrishBot
    {
        private static Random rnd = new Random();

        private static Grid grid = new Grid();
        public static char GetRandomChar(string text, int shipSize)
        {
            int index = rnd.Next(text.Length - shipSize + 1);
            return text[index];
        }


        public static ShipPosition GenerateShipPosition(int shipSize, int gridSize)
        {
            var horizontal = rnd.Next(0, 2);


            if (horizontal == 0)
            {
                int startColumn = rnd.Next(1, (gridSize + 1) - shipSize + 1);
                int endColumn = startColumn + shipSize - 1;
                var row = GetRandomChar("ABCDEFGHIJ", 1);
                var shipPosition = new ShipPosition(new GridSquare(row, startColumn), new GridSquare(row, endColumn));

                var valid = grid.IsPopulated(shipPosition);

                if (valid)
                {
                    grid.AddShipToList(shipPosition);
                    return shipPosition;

                }

                return GenerateShipPosition(shipSize, gridSize);

            }
            else
            {
                char startRow = GetRandomChar("ABCDEFGHIJ", shipSize + 1);
                char endRow = (char)((int)startRow + shipSize - 1);
                var column = rnd.Next(1, 11);
                var shipPosition = new ShipPosition(new GridSquare(startRow, column), new GridSquare(endRow, column));

                var valid = grid.IsPopulated(shipPosition);

                if (valid)
                {
                    grid.AddShipToList(shipPosition);
                    return shipPosition;

                }
                return GenerateShipPosition(shipSize, gridSize);
            }
        }
    }
}
