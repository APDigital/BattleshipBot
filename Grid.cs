using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Player.Interface;

namespace BattleshipBot
{
    class Grid
    {
        public List<GridSquare> GridSquareLst = new List<GridSquare>();

        public bool IsPopulated(ShipPosition position)
        {
            for (char i = position.StartingSquare.Row; i <= position.EndingSquare.Row; i++)
            {
                if (SquareValid(new GridSquare(i, position.StartingSquare.Column))==false)
                {
                    return false;
                }
            }
            for (int i = position.StartingSquare.Column; i <= position.EndingSquare.Column; i++)
            {
                if (SquareValid(new GridSquare(position.StartingSquare.Row, i))==false)
                {
                    return false;
                }
            }
            return true;
        }

        public bool SquareValid(GridSquare gridSquare)
        {
            foreach (var gridSquareitm in GridSquareLst)
            {
                if (gridSquareitm.Row == gridSquare.Row && gridSquareitm.Column == gridSquare.Column)
                {
                    return false;
                }
            }
            return true;
        }

        public void AddShipToList(ShipPosition position)
        {
            for (char i = (char)((int)position.StartingSquare.Row - 1); i <= (char)((int)position.EndingSquare.Row + 1); i++)
            {
                GridSquareLst.Add(new GridSquare(i, position.StartingSquare.Column));
                GridSquareLst.Add(new GridSquare(i, position.StartingSquare.Column + 1));
                GridSquareLst.Add(new GridSquare(i, position.StartingSquare.Column - 1));
            }
            for (int i = position.StartingSquare.Column - 1; i <= position.EndingSquare.Column + 1; i++)
            {
                GridSquareLst.Add(new GridSquare(position.StartingSquare.Row, i));
                GridSquareLst.Add(new GridSquare((char)((int)position.StartingSquare.Row + 1), i));
                GridSquareLst.Add(new GridSquare((char)((int)position.StartingSquare.Row - 1), i));
            }
        }
    }
}
