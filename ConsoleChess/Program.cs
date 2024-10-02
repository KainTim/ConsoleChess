using ConsoleChess;

var chessBoard = ChessBoard.Inst;

chessBoard.Init();
chessBoard.Render();
while (true)
{
    PrintHelpInformation();
    string input = Console.ReadLine() ?? "UNKNOWN";
    try
    {
        HandleMove(input);
        chessBoard.Render();
    }
    catch (Exception exc)
    {
        if (exc.Message.Equals("EXIT")) return 0;
        Console.Clear();

        chessBoard.Render();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(exc.Message);
        Console.ForegroundColor = ConsoleColor.White;
    }
}

void HandleMove(string input)
{
    if (input.ToLower().Equals("exit")) throw new("EXIT");

    string[] parts = input.Split('-');
    if (parts.Length != 2) throw new Exception("Input has to contain a single dash");

    if (parts[0].Length != 2) throw new Exception($"The first Coordinates have to contain exactly 2 characters");
    if (parts[1].Length != 2) throw new Exception($"The second Coordinates have to contain exactly 2 characters");

    int yFrom = parts[0].ToCharArray()[0] - 'a';
    if (yFrom is < 0 or > 7) throw new Exception($"column {parts[0].ToCharArray()[0]} is not a valid column");
    int yTo = parts[1].ToCharArray()[0] - 'a';
    if (yTo is < 0 or > 7) throw new Exception($"column {parts[1].ToCharArray()[0]} is not a valid column");

    try
    {
        int xFrom = 8 - int.Parse(parts[0].ToCharArray()[1].ToString());

        if (xFrom is < 0 or > 7) throw new Exception($"column {parts[0].ToCharArray()[1]} is not a valid row");
        try
        {
            int xTo = 8 - int.Parse(parts[1].ToCharArray()[1].ToString());

            if (xTo is < 0 or > 7) throw new Exception($"column {parts[1].ToCharArray()[1]} is not a valid row");
            chessBoard.MovePieceFromTo(xFrom, yFrom, xTo, yTo);
        }
        catch (FormatException)
        {
            throw new Exception($"{parts[1].ToCharArray()[1].ToString()} is not convertible to a number");
        }
    }
    catch (FormatException)
    {
        throw new Exception($"{parts[0].ToCharArray()[1].ToString()} is not convertible to a number");
    }

}

void PrintHelpInformation()
{
    Console.WriteLine("Make your Move!");
    Console.WriteLine("Format: a1-a2");
}
