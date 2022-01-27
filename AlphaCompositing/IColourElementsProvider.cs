using System.Windows;

namespace AlphaCompositing
{
    public interface IColourElementsProvider
    {
        FrameworkElement CreateColorElement(string hex);
        FrameworkElement CreateOverlay(float opacity, string surfaceColour, string primaryColour);
    }
}
