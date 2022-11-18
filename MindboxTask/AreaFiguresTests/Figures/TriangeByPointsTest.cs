using AreaFiguresLibrary;
using AreaFiguresLibrary.Additionally;
using AreaFiguresLibrary.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaFiguresTests.Figures
{
    public class TriangeByPointsTest
    {
        [Fact]
        public void CreateTriangleByPoints_Uncorrect()
        {
            var pointA = new CoordOfPoint(1, 0);
            var pointB = new CoordOfPoint(3, 0);
            var pointC = new CoordOfPoint(2, 0);

            (double, double) tupleA = (1.5, 0);
            (double, double) tupleB = (1.5, 0);
            (double, double) tupleC = (3, 2.5);

            Assert.Throws<ArgumentException>(() => { Figure figureTriangle = new TriangeByPoints(pointA, pointB, pointC); });
            Assert.Throws<ArgumentException>(() => { TriangeByPoints figureTriangle = new TriangeByPoints(tupleA, tupleB, tupleC); });
        }

        [Fact]
        public void IsRight()
        {
            var rightTriangle = new TriangeByPoints(new CoordOfPoint(0, 5), new CoordOfPoint(0, 0), new CoordOfPoint(5, 0));
            var notRightTriangle = new TriangeByPoints((1, 2), (2, 4), (3, 3));

            bool rightResult = rightTriangle.IsRight();
            bool notRightResult = notRightTriangle.IsRight();

            Assert.True(rightResult);
            Assert.False(notRightResult);
        }

        [Fact]
        public void GetArea()
        {
            CoordOfPoint pointA = new(0, 5);
            CoordOfPoint pointB = new(0, 0);
            CoordOfPoint pointC = new(5, 0);

            var vectorAB = pointA.GetVector(pointB);
            var vectorAC = pointA.GetVector(pointC);
            var expected = CoordOfPoint.VectorProductModule(vectorAB, vectorAC) / 2;

            var triangle = new TriangeByPoints(pointA, pointB, pointC);
            var result = triangle.Area;

            Assert.Equal(expected, result);
        }
    }
}
