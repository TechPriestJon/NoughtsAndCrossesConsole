using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameComponents.Enum;
using GameComponents.Squares;

namespace GameComponents.Board
{
    public class GameBoard : IGameBoard
    {
        private IGameSquare[][] _squares;

        public GameBoard(IGameSquare[][] squares)
        {
            _squares = squares;
        }

        public IGameSquare[][] GetBoard()
        {
            return _squares;
        }

        public NoughtCrossToken? GetSquare(int x, int y)
        {
            return _squares[x][y].Value;
        }

        public void SetSquare(int x, int y, NoughtCrossToken value)
        {
            try
            {
                _squares[x][y].Value = value;
            }
            catch(Exception e)
            {
                if(e.GetType() == typeof(InvalidOperationException))
                {
                    throw new InvalidOperationException("Cannot set square: " + e.Message);
                }
            }
        }
    }
}
