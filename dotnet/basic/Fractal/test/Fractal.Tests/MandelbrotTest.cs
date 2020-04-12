using Xunit;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.APIGatewayEvents;

using Fractal;
using System.Collections.Generic;

namespace Fractal.Tests
{
    public class MandelbrotTest
    {

        public MandelbrotTest()
        {
        }

        [Theory]
        [InlineData(1000, 0.0, 0.0, 1000)]
        [InlineData(3000, 0.0, 0.0, 3000)]
        [InlineData(1000, 0.0, -1.0, 1000)]
        [InlineData(1000, 2.0, 2.0, 0)]
        [InlineData(1000, 1.0, 0.0, 2)]
        [InlineData(1000, 0.1, 0.0, 1000)]
        public void TestCalculatePoint(int iterations, double x, double y, int expected)
        {
            var actual = Mandelbrot.CalculatePoint(iterations, x, y);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCalculateArea()
        {
            // Arrange
            var iterations = 1000;
            var bottomLeftX = 0.0;
            var bottomLeftY = 0.0;
            var topRightX = 1.0;
            var topRightY = 1.0;
            var stepX = 10;
            var stepY = 10;

            //Act
            var result = Mandelbrot.CalculateArea(iterations, bottomLeftX, bottomLeftY, topRightX, topRightY, stepX, stepY);

            // Assert
            Assert.Equal(10, result.Count);
            Assert.Equal(10, result[0].Count);
        }

        [Theory]
        [InlineData(0.0, 1.0, 10, new double[] {0.0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9})]
        [InlineData(0.0, 0.3, 3, new double[] {0.0, 0.1, 0.2})]
        public void TestGetSteps(double start, double end, int steps, double[] expected)
        {
            var actual = new List<double>(Mandelbrot.GetSteps(start, steps, (end - start)/steps)).ToArray();

            Assert.Equal(expected.Length, actual.Length);
            for (int i=0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], actual[i], 5);
            }
        }
    }
}
