using ChessMazeGame.Enums;
using ChessMazeGame.Interfaces;

namespace ChessMazeGame.Models;

public class King : ChessPiece
{
    public King() : base(PieceType.King) { }
    public override bool IsChessRuleApplied(IPosition start, IPosition end)
    {
        // Kings move one square in any direction
        int dRow = Math.Abs(start.Row - end.Row);
        int dColumn = Math.Abs(start.Column - end.Column);
        return dRow <= 1 && dColumn <= 1;
    }
}