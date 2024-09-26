using ConsoleChess.ChessPieces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleChess;
internal class ChessBoard
{
  private static ChessBoard? _instance;
  private List<ChessPiece> _board = new List<ChessPiece>();

  public static ChessBoard Inst => _instance ??= new();

  private ChessBoard() { }

  public void Init()
  {
    _board = [
        new Rook {IsWhite = false,Column = 0, Row = 0 },
        new Knight { IsWhite = false, Column = 1, Row = 0 },
        new Bishop {IsWhite = false, Column = 2, Row = 0 },
        new Queen {IsWhite = false, Column = 3, Row = 0 },
        new King {IsWhite = false, Column = 4, Row = 0 },
        new Bishop {IsWhite = false, Column = 5, Row = 0 },
        new Knight(false, 6,0),
        new Rook(false,7,0),
        new Pawn(false,0,1),
        new Pawn(false,1,1),
        new Pawn(false,2,1),
        new Pawn(false,3,1),
        new Pawn(false,4,1),
        new Pawn(false,5,1),
        new Pawn(false,6,1),
        new Pawn(false,7,1),

        new Rook(true, 0,7),
        new Knight(true, 1,7),
        new Bishop(true, 2,7),
        new Queen(true, 3,7),
        new King(true, 4,7),
        new Bishop(true,5,7),
        new Knight(true, 6,7),
        new Rook(true,7,7),
        new Pawn(true,0,6),
        new Pawn(true,1,6),
        new Pawn(true,2,6),
        new Pawn(true,3,6),
        new Pawn(true,4,6),
        new Pawn(true,5,6),
        new Pawn(true,6,6),
        new Pawn(true,7,6),
  ];
  }

  public void Render()
  {
    Console.OutputEncoding = Encoding.UTF8;
    Console.Clear();

    RenderBoard();

  }

  private void RenderBoard()
  {
    var boardArr = ConvertPieceListToBoardArr();

    for (int row = 0; row < 8; row++)
    {
      Console.BackgroundColor = ConsoleColor.Black;
      Console.Write("  ");
      Console.BackgroundColor = ConsoleColor.DarkGray;
      for (int i = 0; i < 8; i++) { Console.Write("+----"); }

      Console.WriteLine("+");

      Console.BackgroundColor = ConsoleColor.Black;
      Console.Write($" {8 - row}");

      Console.BackgroundColor = ConsoleColor.DarkGray;
      for (int column = 0; column < 8; column++)
      {
        Console.Write($"| {(boardArr[row, column] == null ? " " : boardArr[row, column])}  ");
      }
      Console.WriteLine("|");

      Console.BackgroundColor = ConsoleColor.Black;
    }
    Console.Write("  ");

    Console.BackgroundColor = ConsoleColor.DarkGray;
    for (int i = 0; i < 8; i++)
    {
      Console.Write("+----");
    }
    Console.WriteLine("+");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.Write("    ");
    char[] chars = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
    for (int column = 0; column < 8; column++)
    {
      Console.Write($"{chars[column]}    ");
    }
    Console.WriteLine();
  }

  private ChessPiece?[,] ConvertPieceListToBoardArr()
  {
    var boardArr = new ChessPiece[8, 8];
    foreach (ChessPiece piece in _board)
    {
      boardArr[piece.Row, piece.Column] = piece;
    }

    return boardArr;
  }

  public void MovePieceFromTo(int xFrom, int yFrom, int xTo, int yTo)
  {
    var boardArr = ConvertPieceListToBoardArr();

    var chessPiece = boardArr[xFrom, yFrom];
    if (chessPiece == null)
    {
      foreach (var piece in boardArr)
      {
        Console.WriteLine($"{piece}");
      }
      throw new Exception($"No Piece to from {xFrom},{yFrom}-{xTo},{yTo}!");
    }

    if (chessPiece.CanMoveTo(xTo, yTo))
    {
      foreach (var piece in boardArr)
      {
        Console.WriteLine($"{piece} [{piece?.Row} {piece?.Column}]");
      }
      chessPiece.Row = xTo;
      chessPiece.Column = yTo;
    }
  }

}
