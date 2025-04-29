using ChessMazeGame;
using ChessMazeGame.Interfaces;
using ChessMazeGame.Models;

namespace ChessMazeGameTest;

[TestClass]
public class BoardTest : GameTestBase
{
    

    [TestMethod]
    public void GetPieceAt_ValidPosition_ReturnPiece()
    {
        //act
        var result = Board.GetPieceAt(new PiecePosition(0, 2));
        //assert
        Assert.AreEqual(typeof(Knight), result.GetType());

        //act
        var result1 = Board.GetPieceAt(new PiecePosition(0, 0));
        //assert
        Assert.AreEqual(typeof(Rook), result1.GetType());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GetPieceAt_InValidPosition_ThrowsArgumentException()
    {
        //act
        var invalidPosition = new PiecePosition(4, 3);
        //assert
        Board.GetPieceAt(invalidPosition);
    }

    [TestMethod]
    public void PlacePiece_ValidPosition_PiecePlacedSuccess()
    {
        //arrange - created a new board here to place the chess piece
        var board1 = new Board(3, 3);
        var piece = new Knight();
        var position = new PiecePosition(0,1);
        //act
        board1.PlacePiece(piece,position);
        var placedPiece = board1.GetPieceAt(position);
        //assert
        Assert.AreEqual(piece, placedPiece, "The placed piece does not match the expected piece.");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void PlacePiece_InValidPosition_ThrowsArgumentException()
    {
        //arrange - created a new board here to place the chess piece
        var board1 = new Board(3, 3);
        var piece = new Knight();
        var position = new PiecePosition(0, -1);

        //act
        board1.PlacePiece(piece, position);
    }

    [TestMethod]
    public void IsValidPosition_ValidRowAndColPosition_ReturnTrue()
    {
        var validPosition = new PiecePosition(0,0);
        var result = Board.IsValidPosition(validPosition);

        Assert.IsTrue(result, "Position is not valid");
    }

    [TestMethod]
    public void IsValidPosition_InvalidRow_ReturnTrue()
    {
        var validPosition = new PiecePosition(-1, 0);
        var result = Board.IsValidPosition(validPosition);

        Assert.IsFalse(result, "Position Row should be valid");
    }

    [TestMethod]
    public void IsValidPosition_InvalidCol_ReturnTrue()
    {
        var validPosition = new PiecePosition(0, -1);
        var result = Board.IsValidPosition(validPosition);

        Assert.IsFalse(result, "Position Column should be valid");
    }

    [TestMethod]
    public void IsValidPosition_InvalidRowAndCol_ReturnTrue()
    {
        var validPosition = new PiecePosition(-1, -1);
        var result = Board.IsValidPosition(validPosition);

        Assert.IsFalse(result, "Position Row and Col should be valid");
    }


    [TestMethod]
    public void IsEmptyPosition_SelectedPosition_IsOccupied_ReturnFalse()
    {
        var position = new PiecePosition(0, 0);//rook here
        var result = Board.IsEmptyPosition(position);

        Assert.IsFalse(result);
    }


    [TestMethod]
    public void IsEmptyPosition_SelectedPosition_IsEmpty_ReturnTrue()
    {
        var position = new PiecePosition(0, 1);
        var result = Board.IsEmptyPosition(position);


        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsMoveLegal_InvalidPosition_ReturnFalse()
    {
        //invalid from position
        var invalidFromPosition = new PiecePosition(3, 3); 
        var validToPosition = new PiecePosition(0, 0);

        var result = Board.IsMoveLegal(invalidFromPosition, validToPosition);
        Assert.IsFalse(result);

        //invalid to position
        var validFromPosition = new PiecePosition(0, 0);
        var invalidToPosition = new PiecePosition(-1,-1);

        var result1 = Board.IsMoveLegal(validFromPosition, invalidToPosition);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsMoveLegal_FromPositionEmpty_ReturnFalse()
    {
        var emptyFromPosition = new PiecePosition(0, 1);//empty piece here
        var validToPosition = new PiecePosition(0, 0);

        var result = Board.IsMoveLegal(emptyFromPosition, validToPosition);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsMoveLegal_ToPositionEmpty_ReturnFalse()
    {

        var validFromPosition = new PiecePosition(0, 0);
        var emptyToPosition = new PiecePosition(0, 1);//empty piece here

        var result = Board.IsMoveLegal(validFromPosition, emptyToPosition);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsMoveLegal_SameFromAndToPosition_ReturnFalse()
    {
        //arrange
        var validFromPosition = new PiecePosition(0, 0);
        var validToPosition = new PiecePosition(0, 0);
        //act
        var result = Board.IsMoveLegal(validFromPosition, validToPosition);
        Console.WriteLine(result);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsMoveLegal_PieceKing_ValidMove_ReturnTrue()
    {

        var fromPosition = new PiecePosition(2, 2);//king
        var toPosition = new PiecePosition(1, 2);//rook

        var result = Board.IsMoveLegal(fromPosition, toPosition);
        Assert.IsTrue(result);
    }


    [TestMethod]
    public void IsMoveLegal_RookValidMove_PathIsClear_ReturnTrue()
    {
        //when rook path clear can jump through the empty cells to other chess cell
        var fromPosition = new PiecePosition(0, 0);//rook
        var toPosition = new PiecePosition(0, 2);//knight

        var result = Board.IsMoveLegal(fromPosition, toPosition);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsMoveLegal_Bishop_BlockedPath_ReturnFalse()
    {
        var fromPosition = new PiecePosition(2, 0);//bishop
        var toPosition = new PiecePosition(0, 2);//knight

        var result = Board.IsMoveLegal(fromPosition, toPosition);
        Assert.IsFalse(result);
    }


    [TestMethod]
    public void IsPathClear_RookMadeMove_PathIsClear_ReturnTrue()
    {
        var from = new PiecePosition(0, 0);//rook left jumo over empty piece to knight
        var to = new PiecePosition(0, 2);//knight

        var result = Board.IsPathClear(from, to);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsPathClear_KnightMadeMove_PathIsBlocked_ReturnFalse ()
    {
        var from = new PiecePosition(2,0); //Knight
        var to = new PiecePosition(0, 2); //bishop 
        
        var result = Board.IsPathClear(from, to);
        
        Assert.IsFalse(result);
    }


}
