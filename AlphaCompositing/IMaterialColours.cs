using System.Collections.Generic;

namespace AlphaCompositing
{
    interface IMaterialColours
    {
        string PrimaryLight { get; }
        string PrimaryDark { get; }
        string SurfaceLight { get; }
        string SurfaceDark { get; }

        List<string> CalculatedLight { get; }
        List<string> CalculatedDark { get; }
    }
}
