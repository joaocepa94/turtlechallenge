using System;
using Turtle.Library.Models;
using Turtle.Library.Strategy;

namespace Turtle.Library
{
    public static class Printer
    {
        public const string DEAD = "Our poor turtle is dead";
        public const string OUT = "Turtle went out of bounds";
        public const string IS_NEAR = "Danger is near!";
        public const string SUCCESS = "Success";

        public static string startString = "Starting Position of Turtle: ({x},{y}), Direction: {dir}";
        public static string movedFromTo = "Turtle moved from position {from} to {to}";
        public static string rotate = "Turned to {to}";

        public static void Print(Point pointFrom, Point pointTo)
        {
            ColorContext context = new ColorContext(new Yellow());
            context.ContextInterface();
            string combinePointFrom = $"({pointFrom.X},{pointFrom.Y})";
            string combinePointTo = $"({pointTo.X},{pointTo.Y})";
            string printText = movedFromTo.Replace("{from}", combinePointFrom).Replace("{to}", combinePointTo);
            Console.WriteLine(printText);
            ColorContext contextWhite = new ColorContext(new White());
            contextWhite.ContextInterface();
            Console.WriteLine(new string('-', 50));
        }

        public static void Print(string text)
        {
            ColorContext contextGreen = new ColorContext(new Green());
            contextGreen.ContextInterface();
            Console.WriteLine(text);
            ColorContext contextWhite = new ColorContext(new White());
            contextWhite.ContextInterface();
            Console.WriteLine(new string('-', 50));
        }

        public static void Print(Directions dir)
        {
            ColorContext contextGreen = new ColorContext(new Green());
            contextGreen.ContextInterface();
            Console.WriteLine(rotate.Replace("{to}", dir.ToString()));
            ColorContext contextWhite = new ColorContext(new White());
            contextWhite.ContextInterface();
            Console.WriteLine(new string('-', 50));
        }

        public static void Print(Turtle.Library.Models.Turtle turtle)
        {
            ColorContext contextGreen = new ColorContext(new Green());
            contextGreen.ContextInterface();
            Console.WriteLine(startString.Replace("{x}", turtle.Position.X.ToString()).Replace("{y}",
                turtle.Position.Y.ToString()).Replace("{dir}", turtle.Direction.ToString()));
            ColorContext contextWhite = new ColorContext(new White());
            contextWhite.ContextInterface();
            Console.WriteLine(new string('-', 50));
        }
    }
}
