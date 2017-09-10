using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameComponents.Squares;
using GameComponents.Enum;
using GameComponents.Board;

namespace GameComponentsUnitTests
{
    [TestClass]
    public class NandCBoard2DTests
    {
        private INandCBoard2D _board;

        [TestInitialize]
        public void InitiateBoard()
        {
            _board = new NandCBoard2D();
        }

        [TestMethod]
        public void BoardInitialized3By3()
        {
            _board = new NandCBoard2D();
            Assert.IsNotNull(_board);
            var boardSquares = _board.GetBoard();
            Assert.AreEqual(3, boardSquares.Length);
            Assert.AreEqual(3, boardSquares[0].Length);
        }

        [TestMethod]
        public void GetDefaultBoardSquareExpectNull()
        {
            int x = 0;
            int y = 0;
            _board = new NandCBoard2D();
            var value = _board.GetSquare(x, y);
            Assert.IsNull(value);
        }

        [TestMethod]
        public void SetAndGetBoardSquare()
        {
            int x = 0;
            int y = 0;
            NoughtCrossToken value = NoughtCrossToken.X;
            _board = new NandCBoard2D();
            _board.SetSquare(x, y, value);
            var setValue = _board.GetSquare(x, y);
            Assert.AreEqual(value, setValue);
        }

        [TestMethod]
        public void SetAndGetBoardSquare1by2()
        {
            int x = 1;
            int y = 2;
            NoughtCrossToken value = NoughtCrossToken.X;
            _board = new NandCBoard2D();
            _board.SetSquare(x, y, value);
            var setValue = _board.GetSquare(x, y);
            Assert.AreEqual(value, setValue);
        }

        [TestMethod]
        public void SetAndGetBoardSquare2by0()
        {
            int x = 2;
            int y = 0;
            NoughtCrossToken value = NoughtCrossToken.X;
            _board = new NandCBoard2D();
            _board.SetSquare(x, y, value);
            var setValue = _board.GetSquare(x, y);
            Assert.AreEqual(value, setValue);
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void SetAlreadySetBoardSquare()
        {
            int x = 0;
            int y = 0;
            NoughtCrossToken value = NoughtCrossToken.X;
            _board = new NandCBoard2D();
            _board.SetSquare(x, y, value);
            value = NoughtCrossToken.O;
            _board.SetSquare(x, y, value);
        }


    }
}
