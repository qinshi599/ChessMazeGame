using ChessMazeGame.Models;

namespace ChessMazeGameTest
{
    [TestClass]
    public class KnightTest 
    {
        protected Knight Knight;

        [TestInitialize]
        public void Setup()
        {
            Knight = new Knight();
        }

        [TestMethod]
        public void Knight_ValidMove_ReturnTrue()
        { 
            var start = new PiecePosition(0, 2);
            var end = new PiecePosition(2,1);

            bool result = Knight.IsChessRuleApplied(start, end);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Knight_InValidMove_ReturnFalse()
        {
            var start = new PiecePosition(0, 2);
            var end = new PiecePosition(1, 2);

            bool result = Knight.IsChessRuleApplied(start, end);

            Assert.IsFalse(result);
        }

    }
}