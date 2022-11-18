using AreaFiguresLibrary.Additionally;
namespace AreaFiguresLibrary
{
    public static class AreaForUnknowFigure
    {
        public static double AreaCalculate(params (double, double)[] tuples)
        {
            var points = tuples.Select(p => new CoordOfPoint(p.Item1, p.Item2)).ToArray();
            return AreaCalculate(points);
        }

        public static double AreaCalculate(params CoordOfPoint[] points) // Gauss's area formula
        {
            if (points.Length < 3)
                throw new Exception("Figure can`t contain less than 3 points");

            double sum = 0;
            int count = 0;

            foreach (var point in points)
            {
                sum += point.Y;
                count++;
            }

            double middle = sum / count;

            var UpperPoints = points.Where(p => p.Y > middle).OrderBy(p => -1 * p.X);
            var DownPoints = points.Where(p => p.Y <= middle).OrderBy(p => p.X);

            var AllPoints = DownPoints.Union(UpperPoints).ToArray();

            double doubleArea = 0;
            int module = AllPoints.Length;

            for (int i = 0; i < module; i++)
                doubleArea += AllPoints[i].X * AllPoints[(i + 1) % module].Y - AllPoints[(i + 1) % module].X * AllPoints[i].Y;

            return doubleArea / 2;
        }
    }
}
