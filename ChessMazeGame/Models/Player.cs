using ChessMazeGame.Interfaces;

namespace ChessMazeGame.Models;
/// <summary>
/// 
/// </summary>
public class Player : IPlayer
{
    public IPosition CurrentPosition { get; set; }
    public Player(IPosition startPosition)
    {
        CurrentPosition = startPosition;
    }

    public bool CanMove(IPosition newPosition, IBoard board)
    {
        return board.IsMoveLegal(CurrentPosition, newPosition);
    }

    public void Move(IPosition newPosition, IBoard board)
    {
        if (CanMove(newPosition, board))
        {
            // Move the player and update the position
            CurrentPosition = newPosition;
        }
        else
        {
            throw new ArgumentException("Move is not allowed.");
        }
    }

}