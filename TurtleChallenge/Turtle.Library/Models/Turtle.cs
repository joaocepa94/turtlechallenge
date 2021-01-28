namespace Turtle.Library.Models
{
    public class Turtle : Element
    {
        #region Singleton
        private static Turtle turtle;

        private Turtle(Point position)
        {
            this.Position = position;
        }

        public static Turtle Instance(Point position)
        {
            return turtle ?? (turtle = new Turtle(position));
        }
        #endregion

        public Directions Direction { get; set; }

        public void Move()
        {
            switch (this.Direction)
            {
                case Directions.North:
                    Point northDirection = new Point {
                        X = turtle.Position.X - 1,
                        Y = turtle.Position.Y
                    };
                    Printer.Print(turtle.Position, northDirection);
                    turtle.Position = northDirection;
                    break;
                case Directions.South:
                    Point southDirection = new Point
                    {
                        X = turtle.Position.X + 1,
                        Y = turtle.Position.Y
                    };
                    Printer.Print(turtle.Position, southDirection);
                    turtle.Position = southDirection;
                    break;
                case Directions.East:
                    Point eastDirection = new Point
                    {
                        X = turtle.Position.X,
                        Y = turtle.Position.Y + 1
                    };
                    Printer.Print(turtle.Position, eastDirection);
                    turtle.Position = eastDirection;
                    break;
                case Directions.West:
                    Point weastDirection = new Point
                    {
                        X = turtle.Position.X,
                        Y = turtle.Position.Y - 1
                    };
                    Printer.Print(turtle.Position, weastDirection);
                    turtle.Position = weastDirection;
                    break;
            }
        }

        public void Rotate()
        {
            switch (this.Direction)
            {
                case Directions.North:
                    this.Direction = Directions.East;
                    Printer.Print(this.Direction);
                    break;
                case Directions.South:
                    this.Direction = Directions.West;
                    Printer.Print(this.Direction);
                    break;
                case Directions.East:
                    this.Direction = Directions.South;
                    Printer.Print(this.Direction);
                    break;
                case Directions.West:
                    this.Direction = Directions.North;
                    Printer.Print(this.Direction);
                    break;
                default:
                    break;
            }
        }
    }
}
