using AreaFiguresLibrary.Additionally;

namespace AreaFiguresLibrary.Figures
{
    public class TriangeByPoints : Figure
    {
        private readonly CoordOfPoint vectorAB;
        private readonly CoordOfPoint vectorAC;
        private readonly CoordOfPoint vectorBC;

        public TriangeByPoints((double, double) a, (double, double) b, (double, double) c)
        {
            vectorAB = new CoordOfPoint(a.Item1, a.Item2).GetVector(new CoordOfPoint(b.Item1, b.Item2));
            vectorAC = new CoordOfPoint(a.Item1, a.Item2).GetVector(new CoordOfPoint(c.Item1, c.Item2));
            vectorBC = new CoordOfPoint(b.Item1, b.Item2).GetVector(new CoordOfPoint(c.Item1, c.Item2));

            IsTriangle();
        }
        public TriangeByPoints(CoordOfPoint a, CoordOfPoint b, CoordOfPoint c)
        {
            vectorAB = a.GetVector(b);
            vectorAC = a.GetVector(c);
            vectorBC = b.GetVector(c);

            IsTriangle();
        }

        private void IsTriangle() 
        {
            if (CoordOfPoint.VectorProductModule(vectorAB, vectorAC) == 0) // если векторное произведения = 0, то sin = 0 => это не треугольник
                throw new ArgumentException("It's not a triangle");
        }

        public bool IsRight()
        {
            if (CoordOfPoint.ScalarProduct(vectorAC, vectorBC) == 0  // если скалярое произведения любых 2 векторов = 0, то cos = 0 => угол 90 градусов
                || CoordOfPoint.ScalarProduct(vectorAC, vectorAB) == 0
                || CoordOfPoint.ScalarProduct(vectorAB, vectorBC) == 0)
                return true;
            return false;
        }
        protected override double CalculateArea()
        {
           return CoordOfPoint.VectorProductModule(vectorAB, vectorAC) / 2;
        }
    }
}
