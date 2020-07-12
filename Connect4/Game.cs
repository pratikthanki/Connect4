using System;
using System.Collections.Generic;

namespace Connect4
{
    public class Game
    {
        private readonly Board board;
        private readonly List<Player> players = new List<Player>();
        private string userInput;

        public Game()
        {
            board = new Board();
        }

        public void GameIntro()
        {
            Console.WriteLine("Welcome to Connect4!");
            Console.WriteLine("Enter a number to place a counter in that column.");
            board.PrintBoard();

            InitializePlayers();
            PlayGame();
        }

        public void RestartGame()
        {
            Console.WriteLine("New game started!");
            board.PrintBoard();

            InitializePlayers();
            PlayGame();
        }

        private void InitializePlayers()
        {
            var player1 = new Player(new Counter("r"));
            var player2 = new Player(new Counter("y"));

            players.Add(player1);
            players.Add(player2);
        }

        private void PlayGame()
        {
            var turn = 0;
            var retry = 1;

            while(board.CanPlay())
            {
                var currentPlayer = players[turn % 2];
                userInput = Console.ReadLine();

                while (!IsValidInput(userInput))
                {
                    userInput = Console.ReadLine();

                    retry++;
                    if (retry == 3)
                    {
                        Console.WriteLine("Error: 3 consecutive invalid moves, next players turn.");
                        break;
                    }
                }

                var position = Int32.Parse(userInput);
                var valid = board.PlaceCounter(position, currentPlayer.GetCounter());

                retry = 1;
                while (!valid)
                {
                    userInput = Console.ReadLine();
                    valid = board.PlaceCounter(position, currentPlayer.GetCounter());

                    retry++;
                    if (retry == 3)
                    {
                        Console.WriteLine("Error: 3 consecutive invalid moves, next players turn.");
                        break;
                    }
                }

                if (board.CheckWin(currentPlayer.GetCounter()))
                {
                    board.PrintBoard();
                    break;
                }

                board.PrintBoard();
                turn++;
                retry = 1;
            }
            
            PlayAgain();
        }

        private static bool IsValidInput(string userInput)
        {
            try
            {
                int.Parse(userInput);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Invalid input: unable to parse '{userInput}'");
                return false;
            }
            return true;
        }

        private void PlayAgain()
        {
            Console.WriteLine("Would you like to play again? [Y/N] Or Q to quit.");
            userInput = Console.ReadLine();

            if (userInput.ToUpper() == "Y")
            {
                InputHandler.InitialiseGame();
            }
            else if (userInput.ToUpper() == "N")
            {
                Console.WriteLine("Exiting the game.");
            }
            else if (userInput.ToUpper() == "Q")
            {
                Console.WriteLine("Shutting down..");
                return;
            }
            else
            {
                Console.WriteLine("Invalid input; enter Y or N.");
                PlayAgain();
            }
        }
    }
}
