using ChessMazeGame.Interfaces;
using ChessMazeGame.Models;

namespace ChessMazeGame;

class Program
{
    public static void Main(string[] args)
    {
        // var chessboard = new Board(4, 4);
        //chessboard.PlacePiece(new King(), new PiecePosition(0, 0));    // King at (0, 0)
        //chessboard.PlacePiece(new Bishop(), new PiecePosition(0, 1));  // Bishop at (0, 1)
        //chessboard.PlacePiece(new Knight(), new PiecePosition(0, 2));  // Knight at (0, 2)
        //chessboard.PlacePiece(new Bishop(), new PiecePosition(0, 3));  // Bishop at (0, 3)

        //chessboard.PlacePiece(new Rook(), new PiecePosition(1, 0));    // Rook at (1, 0)
        //chessboard.PlacePiece(new Pawn(), new PiecePosition(1, 1));    // Pawn at (1, 1)
        //chessboard.PlacePiece(new Knight(), new PiecePosition(1, 2));  // Replaced Queen with Knight at (1, 2)
        //chessboard.PlacePiece(new Rook(), new PiecePosition(1, 3));    // Rook at (1, 3)

        //chessboard.PlacePiece(new Knight(), new PiecePosition(2, 0));  // Knight at (2, 0)
        //chessboard.PlacePiece(new Rook(), new PiecePosition(2, 1));    // Rook at (2, 1)
        //chessboard.PlacePiece(new Bishop(), new PiecePosition(2, 2));  // Bishop at (2, 2)
        //chessboard.PlacePiece(new Rook(), new PiecePosition(2, 3));    // Rook at (2, 3)

        //chessboard.PlacePiece(new Bishop(), new PiecePosition(3, 0));  // Bishop at (3, 0)
        //chessboard.PlacePiece(new Knight(), new PiecePosition(3, 1));  // Replaced Queen with Knight at (3, 1)
        //chessboard.PlacePiece(new Knight(), new PiecePosition(3, 2));  // Knight at (3, 2)
        //chessboard.PlacePiece(new Rook(), new PiecePosition(3, 3));    // Rook at (3, 3)

        // PrintBoard(chessboard);

        // var gamelevel = new Level(chessboard, new PiecePosition(0, 0), new PiecePosition(2, 2));
        // var game1 = new Game();
        // game1.LoadLevel(gamelevel);

        // game1.MakeMove(new PiecePosition(2, 0));
        // // Console.WriteLine($"current piece type: {chessboard.GetPieceAt(game1.CurrentLevel.Player.CurrentPosition)}");
        // game1.Undo();
        // //Console.WriteLine($"player's postionsjould back to 0,0 {game1.CurrentLevel.Player.CurrentPosition.Row},{game1.CurrentLevel.Player.CurrentPosition.Column}");
        // game1.PrintMoveHistory();
        // //Console.WriteLine($"Total steps: {game1.GetMoveCount()}");

        // // IPosition newPosition2 = new PiecePosition(2, 2);
        //game1.MakeMove(newPosition2);


        //IPosition newPosition3 = new PiecePosition(3, 3);
        //game1.MakeMove(newPosition3);
        //game1.PrintMoveHistory();

    }

    // public static void PrintBoard(Board board)
    // {
    //     int rows = board.Rows;
    //     int columns = board.Columns;

    //     for (int i = 0; i < rows; i++)
    //     {
    //         for (int j = 0; j < columns; j++)
    //         {
    //             IPiece piece = board.Cells[i, j];
    //             Console.Write(piece.Type.ToString().PadRight(10));
    //         }
    //         Console.WriteLine();
    //     }
    // }
}


