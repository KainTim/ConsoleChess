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
    public bool isWhite = true;
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
        new Knight {IsWhite = false, Column = 6, Row = 0 },
        new Rook {IsWhite = false, Column = 7, Row = 0 },
        new Pawn {IsWhite = false, Column = 0, Row = 1 },
        new Pawn {IsWhite = false, Column = 1, Row = 1 },
        new Pawn {IsWhite = false, Column = 2, Row = 1 },
        new Pawn {IsWhite = false, Column = 3, Row = 1 },
        new Pawn {IsWhite = false, Column = 4, Row = 1 },
        new Pawn {IsWhite = false, Column = 5, Row = 1 },
        new Pawn {IsWhite = false, Column = 6, Row = 1 },
        new Pawn {IsWhite = false, Column = 7, Row = 1 },

        new Rook {IsWhite = true,Column = 0, Row = 7 },
        new Knight { IsWhite = true, Column = 1, Row = 7 },
        new Bishop {IsWhite = true, Column = 2, Row = 7 },
        new Queen {IsWhite = true, Column = 3, Row = 7 },
        new King {IsWhite = true, Column = 4, Row = 7 },
        new Bishop {IsWhite = true, Column = 5, Row = 7 },
        new Knight {IsWhite = true, Column = 6, Row = 7 },
        new Rook {IsWhite = true, Column = 7, Row = 7 },
        new Pawn {IsWhite = true, Column = 0, Row = 6 },
        new Pawn {IsWhite = true, Column = 1, Row = 6 },
        new Pawn {IsWhite = true, Column = 2, Row = 6 },
        new Pawn {IsWhite = true, Column = 3, Row = 6 },
        new Pawn {IsWhite = true, Column = 4, Row = 6 },
        new Pawn {IsWhite = true, Column = 5, Row = 6 },
        new Pawn {IsWhite = true, Column = 6, Row = 6 },
        new Pawn {IsWhite = true, Column = 7, Row = 6 },
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
            throw new Exception($"No Piece to from {xFrom},{yFrom}-{xTo},{yTo}!");
        }
        if (isWhite && chessPiece.IsWhite || !isWhite && !chessPiece.IsWhite)
        {
            if (chessPiece.CanMoveTo(xTo, yTo))
            {
                foreach (var piece in _board)
                {
                    if (piece.Row == xTo && piece.Column == yTo) throw new Exception("There's already a piece there!");
                }
                chessPiece.Row = xTo;
                chessPiece.Column = yTo;
            }
            else
            {
                throw new Exception($"That's not somewhere you can Move to: {xTo},{yTo}!");
            }
        }
        else
        {

            throw new Exception($"That's not your Piece: {xTo},{yTo}!");
        }



    }

    internal ChessPiece? GetPieceAtPosition(int x, int y)
    {
        return ConvertPieceListToBoardArr()[x, y];
    }


}
