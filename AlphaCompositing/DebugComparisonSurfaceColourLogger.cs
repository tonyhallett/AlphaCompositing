using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Media;

namespace AlphaCompositing
{
    public class DebugComparisonSurfaceColourLogger : IComparisonSurfaceColourLogger
    {
        public void Log(List<(Color overlayColor, Color calculatedColor)> surfaceComparisonColours)
        {
            foreach (var (overlayColor, calculatedColor) in surfaceComparisonColours)
            {
                Debug.WriteLine($"{overlayColor.ToRgb()}, {calculatedColor.ToRgb()}");
            }
        }
    }
}
