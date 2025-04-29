﻿namespace ChessMazeGame.Interfaces;

public interface IBoard
{
    /// <summary>
    /// Gets the number of rows on the board.
    /// </summary>
    int Rows { get; }

    /// <summary>
    /// Gets the number of columns on the board.
    /// </summary>
    int Columns { get; }

    /// <summary>
    /// Gets the array of cells on the board, each containing a piece.
    /// </summary>
    IPiece[,] Cells { get; }

    /// <summary>
    /// Gets the piece at a specific position on the board.
    /// </summary>
    /// <param name = "position" > The position to check.</param>
    /// <returns>The piece at the specified position.</returns>
    IPiece GetPieceAt(IPosition position);

    /// <summary>
    /// Places a piece at a specific position on the board.
    /// </summary>
    /// <param name = "piece" > The piece to place.</param>
    /// <param name = "position" > The position to place the piece at.</param>
    void PlacePiece(IPiece piece, IPosition position);

    /// <summary>
    /// Removes a piece from a specific position on the board.
    /// </summary>
    /// <param name="position">The position to remove the piece from.</param>
    void RemovePiece(IPosition position);

    /// <summary>
    /// Moves a piece from one position to another on the board.
    /// </summary>
    /// <param name="from">The starting position of the piece.</param>
    /// <param name="to">The destination position of the piece.</param>
    void MovePiece(IPosition from, IPosition to);

    /// <summary>
    /// Determines if a position is valid on the board.Out of boundry.
    /// </summary>
    /// <param name="position">The position to check.</param>
    /// <returns>True if the position is valid, otherwise false.</returns>
    bool IsValidPosition(IPosition position);

    /// <summary>
    /// Checking if the postion on board has no piece type/
    /// </summary>
    /// <param name="position">The position to check.</param>
    /// <returns>True if the position is empty, otherwise false.</returns>
    bool IsEmptyPosition(IPosition position);

    /// <summary>
    /// Determines if a move from one position to another is legal.
    /// </summary>
    /// <param name="from">The starting position of the move.</param>
    /// <param name="to">The destination position of the move.</param>
    /// <returns>True if the move is legal, otherwise false.</returns>
    bool IsMoveLegal(IPosition from, IPosition to);

    /// <summary>
    /// Check if the path is clear horizontally or vertically or diagonally, only applicable to Rooks and Bishops.
    /// </summary>
    /// /// <param name="from">The starting position of the move.</param>
    /// <param name="to">The destination position of the move.</param>
    /// <returns>True if the path is clear, otherwise false.</returns>
    bool IsPathClear(IPosition from, IPosition to);
}


