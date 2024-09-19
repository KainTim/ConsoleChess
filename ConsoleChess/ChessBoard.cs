using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess;
internal class ChessBoard
{
  private readonly List<ChessPiece> _board = new List<ChessPiece>();
  public void Init()
  {
    _board.Clear();
  }

  public void Render()
  {

  }
}
