using GameComponents.Enum;
using GameComponents.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.Game
{
    public static class GameWinStates
    {
        public static List<GameSquare[,]> GetStates()
        {
            var states = new List<GameSquare[,]>();
            var winState = InitGameSquareArray();
            winState[0,0].Value = NoughtCrossToken.X;
            winState[1,0].Value = NoughtCrossToken.X;
            winState[2,0].Value = NoughtCrossToken.X;
            states.Add(winState);
            winState = null;
            winState = InitGameSquareArray();
            winState[0,1].Value = NoughtCrossToken.X;
            winState[1,1].Value = NoughtCrossToken.X;
            winState[2,1].Value = NoughtCrossToken.X;
            states.Add(winState);
            winState = null;
            winState = InitGameSquareArray();
            winState[0,2].Value = NoughtCrossToken.X;
            winState[1,2].Value = NoughtCrossToken.X;
            winState[2,2].Value = NoughtCrossToken.X;
            states.Add(winState);
            winState = null;
            winState = InitGameSquareArray();
            winState[0,0].Value = NoughtCrossToken.X;
            winState[0,1].Value = NoughtCrossToken.X;
            winState[0,2].Value = NoughtCrossToken.X;
            states.Add(winState);
            winState = null;
            winState = InitGameSquareArray();
            winState[1,0].Value = NoughtCrossToken.X;
            winState[1,1].Value = NoughtCrossToken.X;
            winState[1,2].Value = NoughtCrossToken.X;
            states.Add(winState);
            winState = null;
            winState = InitGameSquareArray();
            winState[2,0].Value = NoughtCrossToken.X;
            winState[2,1].Value = NoughtCrossToken.X;
            winState[2,2].Value = NoughtCrossToken.X;
            states.Add(winState);
            winState = null;
            winState = InitGameSquareArray();
            winState[0, 0].Value = NoughtCrossToken.X;
            winState[1, 1].Value = NoughtCrossToken.X;
            winState[2, 2].Value = NoughtCrossToken.X;
            states.Add(winState);
            winState = null;
            winState = InitGameSquareArray();
            winState[2, 0].Value = NoughtCrossToken.X;
            winState[1, 1].Value = NoughtCrossToken.X;
            winState[0, 2].Value = NoughtCrossToken.X;
            states.Add(winState);
            return states;
        }

        private static GameSquare[,] InitGameSquareArray()
        {
            var gameState = new GameSquare[3,3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gameState[i,j] = new GameSquare();
                }
            }
            return gameState;
        }
    }
}
