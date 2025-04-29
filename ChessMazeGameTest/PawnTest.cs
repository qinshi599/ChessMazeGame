using ChessMazeGame.Models;

namespace ChessMazeGameTest
{
    [TestClass]
    public class PawnTest : GameTestBase
    {
        protected Pawn Pawn;

        [TestInitialize]
        public void Setup()
        {
            base.Setup();
            Pawn = new Pawn();
        }

        [TestMethod]
        public void IsChessRuleApplied_PawnInheritFromBishop_ReturnTrueUnderBishopRule()
        {
            //arrange
            var game = new Game();
            game.LoadLevel(GameLevel);
            game.MakeMove(new PiecePosition(2, 0));//moved to bishop
            game.MakeMove(new PiecePosition(1, 1));//moved to pawn
            var currentPiece = Board.GetPieceAt(new PiecePosition(1, 1));
            //arrange
            var result = currentPiece.IsChessRuleApplied(new PiecePosition(1, 1), new PiecePosition(0, 2));
            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsChessRuleApplied_PawnInheritFromRook_ReturnTrueUnderRookRule()
        {
            //arrange
            var game = new Game();
            game.LoadLevel(GameLevel);
            game.MakeMove(new PiecePosition(0, 2));//moved to knight
            game.MakeMove(new PiecePosition(2, 1));//moved to bishop
            game.MakeMove(new PiecePosition(1, 2));//moved to rook
            game.MakeMove(new PiecePosition(1, 1));//moved to pawn
            var currentPiece = Board.GetPieceAt(new PiecePosition(1, 1));

            //act check id pawn can move like rook should be true
            var result = currentPiece.IsChessRuleApplied(new PiecePosition(1, 1), new PiecePosition(2, 1));
            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsChessRuleApplied_PawnInheritFromRook_ReturnFalseUnderRookRule()
        {
            //arrange
            var game = new Game();
            game.LoadLevel(GameLevel);
            game.MakeMove(new PiecePosition(0, 2));//moved to knight
            game.MakeMove(new PiecePosition(2, 1));//moved to bishop
            game.MakeMove(new PiecePosition(1, 2));//moved to rook
            game.MakeMove(new PiecePosition(1, 1));//moved to pawn
            var currentPiece = Board.GetPieceAt(new PiecePosition(1, 1));

            //act check if pawn can move diagonally-- should be false
            var result = currentPiece.IsChessRuleApplied(new PiecePosition(1, 1), new PiecePosition(0, 0));
            //assert
            Assert.IsFalse(result);
        }

    }



}
