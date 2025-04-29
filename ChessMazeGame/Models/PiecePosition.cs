using ChessMazeGame.Interfaces;

namespace ChessMazeGame.Models;

public class PiecePosition : IPosition
{
    public int Row { get; }
    public int Column { get; }

    public PiecePosition(int row, int column)
    {
        Row = row;
        Column = column;
    }

}