using System;
using ShapeHelper.Exceptions;

namespace ShapeHelper.Shapes
{
    public class Circle : ICircle
    {
        private readonly double _radius;

        public Circle(double radius)
        {
            if (radius <= 0 || double.IsInfinity(radius)) //не допускаются вырожденные фигуры с радиусом, равным 0
                throw new WrongShapeParameterException(this.GetType(), nameof(radius), "радиус должен быть задан положительным числом");

            _radius = radius;
        }

        public double GetSquare()
        {
            var result = Math.PI * Math.Pow(_radius, 2); //возможно переполнение
            if (double.IsInfinity(result))
                throw new VariableOverflowException();

            return result;
        }
    }
}