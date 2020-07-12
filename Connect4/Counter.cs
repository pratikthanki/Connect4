
namespace Connect4
{
    public class Counter
    {
        private readonly string counter;

        public Counter(string counter)
        {
            this.counter = counter;
        }

        public string GetCounter()
        {
            return counter;
        }
    }
}
