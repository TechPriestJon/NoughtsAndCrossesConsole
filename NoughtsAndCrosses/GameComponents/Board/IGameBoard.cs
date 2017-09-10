using GameComponents.Enum;
using GameComponents.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.Board
{
    public interface IGameBoard
    {
        IGameSquare[][] GetBoard();

        void SetSquare(int x, int y, NoughtCrossToken value);

        NoughtCrossToken? GetSquare(int x, int y);
    }
}
