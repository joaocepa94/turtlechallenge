using System.Threading;
using Turtle.Library.Models;

namespace Turtle.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = Game.CreateNewGame();
            game.Start();
            Thread.Sleep(30000);
            System.Console.ReadKey();
        }
    }
}
