﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess.ChessPieces;
internal class Knight() : ChessPiece()
{
  public override bool CanMoveTo(int xTo, int yTo) => true;
  public override string ToString() => IsWhite ? "♞" : "♘";
}
