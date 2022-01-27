using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace AlphaCompositing
{
    internal class XmlMaterialColoursProvider : IMaterialColoursProvider
    {
        private readonly string path;

        public XmlMaterialColoursProvider(string path)
        {
            this.path = path;
        }
        public class Colours : IMaterialColours
        {
            public Colours(string primaryLight, string primaryDark, string surfaceLight, string surfaceDark, List<string> calculatedLight, List<string> calculatedDark)
            {
                PrimaryLight = primaryLight;
                PrimaryDark = primaryDark;
                SurfaceLight = surfaceLight;
                SurfaceDark = surfaceDark;
                CalculatedLight = calculatedLight;
                CalculatedDark = calculatedDark;
            }

            public string PrimaryLight { get; set; }

            public string PrimaryDark { get; set; }

            public string SurfaceLight { get; set; }

            public string SurfaceDark { get; set; }

            public List<string> CalculatedLight { get; set; }

            public List<string> CalculatedDark { get; set; }
        }
        public IMaterialColours Provide()
        {
            var root = XElement.Load(path);

            var colorRoles = root.Descendants("ColorRole").Select(el => new { Role = el.Attribute("Role")!.Value, Color = el.Attribute("Color")!.Value });
            var primaryLight = colorRoles.First(cr => cr.Role == "Primary Light").Color;
            var primaryDark = colorRoles.First(cr => cr.Role == "Primary Dark").Color;
            var surfaceLight = colorRoles.First(cr => cr.Role == "Surface Light").Color;
            var surfaceDark = colorRoles.First(cr => cr.Role == "Surface Dark").Color;

            var overlays = root.Descendants("Overlay").Skip(1).ToList();
            var calculatedLight = overlays.Select(o => o.Attribute("Light")!.Value).ToList();
            var calculatedDark = overlays.Select(o => o.Attribute("Dark")!.Value).ToList();

            return new Colours(
                primaryLight,
                primaryDark,
                surfaceLight,
                surfaceDark,
                calculatedLight,
                calculatedDark
            );
        }
    }
}
