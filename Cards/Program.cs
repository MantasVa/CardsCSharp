using Cards.Models;

namespace Cards
{
    class Program
    {
        static void Main()
        {
            var game = new Game();
            game.PlayGame();
            Player player = game.GetWinner();
        }
    }
}
