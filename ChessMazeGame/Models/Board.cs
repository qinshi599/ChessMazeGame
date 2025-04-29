using ChessMazeGame.Enums;
using ChessMazeGame.Interfaces;

namespace ChessMazeGame.Models;


public class Board : IBoard
{
    public int Rows { get; }
    public int Columns { get; }
    public IPiece[,] Cells { get; }

    public Board(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        Cells = new IPiece[rows, columns];
    }

    public IPiece GetPieceAt(IPosition position)
    {
        if (IsValidPosition(position))
        {
            return Cells[position.Row, position.Column];
        }

        throw new ArgumentException("The position is invalid, please check.", nameof(position));
    }

    public void PlacePiece(IPiece piece, IPosition position)
    {
        if (IsValidPosition(position))
        {
            Cells[position.Row, position.Column] = piece;
        }

        throw new ArgumentException("Invalid position on the board.");
    }

    //this method is out of the scope as a game player designer
    public void RemovePiece(IPosition position)
    {
        throw new NotImplementedException();
    }

    // already move the chess in player's move methoad so i will not implement this method here
    public void MovePiece(IPosition from, IPosition to)
    {
        throw new NotImplementedException();
    }


    public bool IsValidPosition(IPosition position)
    {
        if (position == null)
        {
            throw new ArgumentNullException(nameof(position), "Position cannot be null.");
        }

        return position.Row >= 0 && position.Row < Rows &&
                position.Column >= 0 && position.Column < Columns;
    }

    public bool IsEmptyPosition(IPosition position)
    {
        return GetPieceAt(position).Type == PieceType.Empty;
    }


    public bool IsMoveLegal(IPosition from, IPosition to)
    {
        if (!IsValidPosition(from) || !IsValidPosition(to) || IsEmptyPosition(from) || IsEmptyPosition(to))
        {
            return false;
        }

        if (from.Row == to.Row && from.Column == to.Column)
        {
            Console.WriteLine("you can't move to the same position you already in!");
            return false;
        }

        var fromPiece = GetPieceAt(from);

        //only bishop and rook can jump over the empty piece so we need to condier if the path is clear
        if (fromPiece.Type == PieceType.Bishop || fromPiece.Type == PieceType.Rook)
        {
            return fromPiece.IsChessRuleApplied(from, to) && IsPathClear(from, to);
        }

        return fromPiece.IsChessRuleApplied(from, to);//normal piece just check the rules
    }

    /// <summary>
    /// this method is only suit for rook and boshop who can jump over the empty cells
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns>return false if path is blocked,true if path is clear</returns>
    public bool IsPathClear(IPosition from, IPosition to)
    {
        int rowDiff = to.Row - from.Row;
        int colDiff = to.Column - from.Column;

        // Normalize directions
        int rowStep = rowDiff == 0 ? 0 : rowDiff / Math.Abs(rowDiff);
        int colStep = colDiff == 0 ? 0 : colDiff / Math.Abs(colDiff);

        IPosition current = new PiecePosition(from.Row + rowStep, from.Column + colStep);
        while (current.Row != to.Row && current.Column != to.Column)
        {
            if (GetPieceAt(current).Type != PieceType.Empty) 
            {
                return false; // Path is blocked
            }
            current = new PiecePosition(current.Row + rowStep, current.Column + colStep);
        }

        return true; // Path is clear
    }


}