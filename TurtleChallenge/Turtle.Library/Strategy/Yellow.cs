using System;

namespace Turtle.Library.Strategy
{
    public class Yellow : Color
    {
        public override void ChangeColor()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
    }
}
