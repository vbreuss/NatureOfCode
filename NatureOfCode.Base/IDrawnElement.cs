using NatureOfCode.Base.UI;

namespace NatureOfCode.Base
{
    public interface IDrawnElement<TItem> where TItem : CanvasItem
    {
        TItem Item { get; }

        IDrawnElement<TItem> WithAnimation(IAnimation<TItem> animation);
    }
}