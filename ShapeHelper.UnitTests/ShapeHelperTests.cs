using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ShapeHelper.Exceptions;
using ShapeHelper.Shapes;

namespace ShapeHelper.UnitTests
{
    class ShapeHelperTests
    {
        [Test]
        public void CommonUsage() //немножко дублируем, но эти тесты больше для того, чтобы показать, как работает библиотека
        {
            var helper = new ShapeHelper();

            var circleSquare = helper.ForCircle(5).GetSquare();
            var triangleSquare = helper.ForTriangle(5, 5, 5).GetSquare();

            Assert.IsTrue(Math.Abs(78.53981 - circleSquare) < TestConsts.Epsilon);
            Assert.IsTrue(Math.Abs(10.825317547305 - triangleSquare) < TestConsts.Epsilon);
        }

        [Test]
        public void NewFigure()
        {
            var helper = new ShapeHelper();
            var rectangle = new Rectangle(5, 5);

            var square = helper.For(rectangle).GetSquare();

            Assert.AreEqual(25, square);
        }

        //я подозреваю, что имелось в виду, что мы оперируем не конкретным типом, а абстракцией,
        //иначе появляются вопросы касательно того, как задавать фигуру с неизвестным типом.
        //Если это не так, то хотелось бы узнать, что именно имелось в виду :)
        [Test]
        public void UnknownType()
        {
            var helper = new ShapeHelper();
            IShape shape = new Rectangle(5, 5);

            var square = helper.For(shape).GetSquare();

            Assert.AreEqual(25, square);
        }

        class Rectangle : IShape
        {
            private readonly double _a;
            private readonly double _b;

            public Rectangle(double a, double b)
            {
                if (a <= 0 || b <= 0)
                    throw new WrongShapeParameterException(this.GetType(), "side", "стороны должны быть заданы положительным числом");

                _a = a;
                _b = b;
            }

            public double GetSquare()
            {
                var result = _a * _b;

                if (double.IsInfinity(result))
                    throw new VariableOverflowException();

                return result;
            }
        }
    }
}
