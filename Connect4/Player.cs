
namespace Connect4
{
    public class Player
    {
        private readonly Counter counter;
        public Player(Counter counter)
        {
            this.counter = counter;
        }

        public Counter GetCounter()
        {
            return counter;
        }
    }
}
