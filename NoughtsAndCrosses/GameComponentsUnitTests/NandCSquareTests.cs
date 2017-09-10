using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameComponents.Squares;
using GameComponents.Enum;

namespace GameComponentsUnitTests
{
    [TestClass]
    public class NandCSquareTests
    {
        private INandCSquare _square;

        [TestMethod]
        public void SquareDefaultsNull()
        {
            _square = new NandCSquare();
            Assert.IsNull(_square.Value);
        }

        [TestMethod]
        public void SetSquareCross()
        {
            _square = new NandCSquare();
            _square.Value = NoughtCrossToken.X;
            Assert.AreEqual(NoughtCrossToken.X, _square.Value);
        }

        [TestMethod]
        public void SetSquareNought()
        {
            _square = new NandCSquare();
            _square.Value = NoughtCrossToken.O;
            Assert.AreEqual(NoughtCrossToken.O, _square.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SetSquareAlreadySetSquare()
        {
            _square = new NandCSquare();
            _square.Value = NoughtCrossToken.X;
            _square.Value = NoughtCrossToken.O;
        }
    }
}
