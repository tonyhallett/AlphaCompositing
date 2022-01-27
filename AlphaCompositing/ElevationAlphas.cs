using System;
using System.Collections.Generic;
using System.Linq;

namespace AlphaCompositing
{
    public static class ElevationAlphas
    {
        public enum ElevationLevel
        {
            Zero,
            /* 1 dp*/
            One,
            /* 3 dp*/
            Two,
            /* 6dp */
            Three,
            /* 8dp */
            Four,
            /* 12dp */
            Five
        }
        private static readonly float FORMULA_MULTIPLIER = 4.5f;
        private static readonly float FORMULA_OFFSET = 2f;
        private static Dictionary<ElevationLevel, float> ElevationLevelDps { get; } = new Dictionary<ElevationLevel, float>
        {
            { ElevationLevel.Zero, 0},
            { ElevationLevel.One, 1},
            { ElevationLevel.Two, 3},
            { ElevationLevel.Three, 6},
            { ElevationLevel.Four, 8},
            { ElevationLevel.Five, 12},
        };
        public static float calculateOverlayAlphaFraction(float elevation)
        {
            float elevationDp = elevation / 1;
            var logElevation = (float)MathX.log1p(elevationDp);
            float alphaFraction =
                (FORMULA_MULTIPLIER * logElevation + FORMULA_OFFSET) / 100;
            return Math.Min(alphaFraction, 1);
        }

        public static List<float> Get()
        {
            return Enum.GetValues(typeof(ElevationLevel)).Cast<ElevationLevel>().Skip(1).Select(elevationLevel => calculateOverlayAlphaFraction(ElevationLevelDps[elevationLevel])).ToList();
        }
    }
}
