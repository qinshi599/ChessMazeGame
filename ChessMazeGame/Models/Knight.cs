using ChessMazeGame.Enums;
using ChessMazeGame.Interfaces;

namespace ChessMazeGame.Models;

public class Knight : ChessPiece
{
    public Knight() : base(PieceType.Knight) { }

    public override bool IsChessRuleApplied(IPosition start, IPosition end)
    {
        // Knights move in an L-shape
        int dRow = Math.Abs(start.Row - end.Row);
        int dColumn = Math.Abs(start.Column - end.Column);
        return dRow == 2 && dColumn == 1 || dRow == 1 && dColumn == 2;
    }
}