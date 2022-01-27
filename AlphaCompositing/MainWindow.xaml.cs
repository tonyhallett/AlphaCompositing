using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace AlphaCompositing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<FrameworkElement> overlayElements = new();
        private readonly List<FrameworkElement> calculatedElements = new();

        private readonly IMaterialColours colours;
        private readonly IMaterialColoursProvider colourProvider = new XmlMaterialColoursProvider(@"C:\Users\tonyh\AppData\Local\Packages\E45135E7-70B8-46D3-8947-D1E9D1156AC3_mgp0fqb9ck8de\LocalCache\myTheme.xml");
        private readonly IColourElementsProvider colourElementsProvider = new ColourElementsProvider();
        private readonly IComparisonSurfaceColourSampler comparisonColourSampler = new ComparisonSurfaceColourSampler();
        private readonly IComparisonSurfaceColourLogger comparisonColourLogger = new DebugComparisonSurfaceColourLogger();
        public MainWindow()
        {
            InitializeComponent();

            colours = colourProvider.Provide();
            ShowComparisonElevatedSurfaces();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            comparisonColourLogger.Log(comparisonColourSampler.Sample(overlayElements, calculatedElements));
        }

        private void CreateComparisonElevatedSurfaces(bool isLight, List<float> alphas)
        {
            var stackPanel = new StackPanel();
            var calculated = isLight ? colours.CalculatedLight! : colours.CalculatedDark!;
            var surfaceColour = isLight ? colours.SurfaceLight! : colours.SurfaceDark!;
            var primaryColour = isLight ? colours.PrimaryLight! : colours.PrimaryDark!;
            var count = 0;
            alphas.ForEach(alpha =>
            {
                var overlay = colourElementsProvider.CreateOverlay(alpha, surfaceColour, primaryColour);
                overlayElements.Add(overlay);

                var calculatedElement = colourElementsProvider.CreateColorElement(calculated[count]);
                calculatedElements.Add(calculatedElement);

                var comparisonRow = new StackPanel { Orientation = Orientation.Horizontal };
                comparisonRow.Children.Add(overlay);
                comparisonRow.Children.Add(calculatedElement);
                stackPanel.Children.Add(comparisonRow);

                count++;
            });
            panel.Children.Add(stackPanel);
        }

        private void ShowComparisonElevatedSurfaces()
        {
            var alphas = ElevationAlphas.Get();
            CreateComparisonElevatedSurfaces(true, alphas);
            CreateComparisonElevatedSurfaces(false, alphas);
        }

    }
}
