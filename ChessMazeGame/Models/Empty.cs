using ChessMazeGame.Enums;
using ChessMazeGame.Interfaces;

namespace ChessMazeGame.Models;

public class Empty : ChessPiece
{
    public Empty() : base(PieceType.Empty) { }

    public override bool IsChessRuleApplied(IPosition start, IPosition end)
    {

        return false;
    }
}