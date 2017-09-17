using GameComponents.Enum;
using GameComponents.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.Game
{
    public class GameVictoryCalculator : IGameVictoryCalculator<GameSquare>
    {
        private List<GameSquare[,]> _winStates;

        public GameVictoryCalculator(List<GameSquare[,]> winStates)
        {
            _winStates = winStates;
        }

        public bool IsGameWon(IGameSquare[][] gameState)
        {
            ValidGameStateCheck(gameState);
            var result = false;
            var formattedGameStateX = FormatGameState(gameState,NoughtCrossToken.X);
            var formattedGameStateO = FormatGameState(gameState, NoughtCrossToken.O);

            result = CalculateWin(formattedGameStateX);
            if(!result)
                result = CalculateWin(formattedGameStateO);

            return result;
        }

        private bool CalculateWin(GameSquare[,] gameState)
        {
            bool winResult = false;
            foreach(var winState in _winStates)
            {
                var count = 0;
                for (int i = 0; i < winState.GetLength(0); i++)
                {
                    for (int j = 0; j < winState.GetLength(1); j++)
                    {
                        if (winState[i, j].Value != null &&
                            gameState[i, j].Value == winState[i, j].Value)
                            count++;
                    }
                }
                if (count == 3)
                    winResult = true;
            }

            return winResult;
        }


        private void ValidGameStateCheck(IGameSquare[][] gameState)
        {
            for(var i = 0; i < gameState.Length; i++)
            {
                for (var j = 0; j < gameState[i].Length; j++)
                {
                    if (gameState[i][j].GetType() != typeof(GameSquare))
                        throw new ArrayTypeMismatchException("Array must be of type GameSquare");
                }
            }
        }

        private GameSquare[,] FormatGameState(IGameSquare[][] gameState, NoughtCrossToken token)
        {
            var maxLength = 0;
            for (int i = 0; i < 3; i++)
            {
                if (gameState[i].Length > maxLength)
                    maxLength = gameState[i].Length;
            }

            var formattedGameState = new GameSquare[gameState.Length, maxLength];
            for (int i = 0; i < gameState.Length; i++)
            {
                for (int j = 0; j < gameState[i].Length; j++)
                {
                    formattedGameState[i, j] = new GameSquare();
                    if (gameState[i][j].Value == token)
                        formattedGameState[i, j].Value = NoughtCrossToken.X;
                }
                for (int j = gameState[i].Length; j < maxLength; j++)
                {
                    formattedGameState[i, j] = new GameSquare();
                }
            }

            return formattedGameState;
        }
    }
}
