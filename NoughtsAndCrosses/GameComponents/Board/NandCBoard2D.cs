using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameComponents.Enum;
using GameComponents.Squares;

namespace GameComponents.Board
{
    public class NandCBoard2D : INandCBoard2D
    {
        private INandCSquare[][] _squares;

        public NandCBoard2D()
        {
            _squares = new NandCSquare[3][];
            for(int i = 0; i < 3; i++)
            {
                _squares[i] = new NandCSquare[3];
                for (int j = 0; j < 3; j++)
                {
                    _squares[i][j] = new NandCSquare();
                }
            }
        }

        public INandCSquare[][] GetBoard()
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
