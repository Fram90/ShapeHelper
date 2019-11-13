﻿using System;
using System.Linq;
using ShapeHelper.Exceptions;

namespace ShapeHelper.Shapes
{
    public class Triangle : ITriangle
    {
        private readonly double _a;
        private readonly double _b;
        private readonly double _c;

        public Triangle(double a, double b, double c)
        {
            var sides = new[] { a, b, c, };

            if (sides.Any(x => x <= 0))
                throw new WrongShapeParameterException(this.GetType(), "side", "длины сторон должны быть заданы положительными числами");

            var ordered = sides.OrderBy(x => x).ToArray(); //для простоты. Если необходимо, можно и без Linq

            _a = ordered[0];
            _b = ordered[1];
            _c = ordered[2]; //максимальное значение - гипотенуза
        }

        public double GetSquare()
        {
            var p = 0.5 * (_a + _b + _c);
            var result = Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));

            if (double.IsInfinity(result))
                throw new VariableOverflowException();

            return result;
        }

        public bool IsRightTriangle()
        {
            return Math.Abs((_a * _a + _b * _b) - (_c * _c)) < 0.00001d;
        }
    }
}