using System;
using System.Collections.Generic;
using System.Xml.Schema;
using Battleships.Player.Interface;

namespace BattleshipBot
{
    public class IrishBot : IBattleshipsBot
    {
        private IGridSquare lastTarget;

        public IEnumerable<IShipPosition> GetShipPositions()
        {
            lastTarget = null; // Forget all our history when we start a new game
            return new List<IShipPosition>
      {
               ShipStart.GenerateShipPosition(5,10), //Aircraft Carrier
          ShipStart.GenerateShipPosition(4,10), //Battleship
          ShipStart.GenerateShipPosition(3,10), //Destroyer
          ShipStart.GenerateShipPosition(3,10), //Submarine
          ShipStart.GenerateShipPosition(2,10) //Patrol Boatk
      };
        }


        public IGridSquare SelectTarget()
        {
            var nextTarget = GetNextTarget();
            lastTarget = nextTarget;
            return nextTarget;
        }

        private IGridSquare GetNextTarget()
        {
            Random rnd = new Random();
            if (lastTarget == null)
            {
                int targetColumn = rnd.Next(1,10);
                char targetRow = ShipStart.GetRandomChar("ABCDEFGHIJ", 0);
                return new GridSquare(targetRow,targetColumn);
            }

            var row = lastTarget.Row;
            var col = lastTarget.Column + 1;
            if (lastTarget.Column != 10)
            {
                return new GridSquare(row, col);
            }

            row = (char)(row + 1);
            if (row > 'J')
            {
                row = 'A';
            }
            col = 1;
            return new GridSquare(row, col);
        }

        public void HandleShotResult(IGridSquare square, bool wasHit)
        {
            // Ignore whether we're successful
        }

        public void HandleOpponentsShot(IGridSquare square)
        {
            // Ignore what our opponent does
        }

        public string Name => "IrishBot";
    }
}
