namespace Turtle.Library.Models
{
    public class Grid
    {
        private Element[][] Elements;

        public int Width { get; private set; }
        public int Height { get; private set; }

        public Grid(int x, int y)
        {
            this.Width = y;
            this.Height = x;

            this.Elements = new Element[x][];
            for (int i = 0; i < x; i++)
            {
                this.Elements[i] = new Element[y];
                for (int j = 0; j < y; j++)
                {
                    this.Elements[i][j] = new Element()
                    {
                        Position = new Point
                        {
                            X = i,
                            Y = j
                        }
                    };
                }
            }
        }
        
        #region Indexers
        public Element this[int index1, int index2]
        {
            get { return this.Elements[index1][index2]; }
            set { this.Elements[index1][index2] = value; }
        }

        public Element this[Point p]
        {
            get { return this.Elements[p.X][p.Y]; }
            set { this.Elements[p.X][p.Y] = value; }
        } 
        #endregion
    }
}
