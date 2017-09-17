using GameComponents.Game;
using NoughtsAndCrosses.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrosses.Builder
{
    public abstract class BaseConsoleGameBuilder : IConsoleGameBuilder
    {
        protected IGameEngine _gameEngine;
        protected IConsoleUI _ui;

        public BaseConsoleGameBuilder(IConsoleUI ui)
        {
            _ui = ui;
        }

        public virtual void StartGame()
        {
            throw new NotImplementedException();
        }
    }
}
