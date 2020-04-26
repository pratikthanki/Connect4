using System;
using System.Collections.Generic;

namespace Connect4
{
    public class Game
    {
        private Board board;
        private List<Player> players = new List<Player>();
        string userInput;

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

        public void InitializePlayers()
        {
            Player player1 = new Player(new Counter("r"));
            Player player2 = new Player(new Counter("y"));

            players.Add(player1);
            players.Add(player2);
        }

        public void PlayGame()
        {
            int turn = 0;
            int retry = 1;

            while(board.CanPlay())
            {
                Player currentPlayer = players[turn % 2];
                userInput = Console.ReadLine();

                while (!ValidInput(userInput))
                {
                    userInput = Console.ReadLine();

                    retry++;
                    if (retry == 3)
                    {
                        Console.WriteLine("Error: 3 consecutive invalid moves, next players turn.");
                        break;
                    }
                }

                int position = Int32.Parse(userInput);
                bool valid = board.PlaceCounter(position, currentPlayer.GetCounter());

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
        }

        public bool ValidInput(string userInput)
        {
            try
            {
                int result = Int32.Parse(userInput);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Invalid input: unable to parse '{userInput}'");
                return false;
            }
            return true;
        }
    }
}
