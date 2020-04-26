using System;

namespace Connect4
{
    public class InputHandler
    {

        public InputHandler()
        {
        }

        public void InitialiseGame()
        {
            Game game = new Game();
            game.GameIntro();
        }
    }
}
