using System.Collections.Generic;
using System.Linq;
using Turtle.Library.Models;

namespace Turtle.Library
{
    public class Observer
    {
        private int Width;
        private int Height;
        private Grid Grid;

        public Observer(Grid grid)
        {
            this.Width = grid.Width;
            this.Height = grid.Height;
            this.Grid = grid;
        }

        public State Observe(Point position)
        {
            if (IsExit(position))
            {
                return State.IsExit;
            }
            else if (IsDead(position))
            {
                return State.IsDead;
            }
            else if (IsOutOfBounds(position))
            {
                return State.IsOutOfBounds;
            }
            else if (IsDanger(position))
            {
                return State.IsDanger;
            }
            else
            {
                return State.Normal;
            }
        }

        private bool IsExit(Point position)
        {
            return this.Grid[position] is Exit;
        }

        private bool IsDead(Point position)
        {
            return this.Grid[position] is Mine;
        }

        private bool IsOutOfBounds(Point position)
        {
            return position.X < 0 || position.X >= this.Height || position.Y < 0 || position.Y >= this.Width;
        }

        public bool IsDanger(Point position)
        {
            List<Point> adjacentPoints = GetAdjacentPositions(position);
            return adjacentPoints.Any(x => this.Grid[position] is Mine);
        }

        private List<Point> GetAdjacentPositions(Point position)
        {
            List<Point> list = new List<Point>();

            if (position.X - 1 >= 0)
            {
                list.Add(new Point { X = position.X - 1, Y = position.Y });
            }
            if (position.X - 1 >= 0 && position.Y - 1 >= 0)
            {
                list.Add(new Point { X = position.X - 1, Y = position.Y - 1 });
            }
            if (position.X - 1 >= 0 && position.Y + 1 < this.Width)
            {
                list.Add(new Point { X = position.X - 1, Y = position.Y + 1 });
            }
            if (position.X + 1 < this.Height)
            {
                list.Add(new Point { X = position.X + 1, Y = position.Y });
            }
            if (position.X + 1 < this.Height && position.Y - 1 >= 0)
            {
                list.Add(new Point { X = position.X + 1, Y = position.Y - 1 });
            }
            if (position.X + 1 < this.Height && position.Y + 1 < this.Width)
            {
                list.Add(new Point { X = position.X + 1, Y = position.Y + 1 });
            }
            if (position.Y - 1 >= 0)
            {
                list.Add(new Point { X = position.X, Y = position.Y - 1 });
            }
            if (position.Y + 1 < this.Width)
            {
                list.Add(new Point { X = position.X, Y = position.Y + 1 });
            }
            return list;
        }
    }
}
