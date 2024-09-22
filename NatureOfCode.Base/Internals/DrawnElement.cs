using NatureOfCode.Base.UI;

namespace NatureOfCode.Base.Internals
{
    internal class DrawnElement<TItem> : IDrawnElement<TItem>
         where TItem : CanvasItem
    {
        private readonly CanvasDrawer _canvasDrawer;

        public DrawnElement(CanvasDrawer canvasDrawer, TItem item)
        {
            _canvasDrawer = canvasDrawer;
            Item = item;
        }

        public TItem Item { get; }

        public IDrawnElement<TItem> WithAnimation(IAnimation<TItem> animation)
        {
            _canvasDrawer.StartAnimation(this, animation);
            return this;
        }
    }
}