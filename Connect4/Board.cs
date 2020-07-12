using System;

namespace Connect4
{
    public class Board
    {
        private readonly Counter[,] _board;
        private readonly int winCondition;

        public Board()
        {
            var rows = 6;
            var columns = 7;
            _board = new Counter[rows,columns];
            winCondition = 4;
        }

        public void PrintBoard()
        {
            for (var i = 0; i < _board.GetLength(0); i++)
            {
                for (var j = 0; j < _board.GetLength(1); j++)
                {
                    if (_board[i,j] == null)
                    {
                        Console.Write("|   ");
                    }
                    else
                    {
                        Console.Write("| ");

                        var counter = _board[i, j].GetCounter();
                        if (counter == "r")
                            Console.ForegroundColor = ConsoleColor.DarkRed;

                        if (counter == "y")
                            Console.ForegroundColor = ConsoleColor.DarkYellow;

                        Console.Write(counter + " ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                Console.WriteLine("|");
            }

            Console.WriteLine("  1   2   3   4   5   6   7");
        }

        public bool CanPlay()
        {
            for (var i = 0; i < _board.GetLength(0); i++)
            {
                for (var j = 0; j < _board.GetLength(1); j++)
                {
                    if (_board[i,j] == null)
                    {
                        return true;
                    }
                }
            }

            Console.WriteLine("No further moves available");
            return false;
        }

        public bool PlaceCounter(int position, Counter player)
        {
            var ixPosition = position - 1;
            if (ixPosition >= 0 && ixPosition <= _board.Length)
            {
                for (var i = _board.GetLength(0) - 1; i >= 0; i--)
                {
                    if (_board[i,ixPosition] == null)
                    {
                        _board[i,ixPosition] = new Counter(player.GetCounter());
                        return true;
                    }

                    if (i == 0 && _board[i,ixPosition] != null)
                    {
                        Console.WriteLine($"Invalid input: no moves available in this position");
                    }
                }
                return false;
            }
            Console.WriteLine("Invalid input: number must be between 1-7");
            return false;
        }

        public bool CheckWin(Counter counter)
        {
            if (!CheckDiagonal(counter) && !CheckHorizontal(counter) && !CheckVertical(counter)) return false;

            Console.WriteLine($"Game over: player {counter.GetCounter()} has won");
            return true;

        }

        public bool CheckHorizontal(Counter counter)
        {
            for (var i = 0; i < _board.GetLength(0); i++)
            {
                var count = 0;
                for (var j = 0; j < _board.GetLength(1); j++)
                {
                    if (_board[i,j] == null || _board[i,j].GetCounter() != counter.GetCounter())
                    {
                        count = 0;
                    } else
                    {
                        count++;
                        if (count == winCondition)
                        {
                            Console.WriteLine("Horizontal Win");
                            return true;
                        }

                    }
                }
            }
            return false;
        }

        public bool CheckVertical(Counter counter)
        {
            for (var i = _board.GetLength(0) - 1; i >= 0; i--)
            {
                var count = 0;
                for (var j = 0; j < _board.GetLength(0); j++)
                {
                    if (_board[j,i] == null || _board[j,i].GetCounter() != counter.GetCounter())
                    {
                        count = 0;
                    }
                    else
                    {
                        count++;
                        if (count == winCondition)
                        {
                            Console.WriteLine("vertical Win");
                            return true;
                        }

                    }
                }
            }
            return false;
        }

        public bool CheckDiagonal(Counter counter)
        {
            int x;
            int y;
            var count = 0;

            for (var row = 0; row < 6; row++)
            {
                for (var col = 0; col < 7; col++)
                {
                    x = col;
                    y = row;

                    // ------------- check for a \ diagonal win ---------------------
                    while (x < _board.GetLength(1) && y < _board.GetLength(0))
                    {
                        if (_board[y, x] == null || _board[y, x].GetCounter() != counter.GetCounter())
                        {
                            count = 0;
                        }
                        else
                        {
                            count++;
                            if (count == winCondition)
                            {
                                Console.WriteLine("diagonal win");
                                return true;
                            }
                        }

                        x++;
                        y++;
                    }

                    // ------------- check for a / diagonal win ---------------------
                    x = col;
                    y = row;
                    count = 0;
                    while (x < _board.GetLength(1) && y >= 0 && y < _board.GetLength(0))
                    {
                        if (_board[y, x] == null || _board[y, x].GetCounter() != counter.GetCounter())
                        {
                            count = 0;
                        }
                        else
                        {
                            count++;
                            if (count == winCondition)
                            {
                                Console.WriteLine("diagonal win");
                                return true;
                            }
                        }

                        y--;
                        x++;
                    }
                }
            }

            return false;
        }
    }
}
