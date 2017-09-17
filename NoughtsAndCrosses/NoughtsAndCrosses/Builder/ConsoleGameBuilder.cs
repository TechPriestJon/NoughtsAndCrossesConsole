using GameComponents.Board;
using GameComponents.Enum;
using GameComponents.Game;
using GameComponents.Player;
using GameComponents.Squares;
using NoughtsAndCrosses.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrosses.Builder
{
    public class ConsoleGameBuilder : BaseConsoleGameBuilder, IConsoleGameBuilder
    {
        public ConsoleGameBuilder(IConsoleUI ui): base(ui)
        {
            ui.DisplayStartScreen();
            bool startGame = false;
            while(startGame == false)
            {
                startGame = ui.DisplayReadyScreen();
            }
            List<IGamePlayer> players = ui.DisplayEnterPlayersScreen();
            NoughtCrossToken token = ui.DisplayEnterPlayerOneTokenScreen();
            IGameSquare[][] squares = new GameSquare[3][];
            for (int i = 0; i < 3; i++)
            {
                squares[i] = new GameSquare[3];
                for (int j = 0; j < 3; j++)
                {
                    squares[i][j] = new GameSquare();
                }
            }
            IGameBoard board = new GameBoard(squares);
            _gameEngine = new GameEngine(players,board,players[0].Id,token,new GameVictoryCalculator(GameWinStates.GetStates()));
        }

        public override void StartGame()
        {
            while(_gameEngine.Winner == null)
            {
                _ui.DisplayBoardScreen(_gameEngine.Board);
                int[] move = _ui.DisplayEnterMoveScreen(_gameEngine.Players.Where(e => e.Id == _gameEngine.PlayerTurn).FirstOrDefault());
                if(move.Length == 2)
                {
                    _gameEngine.PlayTurn(move[0], move[1]);
                }
                else
                {

                }
            }
            _ui.DisplayGameOverScreen(_gameEngine.Winner);
        }
    }
}
