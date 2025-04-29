using ChessMazeGame.Enums;
using ChessMazeGame.Interfaces;

namespace ChessMazeGame.Models;

public class Game : IGame
{
    public ILevel CurrentLevel { get; set; }
    public Stack<IPosition> MoveHistory { get; set; }
    public Game()
    {
        MoveHistory = new Stack<IPosition>();
    }

    public bool IsGameOver
    {
        get
        {
            return CurrentLevel.Player.CurrentPosition.Row == CurrentLevel.EndPosition.Row &&
               CurrentLevel.Player.CurrentPosition.Column == CurrentLevel.EndPosition.Column;
        }
    }

    public void LoadLevel(ILevel level)
    {
        if (level == null)
        {
            throw new ArgumentNullException(nameof(level), "Level cannot be null.");
        }

        CurrentLevel = level;
        MoveHistory.Push(CurrentLevel.Player.CurrentPosition);
    }

    public void Restart()
    {
        MoveHistory.Clear();
        LoadLevel(CurrentLevel);
    }


    public bool MakeMove(IPosition newPosition)
    {
        if (CurrentLevel.Player.CanMove(newPosition, CurrentLevel.Board))
        {
            var lastPositionBeforeMove = CurrentLevel.Player.CurrentPosition;
            CurrentLevel.Player.Move(newPosition, CurrentLevel.Board);
            MoveHistory.Push(CurrentLevel.Player.CurrentPosition);
           
            var currentPiece = CurrentLevel.Board.GetPieceAt(CurrentLevel.Player.CurrentPosition);
            //if player moved to Pawn, then setting Pawn's LastMovedPiece to player's last ChessPiece
            if (currentPiece.Type == PieceType.Pawn)
            {
                Pawn currentPawn = (Pawn)currentPiece; // downcasting to Pawn
                var lastPieceBeforeMove = CurrentLevel.Board.GetPieceAt(lastPositionBeforeMove);
                currentPawn.SetLastMovedPiece((ChessPiece)lastPieceBeforeMove); // downcasting here
            }

            return true;
        }
        else
        {
            Console.WriteLine("You cannot move this way");
            return false;
        }
    }


    public int GetMoveCount()
    {
        return MoveHistory.Count - 1;
    }

    public void Undo()
    {
        if (MoveHistory.Count > 1)
        {
            MoveHistory.Pop();//remove new move first 

            IPosition lastPosition = MoveHistory.Peek();//get the last move position

            CurrentLevel.Player.CurrentPosition = lastPosition;//change player's postion back
        }
        else
        {
            Console.WriteLine("No move to undo.");
        }
    }

    // since its just for visualize the board, i won't add this method to the must-have feature list and do the unit test 
    public void PrintMoveHistory()
    {
        Console.WriteLine("Player's move history:");

        IPosition[] moveArray = MoveHistory.ToArray();
        Array.Reverse(moveArray);

        foreach (IPosition position in moveArray)
        {
            Console.WriteLine($"Step: [{position.Row}, {position.Column}]");
        }
    }
}