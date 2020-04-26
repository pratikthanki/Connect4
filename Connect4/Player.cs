using System;

namespace Connect4
{
    public class Player
    {
        private Counter counter;
        public Player(Counter counter)
        {
            this.counter = counter;
        }

        public Counter GetCounter()
        {
            return this.counter;
        }
    }
}
