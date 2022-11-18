using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaFiguresLibrary
{
    public abstract class Figure
    {
        private readonly Lazy<double> area;

        public double Area { get => area.Value; }

        protected Figure()
        {
            area = new Lazy<double>(CalculateArea);
        }

        protected abstract double CalculateArea();
    }
}
