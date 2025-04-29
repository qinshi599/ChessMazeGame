using ChessMazeGame;
using ChessMazeGame.Interfaces;
using ChessMazeGame.Models;

namespace ChessMazeGameTest;

public  class GameTestBase
{
    protected IBoard Board { get; private set; }

    protected Level GameLevel { get;  set; }// the new player has been created in level so no need to creat a new player here

    [TestInitialize]
    public void Setup()
    {
        Board = new Board(3, 3);
        Board.PlacePiece(new Rook(), new PiecePosition(0, 0));
        Board.PlacePiece(new Empty(), new PiecePosition(0, 1));
        Board.PlacePiece(new Knight(), new PiecePosition(0, 2));
        Board.PlacePiece(new Empty(), new PiecePosition(1, 0));
        Board.PlacePiece(new Pawn(), new PiecePosition(1, 1));
        Board.PlacePiece(new Rook(), new PiecePosition(1, 2));
        Board.PlacePiece(new Bishop(), new PiecePosition(2, 0));
        Board.PlacePiece(new Bishop(), new PiecePosition(2, 1));
        Board.PlacePiece(new King(), new PiecePosition(2, 2));

        GameLevel = new Level(Board, new PiecePosition(0, 0), new PiecePosition(2, 2)); // create a level 
        //Game game1 = new();// create a new game , simplified writing style from nre Game();
        //game1.LoadLevel(gameLevel1); // load the level to the game 


    }
}