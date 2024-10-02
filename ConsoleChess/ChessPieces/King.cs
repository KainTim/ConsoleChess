using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess.ChessPieces;
internal class King : ChessPiece
{
    public override bool CanMoveTo(int xTo, int yTo)
    {

        if (xTo < 0 || xTo > 7) throw new ArgumentOutOfRangeException($"Column {xTo + 1} is out of the Playable area");
        if (yTo < 0 || yTo > 7) throw new ArgumentOutOfRangeException($"Row {yTo + 1} is out of the Playable area");

        int xDiff = Math.Abs(xTo - Column);
        int yDiff = Math.Abs(yTo - Row);

        // King can move one square in any direction
        if (xDiff <= 1 && yDiff <= 1)
        {
            return true;
        }

        return false;
    }

    public override string ToString() => IsWhite ? "♚" : "♔";
}
