using System.Collections.Generic;
using System.Threading;
using Turtle.Library.ReadModels;

namespace Turtle.Library.Models
{
    public class Game
    {
        private Point turtleStartPoint;
        private FileReader fileReader;
        private Setting settings;
        private Grid grid;
        private Observer observer;

        #region Factory method
        private Game()
        {
            this.fileReader = FileReader.Instance();
            this.settings = this.fileReader.GetSettings();
            this.turtleStartPoint = this.settings.StartPoint;
            this.grid = new Grid(this.settings.BoardSize.Y, this.settings.BoardSize.X);
            this.observer = new Observer(this.grid);
            this.Initialize();
        }

        public static Game CreateNewGame()
        {
            return new Game();
        }
        #endregion

        public void Start()
        {
            List<string> moves = this.settings.Moves;
            Turtle turtle = this.grid[this.turtleStartPoint] as Turtle;

            if (System.Enum.TryParse<Directions>(this.settings.Direction, out Directions direction))
            {
                turtle.Direction = direction;
            }
            Printer.Print(turtle);

            for (int i = 0; i < moves.Count; i++)
            {
                if (moves[i] == "R")
                {
                    turtle.Rotate();
                }
                else if (moves[i] == "M")
                {
                    turtle.Move();
                }
                Thread.Sleep(1000);
                State situation = this.observer.Observe(turtle.Position);
                if (situation == State.IsDead)
                {
                    Printer.Print(Printer.DEAD);
                    break;
                }
                else if (situation == State.IsExit)
                {
                    Printer.Print(Printer.SUCCESS);
                    break;
                }
                else if (situation == State.IsOutOfBounds)
                {
                    Printer.Print(Printer.OUT);
                }
                else if (situation == State.IsDanger)
                {
                    Printer.Print(Printer.IS_NEAR);
                }
            }
        }

        private void Initialize()
        {
            this.SetTurtle(this.turtleStartPoint);
            this.SetExit(this.settings.ExitPoint);
            this.SetMines(this.settings.MinePoints);
        }

        private void SetMines(List<Point> mines)
        {
            foreach (Point minePosition in mines)
            {
                try
                {
                    this.grid[minePosition] = new Mine()
                    {
                        Position = minePosition
                    };
                }
                catch
                {/*ignore*/ }
            }
        }

        private void SetExit(Point exitPosition)
        {
            try
            {
                this.grid[exitPosition] = new Exit()
                {
                    Position = exitPosition
                };
            }
            catch
            {/*ignore*/}
        }

        private void SetTurtle(Point turtlePosition)
        {
            try
            {
                this.grid[turtlePosition] = Turtle.Instance(turtlePosition);
            }
            catch
            {/*ignore*/}
        }
    }
}
