namespace Turtle.Library.Strategy
{
    public class ColorContext
    {
        private Color Color;

        public ColorContext(Color color)
        {
            this.Color = color;
        }

        public void ContextInterface()
        {
            this.Color.ChangeColor();;
        }
    }
}
