using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameComponents.Board;
using GameComponents.DTOs;
using GameComponents.Player;
using GameComponents.Enum;
using GameComponents.Squares;

namespace GameComponents.Game
{
    public class Game : AbstractGame, IGame
    {
        public Game(List<IGamePlayer> players, IGameBoard board, Guid playerOneId, NoughtCrossToken playerOneToken) : base(players, board, playerOneId, playerOneToken)
        { }

        public override List<IGamePlayer> Players => _players;
        public override IGameBoard Board => _board;
        public override int GameTurn => _gameTurn;
        public override IGamePlayer Winner => _winner;
        public override Guid PlayerTurn => _playerTurn;

        public override TurnReportDTO PlayTurn(int x, int y)
        {
            if (_gameTurn == 0)
                _gameTurn = 1;

            var report = new TurnReportDTO()
            {
                GameState = GameState.InProgress,
                Player = _playerTurn,
                GameTurn = _gameTurn,
                Success = false,
                x = x,
                y = y,
                Winner = Guid.Empty
            };

            try
            {
                CalculateState(x, y);
                report.Success = true;
            }
            catch (Exception e)
            {
                report.Message = e.Message;
            }

            if (IsGameWon())
            {
                _winner = _players.Find(e => e.Id == report.Player);
                report.GameState = GameState.Won;
                report.Winner = _winner.Id;
            }
            else
            {
                _gameTurn++;
                _playerTurn = _players.Find(e => e.Id != report.Player).Id;
            }

            return report;
        }

        private void CalculateState(int x, int y)
        {
            NoughtCrossToken token;
            if (_players.Find(e => e.Id == _playerTurn).Token is NoughtCrossToken)
            {
                token = (NoughtCrossToken)_players.Find(e => e.Id == _playerTurn).Token;
                _board.SetSquare(x, y, token);
            }
            else
            {
                throw new ArgumentException("Player missing token");
            }
        }

        private bool IsGameWon()
        {
            return false;

        }

    }
}
