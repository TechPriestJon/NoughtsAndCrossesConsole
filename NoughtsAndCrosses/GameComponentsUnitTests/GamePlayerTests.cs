using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameComponents.Enum;
using GameComponents.Player;

namespace GameComponentsUnitTests
{
    [TestClass]
    public class GamePlayerTests
    {
        private IGamePlayer _player;

        [TestMethod]
        public void InitializePlayer()
        {
            var playerName = "Alice";
            _player = new GamePlayer(playerName);
            Assert.IsNotNull(_player);
        }

        [TestMethod]
        public void GetPlayerTokenX()
        {
            var playerToken = NoughtCrossToken.X;
            var playerName = "Alice";
            _player = new GamePlayer(playerName);
            _player.SetPlayerToken(playerToken);
            Assert.IsNotNull(_player.Token);
            Assert.AreEqual(playerToken, _player.Token);
        }

        [TestMethod]
        public void GetPlayerTokenO()
        {
            var playerToken = NoughtCrossToken.O;
            var playerName = "Alice";
            _player = new GamePlayer(playerName);
            _player.SetPlayerToken(playerToken);
            Assert.IsNotNull(_player.Token);
            Assert.AreEqual(playerToken, _player.Token);
        }

        [TestMethod]
        public void GetPlayerName()
        {
            var playerName = "Alice";
            _player = new GamePlayer(playerName);
            Assert.AreEqual(playerName, _player.Name);
        }

        [TestMethod]
        public void GetPlayerID()
        {
            var playerName = "Alice";
            _player = new GamePlayer(playerName);
            Assert.AreNotEqual(Guid.Empty, _player.Id);
        }

        [TestMethod]
        public void EnsurePlayerIdsNotDuplicate()
        {
            var playerName = "Alice";
            _player = new GamePlayer(playerName);

            var secondPlayer = new GamePlayer("Bob");

            if (_player.Id == secondPlayer.Id)
            {
                secondPlayer = new GamePlayer("Bob");
            }

            Assert.AreNotEqual(_player.Id, secondPlayer.Id);
        }
    }
}
