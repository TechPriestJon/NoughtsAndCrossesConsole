using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameComponents.Board;
using GameComponents.Enum;
using GameComponents.Player;

namespace NoughtsAndCrosses.UI
{
    public class ConsoleUI : IConsoleUI
    {
        private IGameBoard _gameBoard;

        public ConsoleUI()
        {

        }

        public void DisplayBoardScreen(IGameBoard gameBoard)
        {
            Console.WriteLine("/*/*/*/*/*/*");
            _gameBoard = gameBoard;
            var squares = _gameBoard.GetBoard();
            Console.WriteLine();
            Console.Write("y ");
            for (var i = 0; i < squares[0].Length; i++)
            {
                Console.Write("= ");
            }
            Console.WriteLine(" ");

            for (var i = 0; i < squares.Length; i++)
            {
                var k = (2 - i);
                Console.Write(k.ToString() + "|");
                for (var j = 0; j < squares[i].Length; j++)
                {
                    var l = (2 - j);
                    var token = _gameBoard.GetSquare(j,k);
                    if (token == null)
                        Console.Write(" ");
                    else if (token == NoughtCrossToken.X)
                        Console.Write("X");
                    else if (token == NoughtCrossToken.O)
                        Console.Write("O");

                    if(j != (squares[i].Length - 1))
                    {
                        Console.Write("|");
                    }
                }
                Console.WriteLine("|");
                if (i != (squares.Length - 1))
                {
                    Console.WriteLine("  = = = ");
                }
            }

            Console.Write("  ");
            for (var i = 0; i < squares[0].Length; i++)
            {
                Console.Write("= ");
            }
            Console.Write(" ");

            Console.WriteLine();
            Console.Write("x ");
            for (var i = 0; i < squares[0].Length; i++)
            {
                Console.Write(i.ToString() + " ");
            }
            Console.WriteLine();
            Console.WriteLine("/*/*/*/*/*/*");
            Console.WriteLine();
        }

        public int[] DisplayEnterMoveScreen(IGamePlayer player)
        {
            int[] moves = new int[2];
            Console.WriteLine("Player:" + player.Name);
            Console.WriteLine("X value:");
            var input = Console.ReadLine();
            int x;
            if (int.TryParse(input.Trim().ToLower(),out x))
            {
                moves[0] = x;
            }
            else
            {
                InvalidInput();
                DisplayEnterMoveScreen(player);
            }

            Console.WriteLine("Y value:");
            int y;
            input = null;
            input = Console.ReadLine();
            if (int.TryParse(input.Trim().ToLower(), out y))
            {
                moves[1] = y;
            }
            else
            {
                InvalidInput();
                DisplayEnterMoveScreen(player);
            }
            return moves;
        }

        public NoughtCrossToken DisplayEnterPlayerOneTokenScreen()
        {
            Console.WriteLine("Enter Player 1 O or X: ");
            var input = Console.ReadLine().Trim();
            NoughtCrossToken token;
            if (input.Trim().ToLower() == "x")
            {
                token = NoughtCrossToken.X;
                return token;
            }
            else if (input.Trim().ToLower() == "o")
            {
                token = NoughtCrossToken.O;
                return token;
            }
            else
            {
                InvalidInput();
                DisplayEnterPlayerOneTokenScreen();
            }
            throw new InvalidProgramException();
        }

        public List<IGamePlayer> DisplayEnterPlayersScreen()
        {
            List<IGamePlayer> gamePlayers = new List<IGamePlayer>();
            Console.WriteLine("Enter Player 1 Name: ");
            var playerOneName = Console.ReadLine().Trim();
            gamePlayers.Add(new GamePlayer(playerOneName));
            Console.WriteLine("Enter Player 2 Name: ");
            var playerTwoName = Console.ReadLine().Trim();
            gamePlayers.Add(new GamePlayer(playerTwoName));
            return gamePlayers;
        }

        public void DisplayGameOverScreen(IGamePlayer winner)
        {
            Console.WriteLine();
            Console.WriteLine("/*/*/*/*/*/*");
            Console.WriteLine("---Game Over!---");
            Console.WriteLine("---Player " + winner.Name + " Wins!---");
            Console.WriteLine("---PlayAgain?---");
            Console.WriteLine("/*/*/*/*/*/*");
            Console.WriteLine();
        }

        public bool DisplayReadyScreen()
        {
            Console.WriteLine("Play Game? Y/N");
            var input = Console.ReadLine();
            if (input.Trim().ToLower() == "n")
            {
                Console.WriteLine("Press Q to Exit:");
                input = null;
                input = Console.ReadLine();
                if (input.Trim().ToLower() == "q")
                {
                    Environment.Exit(0);
                }
                else
                {
                    DisplayReadyScreen();
                }
            }
            else if (input.Trim().ToLower() == "y")
                return true;
            else
            {
                InvalidInput();
                DisplayReadyScreen();
            }
            return false;
        }
        
        public void DisplayStartScreen()
        {
            Console.WriteLine("---NOUGHTS & CROSSES!---");
            Console.WriteLine("---Aka Tic Tac Toe---");
            //DisplayBoard();
            Console.WriteLine("---Ready To Play!---");
        }

        private void InvalidInput()
        {
            Console.WriteLine("Invalid Input. Try Again.");
        }

        private void InvalidMove()
        {
            Console.WriteLine("You Can't Place Your Token There. Try Again.");
        }
    }
}
