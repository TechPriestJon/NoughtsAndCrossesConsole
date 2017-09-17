using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameComponents.Squares;
using GameComponents.Enum;
using GameComponents.Board;
using GameComponents.Game;
using GameComponents.Player;
using System.Collections.Generic;

namespace GameComponentsUnitTests
{
    [TestClass]
    public class GameTests
    {
        private IGameEngine _Game;
        private IGameSquare[][] _squares;
        private IGameBoard _board;
        private List<IGamePlayer> _players;
        private IGamePlayer _playerOne;
        private IGameVictoryCalculator _victoryCalculator;

        [TestInitialize]
        public void InitiateGameResources()
        {
            _squares = new GameSquare[3][];
            for (int i = 0; i < 3; i++)
            {
                _squares[i] = new GameSquare[3];
                for (int j = 0; j < 3; j++)
                {
                    _squares[i][j] = new GameSquare();
                }
            }

            _board = new GameBoard(_squares);

            _playerOne = new GamePlayer("Alice");

            _players = new List<IGamePlayer>()
            {
                _playerOne,
                new GamePlayer("Bob")
            };
            var playerOneToken = NoughtCrossToken.X;
            _victoryCalculator = new GameVictoryCalculator(GameWinStates.GetStates());
            _Game = new GameEngine(_players, _board, _playerOne.Id, playerOneToken, _victoryCalculator);
            _playerOne.SetPlayerToken(playerOneToken);

        }

        [TestMethod]
        public void EnsurePlayersAreInitialised()
        {
            var gamePlayers = _Game.Players;
            Assert.AreEqual(_players.Count,gamePlayers.Count);
            foreach(var player in _players)
            {
                Assert.AreEqual(player.Id, gamePlayers.Find(e => e.Name == player.Name).Id);
            }
            
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ThrowErrorOnOnlyOnePlayer()
        {
            var players = new List<IGamePlayer>()
            {
                _playerOne
            };
            var playerOneToken = NoughtCrossToken.X;
            _Game = new GameEngine(players, _board, _playerOne.Id, playerOneToken, _victoryCalculator);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ThrowErrorOnPlayerOneMissing()
        {
            var players = new List<IGamePlayer>()
            {
                new GamePlayer("Sam"),
                new GamePlayer("Bob")
            };
            var playerOneToken = NoughtCrossToken.X;
            _Game = new GameEngine(players, _board, _playerOne.Id, playerOneToken, _victoryCalculator);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ThrowErrorOnTooManyPlayers()
        {
            var players = new List<IGamePlayer>()
            {
                _playerOne,
                new GamePlayer("Bob"),
                new GamePlayer("Sam")
            };
            var playerOneToken = NoughtCrossToken.X;
            _Game = new GameEngine(players, _board, _playerOne.Id, playerOneToken, _victoryCalculator);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ThrowErrorOnWrongBoard()
        {
            var playerOneToken = NoughtCrossToken.X;

            var squares = new GameSquare[4][];
            for (int i = 0; i < 4; i++)
            {
                squares[i] = new GameSquare[4];
                for (int j = 0; j < 4; j++)
                {
                    squares[i][j] = new GameSquare();
                }
            }
            var board = new GameBoard(squares);
            _Game = new GameEngine(_players, board, _playerOne.Id, playerOneToken, _victoryCalculator);
        }

        [TestMethod]
        public void EnsureWinnerIsInitialised()
        {
            var winner = _Game.Winner;
            Assert.IsNull(winner);
        }

        [TestMethod]
        public void EnsureGameTurnIsInitialised()
        {
            var gameTurn = _Game.GameTurn;
            Assert.AreEqual(0, gameTurn);
        }

        [TestMethod]
        public void EnsurePlayerTurnIsInitialised()
        {
            var playerTurn = _Game.PlayerTurn;
            Assert.AreEqual(_playerOne.Id, playerTurn);
        }

        [TestMethod]
        public void PlaySingleTurn()
        {
            var x = 0;
            var y = 0;
            var playerTurn = _Game.PlayerTurn;
            var gameTurn = 1;

            var report = _Game.PlayTurn(x, y);

            Assert.AreEqual(true, report.Success);
            Assert.AreEqual(x, report.x);
            Assert.AreEqual(y, report.y);
            Assert.AreEqual(gameTurn, report.GameTurn);
            Assert.AreNotEqual(gameTurn, _Game.GameTurn);
            Assert.AreEqual(playerTurn, report.Player);
            Assert.AreNotEqual(playerTurn, _Game.PlayerTurn);
            Assert.AreEqual(Guid.Empty,report.Winner);
            Assert.IsNull(_Game.Winner);
            Assert.AreEqual(GameState.InProgress, report.GameState);
        }

        [TestMethod]
        public void PlayTwoTurns()
        {
            var x = 0;
            var y = 0;
            var playerTurn = _Game.PlayerTurn;
            var gameTurn = 1;
            var report = _Game.PlayTurn(x, y);

            Assert.AreEqual(true, report.Success);
            Assert.AreEqual(x, report.x);
            Assert.AreEqual(y, report.y);
            Assert.AreEqual(gameTurn, report.GameTurn);
            Assert.AreNotEqual(gameTurn, _Game.GameTurn);
            Assert.AreEqual(playerTurn, report.Player);
            Assert.AreNotEqual(playerTurn, _Game.PlayerTurn);
            Assert.AreEqual(Guid.Empty, report.Winner);
            Assert.IsNull(_Game.Winner);
            Assert.AreEqual(GameState.InProgress, report.GameState);

            var xTurnTwo = 2;
            var yTurnTwo = 1;
            var gameTurnTwo = _Game.GameTurn;
            var playerTurnTwo = _Game.PlayerTurn;
            var reportTurnTwo = _Game.PlayTurn(xTurnTwo, yTurnTwo);

            Assert.AreEqual(true, reportTurnTwo.Success);
            Assert.AreEqual(xTurnTwo, reportTurnTwo.x);
            Assert.AreEqual(yTurnTwo, reportTurnTwo.y);
            Assert.AreEqual(gameTurnTwo, reportTurnTwo.GameTurn);
            Assert.AreNotEqual(gameTurnTwo, _Game.GameTurn);
            Assert.AreEqual(playerTurnTwo, reportTurnTwo.Player);
            Assert.AreNotEqual(playerTurnTwo, _Game.PlayerTurn);
            Assert.AreEqual(Guid.Empty, reportTurnTwo.Winner);
            Assert.IsNull(_Game.Winner);
            Assert.AreEqual(GameState.InProgress, report.GameState);

            Assert.AreNotEqual(report.Player, reportTurnTwo.Player);
            Assert.AreNotEqual(report.GameTurn, reportTurnTwo.GameTurn);
            Assert.AreNotEqual(report.x, reportTurnTwo.x);
            Assert.AreNotEqual(report.y, reportTurnTwo.y);
        }


        [TestMethod]
        public void PlayToPlayerOneWin()
        {
            _Game.PlayTurn(0, 0);
            _Game.PlayTurn(2, 0);
            _Game.PlayTurn(0, 1);
            _Game.PlayTurn(2, 1);
            var report = _Game.PlayTurn(0, 2);

            Assert.AreEqual(true, report.Success);
            Assert.AreEqual(_playerOne.Id, report.Winner);
            Assert.AreEqual(GameState.Won, report.GameState);
            Assert.AreEqual(_playerOne.Id, _Game.Winner.Id);
        }

        [TestMethod]
        public void PlayerAlreadyPlayedSquare()
        {
            _Game.PlayTurn(0, 0);
            var report = _Game.PlayTurn(0, 0);

            Assert.AreEqual(false, report.Success);
        }

        [TestMethod]
        public void PlayAfterGameWon()
        {
            _Game.PlayTurn(0, 0);
            _Game.PlayTurn(2, 0);
            _Game.PlayTurn(0, 1);
            _Game.PlayTurn(2, 1);
            _Game.PlayTurn(0, 2);
            var report = _Game.PlayTurn(2, 2);

            Assert.AreEqual(false, report.Success);
            Assert.AreEqual(GameState.Won, report.GameState);
            Assert.AreEqual(_playerOne.Id, report.Winner);
            Assert.AreEqual(_playerOne.Id, _Game.Winner.Id);
        }

        [TestMethod]
        public void PlayToPlayerTwoWin()
        {
            var playerTwoId = _players.Find(e => e.Id != _playerOne.Id).Id;
            _Game.PlayTurn(0, 2);
            _Game.PlayTurn(1, 1);
            _Game.PlayTurn(1, 2);
            _Game.PlayTurn(2, 2);
            _Game.PlayTurn(2, 0);
            var report = _Game.PlayTurn(0, 0);

            Assert.AreEqual(true, report.Success);
            Assert.AreEqual(playerTwoId, report.Winner);
            Assert.AreEqual(GameState.Won, report.GameState);
            Assert.AreEqual(playerTwoId, _Game.Winner.Id);
        }
    }
}
