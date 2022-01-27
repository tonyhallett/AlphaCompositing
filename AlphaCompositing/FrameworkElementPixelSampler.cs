using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AlphaCompositing
{
    public static class FrameworkElementPixelSampler
    {
        public static Color Sample(FrameworkElement uiElement)
        {
            var renderTargetBitmap = new RenderTargetBitmap((int)uiElement.ActualWidth,
                                                          (int)uiElement.ActualHeight,
                                                          96, 96, PixelFormats.Default);
            ModifyPosition(uiElement);
            renderTargetBitmap.Render(uiElement);
            ModifyPositionBack(uiElement);

            var croppedBitmap = new CroppedBitmap(renderTargetBitmap,
                                                  new Int32Rect(1, 1, 1, 1));

            var pixels = new byte[4];
            croppedBitmap.CopyPixels(pixels, 4, 0);

            return Color.FromArgb(255, pixels[2], pixels[1], pixels[0]);
        }
        public static void ModifyPosition(FrameworkElement fe)
        {
            /// get the size of the visual with margin
            var fs = new Size(
            fe.ActualWidth +
            fe.Margin.Left + fe.Margin.Right,
            fe.ActualHeight +
            fe.Margin.Top + fe.Margin.Bottom);
            /// measure the visual with new size
            fe.Measure(fs);
            /// arrange the visual to align parent with (0,0)
            fe.Arrange(new Rect(
            -fe.Margin.Left, -fe.Margin.Top,
            fs.Width, fs.Height));
        }

        public static void ModifyPositionBack(FrameworkElement fe)
        {
            /// remeasure a size smaller than need, wpf will
            /// rearrange it to the original position
            fe.Measure(new Size());
        }

    }
}
