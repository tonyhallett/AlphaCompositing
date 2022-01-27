using static System.Drawing.ColorTranslator;
using System.Windows.Media;

namespace AlphaCompositing
{
    public static class ColorHelpers
    {
        public static Color FromHex(string hex)
        {
            var dColor = FromHtml(hex);
            return Color.FromArgb(dColor.A, dColor.R, dColor.G, dColor.B);
        }
        
        public static string ToRgb(this Color color)
        {
            return $"rgb({color.R},{color.G},{color.B})";
        }
    }
}
