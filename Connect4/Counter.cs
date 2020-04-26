using System;

namespace Connect4
{
    public class Counter
    {
        private String counter;

        public Counter(String counter)
        {
            this.counter = counter;
        }

        public String GetCounter()
        {
            return counter;
        }
    }
}
