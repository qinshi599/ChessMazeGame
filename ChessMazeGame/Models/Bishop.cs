using ChessMazeGame.Enums;
using ChessMazeGame.Interfaces;

namespace ChessMazeGame.Models;

public class Bishop : ChessPiece
{
    public Bishop() : base(PieceType.Bishop) { }

    public override bool IsChessRuleApplied(IPosition start, IPosition end)
    {
        return Math.Abs(start.Row - end.Row) == Math.Abs(start.Column - end.Column);
    }
}
