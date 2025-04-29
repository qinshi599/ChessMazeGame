using ChessMazeGame;
using ChessMazeGame.Interfaces;
using ChessMazeGame.Models;

namespace ChessMazeGameTest
{
    [TestClass]
    public class BishopTest
    {
        protected Bishop Bishop;

        [TestInitialize]
        public void Setup()
        {
            Bishop = new Bishop(); // Initialize the Bishop instance
        }

        [TestMethod]
        public void Bishop_ValidDiagonalMove_ReturnTrue()
        {
            var start = new PiecePosition(0, 0);
            var end = new PiecePosition(1, 1);

            bool result = Bishop.IsChessRuleApplied(start, end);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Bishop_InValidMove_ReturnFalse()
        {
            var start = new PiecePosition(0, 0);
            var end = new PiecePosition(0, 1);

            bool result = Bishop.IsChessRuleApplied(start, end);

            Assert.IsFalse(result);
        }


    }



}
