using NatureOfCode.Base.UI;
using System.Windows.Media;

namespace NatureOfCode.Base
{
    public static class Animation
    {
        public static IAnimation<CanvasCircle> FadeOut(int steps = 50)
            => new CircleFadeOutAnimation(steps);

        private class CircleFadeOutAnimation : IAnimation<CanvasCircle>
        {
            private double _stepSize;
            private int makeTransparentIn = 1;
            private bool skipFirstStep = true;

            public CircleFadeOutAnimation(int steps)
            {
                _stepSize = 1.0 / Math.Max(1, steps);
            }

            public AnimationResult Animate(CanvasCircle item)
            {
                if (skipFirstStep)
                {
                    skipFirstStep = false;
                    return AnimationResult.ContinueOnNextStep;
                }

                if (--makeTransparentIn == 0)
                {
                    item.BorderColor = item.FillColor;
                    item.BorderThickness = 1.0;
                    item.FillColor = new SolidColorBrush(Colors.Transparent);
                }
                item.Opacity -= _stepSize;
                if (item.Opacity <= 0.0)
                {
                    return AnimationResult.StopAnimationAndRemoveItem;
                }
                return AnimationResult.ContinueOnNextStep;
            }
        }
    }
}
