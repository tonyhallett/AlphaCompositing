using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AlphaCompositing
{
    public class ColourElementsProvider : IColourElementsProvider
    {
        public FrameworkElement CreateColorElement(string hex)
        {
            var length = 30;
            return new Rectangle
            {
                Width = length,
                Height = length,
                Fill = new SolidColorBrush(ColorHelpers.FromHex(hex)),
            };
        }

        private FrameworkElement CreateOpacityElement(string hex, float opacity)
        {
            var rect = CreateColorElement(hex);
            rect.Opacity = opacity;
            return rect;
        }


        public FrameworkElement CreateOverlay(float opacity, string surfaceColour, string primaryColour)
        {
            var grid = new Grid
            {
            };
            grid.Children.Add(CreateColorElement(surfaceColour));
            grid.Children.Add(CreateOpacityElement(primaryColour, opacity));
            return grid;
        }
    }
}
