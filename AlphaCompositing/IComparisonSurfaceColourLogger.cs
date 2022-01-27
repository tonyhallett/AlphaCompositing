using System.Collections.Generic;
using System.Windows.Media;

namespace AlphaCompositing
{
    public interface IComparisonSurfaceColourLogger
    {
        void Log(List<(Color overlayColor, Color calculatedColor)> surfaceComparisonColours);
    }
}
