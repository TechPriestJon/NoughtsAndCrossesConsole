using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameComponents.Game;
using GameComponents.Board;
using GameComponents.Squares;
using GameComponents.Enum;

namespace GameComponentsUnitTests
{
    public class DummySquare : IGameSquare
    {
        public NoughtCrossToken? Value { get; set; }
    }


    [TestClass]
    public class GameVictoryCalculatorTests
    {
        private IGameVictoryCalculator _victoryCalculator;
        private IGameSquare[][] _squares;

        [TestInitialize]
        public void InitiateBoardResources()
        {
            _squares = new GameSquare[3][];
            for (int i = 0; i < 3; i++)
            {
                _squares[i] = new GameSquare[3];
                for (int j = 0; j < 3; j++)
                {
                    _squares[i][j] = new GameSquare();
                }
            }
            _victoryCalculator = new GameVictoryCalculator(GameWinStates.GetStates());
        }

        [TestMethod]
        [ExpectedException(typeof(ArrayTypeMismatchException))]
        public void ThrowErrorOnWrongSquareType()
        {
            _squares = new DummySquare[3][];
            for (int i = 0; i < 3; i++)
            {
                _squares[i] = new DummySquare[3];
                for (int j = 0; j < 3; j++)
                {
                    _squares[i][j] = new DummySquare();
                }
            }
            _victoryCalculator.IsGameWon(_squares);
        }

        [TestMethod]
        public void CalculatorVictoryVerticalLeftX()
        {
            _squares[0][0].Value = NoughtCrossToken.X;
            _squares[0][1].Value = NoughtCrossToken.X;
            _squares[0][2].Value = NoughtCrossToken.X;
            var result = _victoryCalculator.IsGameWon(_squares);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CalculatorVictoryHorizontalTopX()
        {
            _squares[0][2].Value = NoughtCrossToken.X;
            _squares[1][2].Value = NoughtCrossToken.X;
            _squares[2][2].Value = NoughtCrossToken.X;
            var result = _victoryCalculator.IsGameWon(_squares);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CalculatorVictoryDiagonalTopLeftToRightX()
        {
            _squares[0][2].Value = NoughtCrossToken.X;
            _squares[1][1].Value = NoughtCrossToken.X;
            _squares[2][0].Value = NoughtCrossToken.X;
            var result = _victoryCalculator.IsGameWon(_squares);
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void CalculatorVictoryDiagonalTopRightToLeftX()
        {
            _squares[2][2].Value = NoughtCrossToken.X;
            _squares[1][1].Value = NoughtCrossToken.X;
            _squares[0][0].Value = NoughtCrossToken.X;
            var result = _victoryCalculator.IsGameWon(_squares);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CalculatorVictoryVerticalMidX()
        {
            _squares[1][0].Value = NoughtCrossToken.X;
            _squares[1][1].Value = NoughtCrossToken.X;
            _squares[1][2].Value = NoughtCrossToken.X;
            var result = _victoryCalculator.IsGameWon(_squares);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CalculatorVictoryVerticalRightX()
        {
            _squares[2][0].Value = NoughtCrossToken.X;
            _squares[2][1].Value = NoughtCrossToken.X;
            _squares[2][2].Value = NoughtCrossToken.X;
            var result = _victoryCalculator.IsGameWon(_squares);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CalculatorVictoryHorizontalMidX()
        {
            _squares[0][1].Value = NoughtCrossToken.X;
            _squares[1][1].Value = NoughtCrossToken.X;
            _squares[2][1].Value = NoughtCrossToken.X;
            var result = _victoryCalculator.IsGameWon(_squares);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CalculatorVictoryHorizontalLowerX()
        {
            _squares[0][0].Value = NoughtCrossToken.X;
            _squares[1][0].Value = NoughtCrossToken.X;
            _squares[2][0].Value = NoughtCrossToken.X;
            var result = _victoryCalculator.IsGameWon(_squares);
            Assert.IsTrue(result);
        }



        [TestMethod]
        public void CalculatorVictoryVerticalLeftO()
        {
            _squares[0][0].Value = NoughtCrossToken.O;
            _squares[0][1].Value = NoughtCrossToken.O;
            _squares[0][2].Value = NoughtCrossToken.O;
            var result = _victoryCalculator.IsGameWon(_squares);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CalculatorVictoryHorizontalTopO()
        {
            _squares[0][2].Value = NoughtCrossToken.O;
            _squares[1][2].Value = NoughtCrossToken.O;
            _squares[2][2].Value = NoughtCrossToken.O;
            var result = _victoryCalculator.IsGameWon(_squares);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CalculatorVictoryDiagonalTopLeftToRightO()
        {
            _squares[0][2].Value = NoughtCrossToken.O;
            _squares[1][1].Value = NoughtCrossToken.O;
            _squares[2][0].Value = NoughtCrossToken.O;
            var result = _victoryCalculator.IsGameWon(_squares);
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void CalculatorVictoryDiagonalTopRightToLeftO()
        {
            _squares[2][2].Value = NoughtCrossToken.O;
            _squares[1][1].Value = NoughtCrossToken.O;
            _squares[0][0].Value = NoughtCrossToken.O;
            var result = _victoryCalculator.IsGameWon(_squares);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CalculatorVictoryVerticalMidO()
        {
            _squares[1][0].Value = NoughtCrossToken.O;
            _squares[1][1].Value = NoughtCrossToken.O;
            _squares[1][2].Value = NoughtCrossToken.O;
            var result = _victoryCalculator.IsGameWon(_squares);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CalculatorVictoryVerticalRightO()
        {
            _squares[2][0].Value = NoughtCrossToken.O;
            _squares[2][1].Value = NoughtCrossToken.O;
            _squares[2][2].Value = NoughtCrossToken.O;
            var result = _victoryCalculator.IsGameWon(_squares);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CalculatorVictoryHorizontalMidO()
        {
            _squares[0][1].Value = NoughtCrossToken.O;
            _squares[1][1].Value = NoughtCrossToken.O;
            _squares[2][1].Value = NoughtCrossToken.O;
            var result = _victoryCalculator.IsGameWon(_squares);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CalculatorVictoryHorizontalLowerO()
        {
            _squares[0][0].Value = NoughtCrossToken.O;
            _squares[1][0].Value = NoughtCrossToken.O;
            _squares[2][0].Value = NoughtCrossToken.O;
            var result = _victoryCalculator.IsGameWon(_squares);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CalculatorVictoryNoWinnerTwoMoves()
        {
            _squares[0][0].Value = NoughtCrossToken.X;
            _squares[1][1].Value = NoughtCrossToken.O;
            var result = _victoryCalculator.IsGameWon(_squares);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CalculatorVictoryNoWinnerFourMoves()
        {
            _squares[0][1].Value = NoughtCrossToken.X;
            _squares[2][1].Value = NoughtCrossToken.O;
            _squares[1][1].Value = NoughtCrossToken.X;
            _squares[2][2].Value = NoughtCrossToken.O;
            var result = _victoryCalculator.IsGameWon(_squares);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CalculatorVictoryNoWinnerSixMoves()
        {
            _squares[0][1].Value = NoughtCrossToken.X;
            _squares[2][1].Value = NoughtCrossToken.O;
            _squares[1][1].Value = NoughtCrossToken.X;
            _squares[2][2].Value = NoughtCrossToken.O;
            _squares[0][0].Value = NoughtCrossToken.X;
            _squares[1][2].Value = NoughtCrossToken.O;
            var result = _victoryCalculator.IsGameWon(_squares);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CalculatorVictoryNoWinnerSixMovesAlt()
        {
            _squares[0][2].Value = NoughtCrossToken.X;
            _squares[1][1].Value = NoughtCrossToken.O;
            _squares[2][0].Value = NoughtCrossToken.X;
            _squares[1][2].Value = NoughtCrossToken.O;
            _squares[1][0].Value = NoughtCrossToken.X;
            _squares[2][1].Value = NoughtCrossToken.O;
            var result = _victoryCalculator.IsGameWon(_squares);
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void CalculatorVictoryWinnerXFiveMoves()
        {
            _squares[0][2].Value = NoughtCrossToken.X;
            _squares[1][2].Value = NoughtCrossToken.O;
            _squares[1][1].Value = NoughtCrossToken.X;
            _squares[2][1].Value = NoughtCrossToken.O;
            _squares[2][0].Value = NoughtCrossToken.X;
            var result = _victoryCalculator.IsGameWon(_squares);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CalculatorVictoryWinnerOSevenMoves()
        {
            _squares[1][1].Value = NoughtCrossToken.O;
            _squares[0][2].Value = NoughtCrossToken.X;
            _squares[2][2].Value = NoughtCrossToken.O;
            _squares[0][0].Value = NoughtCrossToken.X;
            _squares[0][1].Value = NoughtCrossToken.O;
            _squares[1][2].Value = NoughtCrossToken.X;
            _squares[2][1].Value = NoughtCrossToken.O;
            var result = _victoryCalculator.IsGameWon(_squares);
            Assert.IsTrue(result);
        }



    }
}
