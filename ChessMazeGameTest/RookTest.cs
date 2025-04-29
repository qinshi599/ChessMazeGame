using ChessMazeGame.Models;

namespace ChessMazeGameTest
{
    [TestClass]
    public class RookTest
    {
        protected Rook Rook;

        [TestInitialize]
        public void Setup()
        {
            Rook = new Rook();
        }

        [TestMethod]
        public void Rook_VerticallyValidMove_ReturnTrue()
        {
            var start = new PiecePosition(0, 0);
            var end = new PiecePosition(0, 1);

            bool result = Rook.IsChessRuleApplied(start, end);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Rook_horizontallyValidMove_ReturnTrue()
        {
            var start = new PiecePosition(0, 0);
            var end = new PiecePosition(1, 0);

            var result = Rook.IsChessRuleApplied(start, end);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Rook_InValidMove_ReturnFalse()
        {
            var start = new PiecePosition(1, 0);
            var end = new PiecePosition(0, 2);

            var start1 = new PiecePosition(1, 0);
            var end1 = new PiecePosition(2, 1);

            var result = Rook.IsChessRuleApplied(start, end);
            var result1 = Rook.IsChessRuleApplied(start, end);

            Assert.IsFalse(result);
            Assert.IsFalse(result1);
        }

    }
}