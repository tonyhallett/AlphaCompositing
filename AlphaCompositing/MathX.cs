using System;

namespace AlphaCompositing
{
    public static class MathX
    {
        public static double log1p(double x)
        {
            return Math.Log(x + 1);
        }
    }
}
