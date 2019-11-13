using System;
using NUnit.Framework;
using ShapeHelper.Exceptions;
using ShapeHelper.Shapes;

namespace ShapeHelper.UnitTests
{
    public class ShapeTests
    {
        [Test]
        public void WhenShapeIsTriangle_AllParamsAreGreaterThanZero_CreatesSuccessfully()
        {
            Assert.DoesNotThrow(() => new Triangle(1, 2, 3));
        }

        [TestCase(-1, 1, 1)]
        [TestCase(1, -1, 1)]
        [TestCase(1, 1, -1)]
        [TestCase(0, 1, 1)]
        [TestCase(1, 0, 1)]
        [TestCase(1, 1, 0)]
        public void WhenShapeIsTriange_AnyParamIsLowerOrEqualsZero_Throws(double a, double b, double c)
        {
            Assert.Throws<WrongShapeParameterException>(() => new Triangle(a, b, c));
        }

        [Test]
        public void WhenShapeIsCircle_RadiusIsGreaterThanZero_CreatesSuccessfully()
        {
            Assert.DoesNotThrow(() => new Circle(1));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void WhenShapeIsCircle_RadiusIsLowerOrEqualsZero_Throws(double r)
        {
            Assert.Throws<WrongShapeParameterException>(() => new Circle(r));
        }

        [Test]
        public void WhenShapeIsTriangle_GetSquare_CalculatesCorrectly()
        {
            var triangle = new Triangle(5, 5, 5);

            Assert.IsTrue(Math.Abs(10.825317547305 - triangle.GetSquare()) < TestConsts.Epsilon); //значение для сравнение берем из какого-нибудь авторитетного источника. Например, посчитаем на бумажке :)
        }

        [Test]
        public void WhenShapeIsCircle_GetSquare_CalculatesCorrectly()
        {
            var circle = new Circle(5);

            Assert.IsTrue(Math.Abs(78.53981 - circle.GetSquare()) < TestConsts.Epsilon);
        }

        [Test]
        public void WhenTriangle_IsNotRight_ReturnsFalse()
        {
            var triangle = new Triangle(5, 5, 5);

            Assert.IsFalse(triangle.IsRightTriangle());
        }

        [Test]
        public void WhenTriangle_IsRightTriangle_ReturnsTrue()
        {
            var triangle = new Triangle(3, 4, 5);

            Assert.IsTrue(triangle.IsRightTriangle());
        }
    }
}