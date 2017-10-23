using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Player.Interface;

namespace BattleshipBot
{
    class ShipSize : IrishBot
    {
        private static Random rnd = new Random();

        private static char GetRandomChar(string text, int shipSize)
        {
            int index = rnd.Next(text.Length - shipSize + 1);
            return text[index];
        }


        public static ShipPosition GetShipPositionForShipOfSize(int shipSize, int gridSize)
        {
            var horizontal = rnd.Next(0, 2);


            if (horizontal == 0)
            {
                int startColumn = rnd.Next(1, (gridSize + 1) - shipSize + 1);
                int endColumn = startColumn + shipSize - 1;
                var row = GetRandomChar("ABCDEFGHIJ", 1);

                return new ShipPosition(new GridSquare(row, startColumn), new GridSquare(row, endColumn));
            }
            else
            {
                char startRow = GetRandomChar("ABCDEFGHIJ", shipSize + 1);
                char endRow = (char)((int)startRow + shipSize - 1);
                var column = rnd.Next(1, 11);
                return new ShipPosition(new GridSquare(startRow, column), new GridSquare(endRow, column));
            }



        }
    }
}
