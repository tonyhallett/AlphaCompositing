using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace AlphaCompositing
{
    public class ComparisonSurfaceColourSampler : IComparisonSurfaceColourSampler
    {
        public List<(Color overlayColor, Color calculatedColor)> Sample(List<FrameworkElement> overlayElements, List<FrameworkElement> calculatedElements)
        {
            return overlayElements.Select((overlayElement, i) =>
            {
                var calculatedElement = calculatedElements[i];
                var overlayColor = FrameworkElementPixelSampler.Sample(overlayElement);
                var calculatedColor = FrameworkElementPixelSampler.Sample(calculatedElement);
                return (overlayColor, calculatedColor);

            }).ToList();
        }
    }
}
