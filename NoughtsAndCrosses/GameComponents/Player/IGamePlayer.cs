using GameComponents.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.Player
{
    public interface IGamePlayer
    {
        NoughtCrossToken? Token { get; }
        string Name { get; }
        Guid Id { get; }

        void SetPlayerToken(NoughtCrossToken token);
    }
}
