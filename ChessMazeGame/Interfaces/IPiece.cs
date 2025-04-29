using ChessMazeGame.Enums;

namespace ChessMazeGame.Interfaces;

/// <summary>
/// Represents a chess piece with a specific type.
/// </summary>
public interface IPiece
{
    /// <summary>
    /// Gets the type of the chess piece.
    /// </summary>
    PieceType Type { get; }

    bool IsChessRuleApplied(IPosition start, IPosition end);
}