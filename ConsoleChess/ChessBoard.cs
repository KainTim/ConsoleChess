using ConsoleChess.ChessPieces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess;
internal class ChessBoard
{
    private List<ChessPiece> _board = new List<ChessPiece>();
    public void Init()
    {
        _board = [
        new Rook(true, 0,0),
        new Knight(true, 1,0),
        new Bishop(true, 2,0),
        new Queen(true, 3,0),
        new King(true, 4,0),
        new Bishop(true,5,0),
        new Knight(true, 6,0),
        new Rook(true,7,0),
        new Pawn(true,0,1),
        new Pawn(true,1,1),
        new Pawn(true,2,1),
        new Pawn(true,3,1),
        new Pawn(true,4,1),
        new Pawn(true,5,1),
        new Pawn(true,6,1),
        new Pawn(true,7,1),

        new Rook(false, 0,7),
        new Knight(false, 1,7),
        new Bishop(false, 2,7),
        new Queen(false, 3,7),
        new King(false, 4,7),
        new Bishop(false,5,7),
        new Knight(false, 6,7),
        new Rook(false,7,7),
        new Pawn(false,0,6),
        new Pawn(false,1,6),
        new Pawn(false,2,6),
        new Pawn(false,3,6),
        new Pawn(false,4,6),
        new Pawn(false,5,6),
        new Pawn(false,6,6),
        new Pawn(false,7,6),
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
        var boardArr = new ChessPiece[8, 8];
        foreach(ChessPiece piece in _board)
        {
            boardArr[piece.Row,piece.Column] = piece;
        }

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
                Console.Write($"| {(boardArr[row,column]==null ? " ":boardArr[row,column])}  ");
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
    }
}
