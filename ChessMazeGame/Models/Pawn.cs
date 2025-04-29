using ChessMazeGame.Enums;
using ChessMazeGame.Interfaces;

namespace ChessMazeGame.Models;

public class Pawn : ChessPiece
{
    public ChessPiece LastMovedPiece { get; private set; }

    public Pawn() : base(PieceType.Pawn) { }

    public void SetLastMovedPiece(ChessPiece lastMovePiece)
    {
        this.LastMovedPiece = lastMovePiece;
    }

    public override bool IsChessRuleApplied(IPosition start, IPosition end)
    {
        if (LastMovedPiece == null)
            throw new InvalidOperationException("Last moved piece cannot be null.");
        else
            return LastMovedPiece.IsChessRuleApplied(start, end);
    }

}