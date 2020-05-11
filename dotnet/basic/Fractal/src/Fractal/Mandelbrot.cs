using System;
using System.Collections.Generic;

namespace Fractal
{
    public static class Mandelbrot
    {
        private static double ROOT_5 = Math.Sqrt(5);
        public static int CalculatePoint(int iterations, double x, double y)
        {
            double z1 = x;
            double z2 = y;
            double result = 0;
            for (int i = 0; i < iterations; i++)
            {
                result = Math.Sqrt(z1 * z1 + z2 * z2);

                if (result > ROOT_5)
                {
                    return i;
                }
                double z3 = z1*z1 - z2*z2 + x;
                z2 = 2*(z1*z2) + y;
                z1 = z3;
            }

            return iterations;
        }
        public static List<List<int>> CalculateArea(
            int iteratoins, 
            double bottomLeftX, 
            double bottomLeftY, 
            double topRightY, 
            double topRightX, 
            int stepX, 
            int stepY)
        {
            var result = new List<List<int>>(stepX);
            var stepXSize = (topRightX - bottomLeftX)/stepX;
            var stepYSize = (topRightY - bottomLeftY)/stepY;
            foreach(var x in GetSteps(bottomLeftX, stepX, stepXSize))
            {
                var row = new List<int>(stepY);
                result.Add(row);
                foreach(var y in GetSteps(bottomLeftY, stepY, stepYSize))
                {
                    row.Add(CalculatePoint(iteratoins, x, y));
                }
            }
            return result;
        }

        public static IEnumerable<double> GetSteps(double start, int steps, double stepSize)
        {
            var x = start;
            for (var i=0; i < steps; i++)
            {
                yield return x;
                x += stepSize;
            }
        }

    }
}