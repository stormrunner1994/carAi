using System;
using System.Drawing;

namespace CarAI
{
    public static class Helper
    {
        public static double CalcDistance(Point point1, Point point2)
        {
            double x1 = Math.Pow(point1.X - point2.X, 2);
            double x2 = Math.Pow(point1.Y - point2.Y, 2);
            double z = Math.Sqrt(x1 + x2);
            return z;
        }

    }
}
