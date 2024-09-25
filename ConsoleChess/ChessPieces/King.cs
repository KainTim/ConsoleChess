using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess.ChessPieces;
internal class King(bool isWhite, int column, int row) : ChessPiece(isWhite,column,row)
{
    public override string ToString() => IsWhite ? "♚": "♔";
}
