using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess;
internal abstract class ChessPiece()
{
  public bool IsWhite { get; init; }
  public int Column { get; set; }
  public int Row { get; set; }

  public abstract bool CanMoveTo(int xTo, int yTo);
}
