using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameComponents.Board;
using GameComponents.DTOs;
using GameComponents.Player;
using GameComponents.Enum;

namespace GameComponents.Game
{
    public abstract class AbstractGame : IGame
    {
        protected List<IGamePlayer> _players;
        protected IGameBoard _board;
        protected int _gameTurn;
        protected IGamePlayer _winner;
        protected Guid _playerTurn;

        public virtual List<IGamePlayer> Players => _players;
        public virtual IGameBoard Board => _board;
        public virtual int GameTurn => _gameTurn;
        public virtual IGamePlayer Winner => _winner;
        public virtual Guid PlayerTurn => _playerTurn;

        public AbstractGame(List<IGamePlayer> players, IGameBoard board, Guid playerOneId, NoughtCrossToken playerOneToken)
        {
            _players = players;
            _board = board;
            if (_players.Count != 2)
                throw new ArgumentException("Invalid number of players");

            if(board.GetBoard().Length != 3 ||
                board.GetBoard()[0].Length != 3 ||
                board.GetBoard()[1].Length != 3 ||
                board.GetBoard()[2].Length != 3)
                throw new ArgumentException("Invalid board size");

            if(_players.Find(e => e.Id == playerOneId) == null)
                throw new ArgumentException("Player One not present");

            foreach (var player in _players)
            {
                if (player.Id == playerOneId)
                    player.SetPlayerToken(playerOneToken);
                else
                {
                    if (playerOneToken == NoughtCrossToken.X)
                        player.SetPlayerToken(NoughtCrossToken.O);
                    else
                        player.SetPlayerToken(NoughtCrossToken.X);
                }
                    
            }

            _gameTurn = 0;
            _winner = null;
            _playerTurn = playerOneId;

        }


        public virtual TurnReportDTO PlayTurn(int x, int y)
        {
            throw new NotImplementedException();
        }


    }
}
