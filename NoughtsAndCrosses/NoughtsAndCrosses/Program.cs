using GameComponents.Game;
using NoughtsAndCrosses.Builder;
using NoughtsAndCrosses.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrossesConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            //MainAsync(args).Wait();
            //var gameEngine = new GameEngine();
            var ui = new ConsoleUI();

            //gameBuilder.Initialize();
            while (true)
            {
                IConsoleGameBuilder gameBuilder = new ConsoleGameBuilder(ui);
                gameBuilder.StartGame();
            }
        }

        //static async Task MainAsync(string[] args)
        //{
        //    await Task.CompletedTask;
        //}
    }
}
