using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaFiguresLibrary.Additionally
{
    public class CoordOfPoint
    {
        public double X { get; set; }
        public double Y { get; set; }

        public CoordOfPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        public CoordOfPoint GetVector(CoordOfPoint end)
        {
            return  new CoordOfPoint(end.X - X, end.Y - Y);
        }

        public double GetVectorLenght(CoordOfPoint end)
        {
            var vectorCords = GetVector(end);
            return Math.Sqrt(vectorCords.X * vectorCords.X + vectorCords.Y * vectorCords.Y);
        }

        public static double ScalarProduct(CoordOfPoint vectorA, CoordOfPoint vectorB)
        {
           return vectorA.X * vectorB.X + vectorA.Y * vectorB.Y;
        }

        public static double VectorProductModule(CoordOfPoint vectorA, CoordOfPoint VectorB)
        {
           return vectorA.X * VectorB.Y - vectorA.Y * VectorB.X;
        }
    }
}
