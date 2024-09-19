using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess;
internal abstract class ChessPiece(bool isWhite, int column, int row)
{
  public bool IsWhite => isWhite;
  public int Column => column;
  public int Row => row;
}
