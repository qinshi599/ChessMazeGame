using ChessMazeGame.Enums;
using ChessMazeGame.Interfaces;

namespace ChessMazeGame.Models;

public abstract class ChessPiece : IPiece
{

    public PieceType Type { get; protected set; }

    public ChessPiece(PieceType type)
    {
        Type = type;
    }

    /// <summary>
    /// Add a validate methoad to allow all PieceType validate their own move rules
    /// </summary>
    public abstract bool IsChessRuleApplied(IPosition start, IPosition end);
}