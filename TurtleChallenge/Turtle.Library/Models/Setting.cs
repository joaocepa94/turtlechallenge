using System.Collections.Generic;
using Turtle.Library.Models;

namespace Turtle.Library.ReadModels
{
    public class Setting
    {
        public Point BoardSize { get; set; }
        public List<Point> MinePoints { get; set; } = new List<Point>();
        public Point ExitPoint { get; set; }
        public Point StartPoint { get; set; }
        public List<string> Moves { get; set; } = new List<string>();
        public string Direction { get; set; }
    }
}