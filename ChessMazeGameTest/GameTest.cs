using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessMazeGame;
using ChessMazeGame.Models;
using System.Numerics;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using NuGet.Frameworks;
using ChessMazeGame.Interfaces;
using System.Reflection.Emit;
using System.Xml.Linq;
using System.Reflection.Metadata;
using ChessMazeGame.Enums;

namespace ChessMazeGameTest;

[TestClass]
public class GameTest : GameTestBase
{

    [TestMethod]
    public void IsGameOver_PlayerAtEndPosition_ReturnsTrue()
    {
        // Arrange
        var game = new Game();
        game.LoadLevel(GameLevel);
        game.MakeMove(new PiecePosition(2, 0));
        game.MakeMove(new PiecePosition(1, 1));
        game.MakeMove(new PiecePosition(2, 2));
        // Act
        var result = game.IsGameOver;
        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsGameOver_PlayerNotAtEndPosition_ReturnsFalse()
    {
        // Arrange
        var game = new Game();
        game.LoadLevel(GameLevel);
        game.MakeMove(new PiecePosition(2, 0));
        // Act
        var result = game.IsGameOver;
        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void LoadLevel_LoadedALevel_CurrentLevelLoadedAndPushCurrentPositionToHistory()
    {
        Game game2 = new();
        game2.LoadLevel(GameLevel);
        var start = game2.CurrentLevel.Player.CurrentPosition;

        Assert.AreEqual(GameLevel, game2.CurrentLevel);
        Assert.AreEqual(1, game2.MoveHistory.Count);
        Assert.AreEqual(start, game2.MoveHistory.Peek());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void LoadLevel_WhenLevelIsNull_ThrowsArgumentException()
    {
        Game game2 = new();
        game2.LoadLevel(null);//empty level here
      
    }

    [TestMethod]
    public void MakeMove_PlayerCanNotMove_ReturnFalse() 
    {
        //arrange
        var game = new Game();
        game.LoadLevel(GameLevel);
        //act
        var result = game.MakeMove(new PiecePosition(0, 1)); //make a move to empty which is invalid position 
        //assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void MakeMove_RookCanMove_UpdateCurrentPositionAndMoveHistory()
    {
        //arrange
        var game = new Game();
        game.LoadLevel(GameLevel);
        var newPosition = new PiecePosition(0, 2);
        //act

        var result = game.MakeMove(newPosition); 
        //assert
        Assert.IsTrue(result);
        Assert.AreEqual(newPosition, game.CurrentLevel.Player.CurrentPosition); 
        Assert.AreEqual(2, game.MoveHistory.Count);
    }


    [TestMethod]
    public void MakeMove_RookCanMoveToPawn_PawnLastMovedPieceEqualsToBishop()
    {
        //arrange
        var game = new Game();
        GameLevel = new Level(Board, new PiecePosition(2, 0), new PiecePosition(2, 2));
        game.LoadLevel(GameLevel);
        var newPosition = new PiecePosition(1, 1);
       
        //act
        var result = game.MakeMove(newPosition);//bishop moved to Pawn
        var lastPiece = GameLevel.Board.GetPieceAt(new PiecePosition(2, 0));//bishop
        var currentPawn = (Pawn)GameLevel.Board.GetPieceAt(GameLevel.Player.CurrentPosition);//pawn
     
        //assert
        Assert.IsTrue(result);
        Assert.AreEqual(newPosition, game.CurrentLevel.Player.CurrentPosition);
        Assert.AreEqual(lastPiece,currentPawn.LastMovedPiece);// player's currrent piece is get the piece rules from last moved piece(bishop) 
    }

    [TestMethod]
    public void GetMoveCount_WhenMoveMade_ReturnCorrectCount()
    {
        //arrange
        Game game = new();
        game.LoadLevel(GameLevel);
        //act
        game.MakeMove(new PiecePosition(0, 2));
        var moveCount = game.GetMoveCount();
        game.MakeMove(new PiecePosition(2,1));
        var moveCount1 = game.GetMoveCount();
        //assert
        Assert.AreEqual(1, moveCount);// one move+ start position
        Assert.AreEqual(2, moveCount1); // two move+ start position
    }

    [TestMethod]
    public void GetMoveCount_WhenNoMoveMade_ReturnCorrectCount_OnlyTheStartPositionCount ()
    {
        //arrange
        Game game = new();
        game.LoadLevel(GameLevel);
        //act
        var moveCount = game.GetMoveCount();
        //assert
        Assert.AreEqual(0, moveCount);// no any move so just record the start position
    }

 

    [TestMethod]
    public void Restart_ClearMoveHistoryAndReloadLevel()
    {
        Game game = new();
        game.LoadLevel(GameLevel);
        game.MoveHistory.Push(new PiecePosition(0, 1));

        game.Restart();

        Assert.AreEqual(GameLevel, game.CurrentLevel);
        Assert.AreEqual(1, game.MoveHistory.Count);
    }

    [TestMethod]
    public void Undo_WhenNoMoveMade_LogMessage()
    {
        Game game = new();
        game.LoadLevel(GameLevel);

        using var consoleOutput = new ConsoleOutput();
        game.Undo();

        Assert.AreEqual(GameLevel.StartPosition, game.CurrentLevel.Player.CurrentPosition, "Player's position should not change.");
        Assert.AreEqual(1, game.MoveHistory.Count, "MoveHistory should remain unchanged.");
        Assert.IsTrue(consoleOutput.GetOutput().Contains("No move to undo."));

    }

    [TestMethod]
    public void Undo_WhenMoveMade_UpdateMoveHistoryAndAdjustPlayerPosition()
    {
        //arrange
        var game = new Game();
        game.LoadLevel(GameLevel);
        var firstMove = new PiecePosition(0, 2);
        var secondMove = new PiecePosition(2, 1);
        game.MakeMove(firstMove);
        game.MakeMove(secondMove);
        //act
        game.Undo();
        //assert
        Assert.AreEqual(firstMove, game.CurrentLevel.Player.CurrentPosition, "Player's position should back to first move position.");
        Assert.AreEqual(2, game.MoveHistory.Count, "MoveHistory should be back to first move status");
    }


}



