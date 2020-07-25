
namespace Connect4
{
    public class InputHandler
    {
        public InputHandler()
        {
        }

        public static void InitialiseGame()
        {
            new Game();
        }
        
        public static void RestartGame()
        {
            var game = new Game();
            game.RestartGame();
        }
    }
}
