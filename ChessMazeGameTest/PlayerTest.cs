using ChessMazeGame;
using ChessMazeGame.Models;

namespace ChessMazeGameTest;

[TestClass]
public class PlayerTest : GameTestBase
{

    [TestMethod]
    public void PlayerMove_ValidMove_UpdatePosition()
    {
        var startPosition = new PiecePosition(0, 0);
        var newPosition = new PiecePosition(0, 2);
        var player = new Player(startPosition);

        player.Move(newPosition, Board);

        Assert.AreEqual(newPosition, player.CurrentPosition);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void PlayerMove_InValidMove_ThrowsArgumentException()
    {
        var startPosition = new PiecePosition(0, 0);
        var newPosition = new PiecePosition(0, 1);//empty
        var player = new Player(startPosition);

        player.Move(newPosition, Board);
    }
   
}





