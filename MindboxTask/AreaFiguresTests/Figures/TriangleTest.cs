using AreaFiguresLibrary.Figures;
using AreaFiguresLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaFiguresTests.Figures
{
    public class TriangleTest
    {
        [Fact]
        public void IsTriangle_Uncorrect()
        {
            const int testsCount = 3;
            var sitesA = new double[testsCount] { 2, 0, 19 };
            var sitesB = new double[testsCount] { -4, 11, 3 };
            var sitesC = new double[testsCount] { 2, 11, 2 };

            for (int i = 0; i < testsCount; i++)
            {
                double siteA = sitesA[i];
                double siteB = sitesB[i];
                double siteC = sitesC[i];

                Assert.Throws<ArgumentException>(() => { Triangle triangle = new Triangle(siteA, siteB, siteC); });
                Assert.Throws<ArgumentException>(() => { Figure figureTriangle = new Triangle(siteA, siteB, siteC); });
            }
        }

        [Fact]
        public void IsRight()
        {
            var rightTriangle = new Triangle(161, 240, 289);
            var notRightTriangle = new Triangle(12, 11, 13);

            bool rightResult = rightTriangle.IsRight();
            bool notRightResult = notRightTriangle.IsRight();

            Assert.True(rightResult);
            Assert.False(notRightResult);
        }

        [Fact]
        public void GetArea()
        {
            double siteA = 7;
            double siteB = 24;
            double siteC = 25;

            double halfPerimeter = (siteA + siteB + siteC) / 2;
            var expected = Math.Sqrt(halfPerimeter * (halfPerimeter - siteA) * (halfPerimeter - siteB) * (halfPerimeter - siteC));

            Triangle triangle = new Triangle(siteA, siteB, siteC);
            Figure figureTriangle = new Triangle(siteA, siteB, siteC);

            var triangleResult = triangle.Area;
            var figureResult = figureTriangle.Area;

            Assert.Equal(expected, triangleResult);
            Assert.Equal(expected, figureResult);
        }
    }
}
