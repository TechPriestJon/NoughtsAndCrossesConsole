using GameComponents.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.Game
{
    public interface IGameVictoryCalculator
    {
        bool IsGameWon(IGameSquare[][] gameState);
    }

    public interface IGameVictoryCalculator<T> : IGameVictoryCalculator where T : IGameSquare
    {
        //bool IsGameWon(T[][] gameState);
    }
}
