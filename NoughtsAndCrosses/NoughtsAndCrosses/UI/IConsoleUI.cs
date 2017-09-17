using GameComponents.Board;
using GameComponents.Enum;
using GameComponents.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrosses.UI
{
    public interface IConsoleUI
    {
        void DisplayStartScreen();

        bool DisplayReadyScreen();

        List<IGamePlayer> DisplayEnterPlayersScreen();

        NoughtCrossToken DisplayEnterPlayerOneTokenScreen();

        void DisplayBoardScreen(IGameBoard gameBoard);

        int[] DisplayEnterMoveScreen(IGamePlayer player);

        void DisplayGameOverScreen(IGamePlayer player);
    }
}
