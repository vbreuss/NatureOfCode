using NatureOfCode.Base.UI;

namespace NatureOfCode.Base
{
    public interface IAnimation<TItem> where TItem : CanvasItem
    {
        AnimationResult Animate(TItem item);
    }
}
