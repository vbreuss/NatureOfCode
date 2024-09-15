namespace NatureOfCode.Base
{
    public class CanvasItem : ICanvasItem
    {
        public double X { get; }
        public double Y { get; }
        public CanvasItem(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
