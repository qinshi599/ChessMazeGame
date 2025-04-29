using ChessMazeGame.Interfaces;

namespace ChessMazeGame.Models;

public class Level : ILevel
{
    public IBoard Board { get; }

    public IPosition StartPosition { get; }

    public IPosition EndPosition { get; }

    public IPlayer Player { get; }

    public bool IsCompleted
    {
        get
        {
            return Player.CurrentPosition.Equals(EndPosition);
        }
    }

    public Level(IBoard board, IPosition start, IPosition end)
    {
        Board = board;
        StartPosition = start;
        EndPosition = end;
        Player = new Player(StartPosition); // Set the player's starting position
    }
}