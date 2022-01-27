using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace AlphaCompositing
{
    public interface IComparisonSurfaceColourSampler
    {
        List<(Color overlayColor, Color calculatedColor)> Sample(List<FrameworkElement> overlayElements, List<FrameworkElement> calculatedElements);
    }
}
