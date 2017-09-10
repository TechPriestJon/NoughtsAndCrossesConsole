using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameComponents.Enum;

namespace GameComponents.Player
{
    public class GamePlayer : IGamePlayer
    {
        private NoughtCrossToken? _token;
        private string _name;
        private Guid _id;

        public NoughtCrossToken? Token { get => _token; }
        public string Name { get => _name; }
        public Guid Id { get => _id; }

        public GamePlayer(string name)
        {
            _name = name;
            var id = Guid.NewGuid();
            _id = id;
        }

        public void SetPlayerToken(NoughtCrossToken token)
        {
            _token = token;
        }
    }
}
