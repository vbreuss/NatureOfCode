using System.Windows.Media.Imaging;

namespace NatureOfCode.Base.UI
{
    public class CanvasBitmap : CanvasItem
    {
        public CanvasBitmap(WriteableBitmap source) : base(0.0, 0.0)
        {
            Source = source;
        }

        public WriteableBitmap Source { get; }
    }
}
