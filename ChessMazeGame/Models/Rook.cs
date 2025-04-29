using ChessMazeGame.Enums;
using ChessMazeGame.Interfaces;

namespace ChessMazeGame.Models;

public class Rook : ChessPiece
{
    public Rook() : base(PieceType.Rook) { }

    public override bool IsChessRuleApplied(IPosition start, IPosition end)
    {
        // Rooks move horizontally or vertically
        return start.Row == end.Row || start.Column == end.Column;
    }
}