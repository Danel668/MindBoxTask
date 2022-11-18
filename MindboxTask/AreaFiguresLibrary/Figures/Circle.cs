﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaFiguresLibrary.Figures 
{
    public class Circle : Figure
    {
        private readonly double _radius;
        public Circle(double radius)
        {
            if (radius < 0)
                throw new ArgumentException("Radius must be more than 0");

            _radius = radius;
        }
        protected override double CalculateArea()  
            => Math.PI * _radius * _radius;
    }
}

