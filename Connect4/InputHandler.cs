
namespace Connect4
{
    public class InputHandler
    {
        public InputHandler()
        {
        }

        public static void InitialiseGame()
        {
            var game = new Game();
            game.GameIntro();
            game.PlayGame();
        }
        
        public static void RestartGame()
        {
            var game = new Game();
            game.RestartGame();
            game.PlayGame();
        }
    }
}
