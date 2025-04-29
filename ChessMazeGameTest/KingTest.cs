using ChessMazeGame.Models;

namespace ChessMazeGameTest
{
    [TestClass]
    public class KingTest
    { 
        protected King King;

        [TestInitialize]
        public void Setup()
        {
            King = new King(); 
        }

        [TestMethod]
        public void King_VerticallyValidMove_ReturnTrue()
        {
            var start = new PiecePosition(0, 0);
            var end = new PiecePosition(0, 1);

            bool result = King.IsChessRuleApplied(start, end);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void King_DiognallyValidMove_ReturnTrue()
        {
            var start = new PiecePosition(0, 0);
            var end = new PiecePosition(1, 1);

            bool result = King.IsChessRuleApplied(start, end);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void King_InValidMove_ReturnFalse()
        {
            var start = new PiecePosition(1, 1);
            var end = new PiecePosition(2, 3);

            bool result = King.IsChessRuleApplied(start, end);

            Assert.IsFalse(result);
        }

    }
}