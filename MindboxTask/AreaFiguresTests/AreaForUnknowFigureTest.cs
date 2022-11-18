using AreaFiguresLibrary;
using AreaFiguresLibrary.Additionally;

namespace AreaFiguresTests
{
    public class AreaForUnknowFigureTest
    {
        [Fact]
        public void AreaCalculate_UncorrectParams()
        {
            var points = new CoordOfPoint[] { new CoordOfPoint(1, 3), new CoordOfPoint(11, 12) };
            var pairs = new (double, double)[] { (17, 21), (24, 11) };

            Assert.Throws<Exception>(() => AreaForUnknowFigure.AreaCalculate(points));
            Assert.Throws<Exception>(() => AreaForUnknowFigure.AreaCalculate(pairs));
        }

        [Fact]
        public void AreaCalculate_CorrectParams()
        {
            var trianglePoints = new CoordOfPoint[] { new CoordOfPoint(1, 1), new CoordOfPoint(2, 4), new CoordOfPoint(5, 3) };
            var pentagonPairs = new (double, double)[] { (-2, -1), (-1, 1), (1, 2), (3, 1), (2, -2) };

            double triangleResult = AreaForUnknowFigure.AreaCalculate(trianglePoints);
            double pentagonResult = AreaForUnknowFigure.AreaCalculate(pentagonPairs);

            Assert.Equal(5, triangleResult);
            Assert.Equal(12.5, pentagonResult);
        }

        [Fact]
        public void FindArea_IdenticalParams()
        {
            var IdenticalPoints = new CoordOfPoint[] { new CoordOfPoint(1, 1), new CoordOfPoint(1, 1), new CoordOfPoint(1, 1) };
            var IdenticalPairs = new (double, double)[] { (-2, -1), (-2, -1), (-2, -1) };

            double IdenticalPointsResult = AreaForUnknowFigure.AreaCalculate(IdenticalPoints);
            double IdenticalPairsResult = AreaForUnknowFigure.AreaCalculate(IdenticalPairs);

            Assert.Equal(0, IdenticalPointsResult);
            Assert.Equal(0, IdenticalPairsResult);
        }
    }
}
