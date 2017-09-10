using GameComponents.Board;
using GameComponents.DTOs;
using GameComponents.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.Game
{
    public interface IGame
    {
        List<IGamePlayer> Players { get; }
        IGameBoard Board { get; }
        int GameTurn { get; }
        IGamePlayer Winner { get; }
        Guid PlayerTurn { get; }
        
        TurnReportDTO PlayTurn(int x, int y);
    }
}
