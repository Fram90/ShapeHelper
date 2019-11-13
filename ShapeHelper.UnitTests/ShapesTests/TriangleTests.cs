using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ShapeHelper.Exceptions;
using ShapeHelper.Shapes;

namespace ShapeHelper.UnitTests.ShapesTests
{
    class TriangleTests
    {
        [Test]
        public void WhenAllParams_AreGreaterThanZero_CreatesSuccessfully()
        {
            Assert.DoesNotThrow(() => new Triangle(3, 4, 5));
        }

        [TestCase(-1, 1, 1)]
        [TestCase(1, -1, 1)]
        [TestCase(1, 1, -1)]
        [TestCase(0, 1, 1)]
        [TestCase(1, 0, 1)]
        [TestCase(1, 1, 0)]
        [TestCase(double.PositiveInfinity, 1, 1)]
        public void WhenAnyParam_IsLowerOrEqualsZeroOrIntinity_Throws(double a, double b, double c)
        {
            Assert.Throws<WrongShapeParameterException>(() => new Triangle(a, b, c));
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

        [Test]
        public void When_WrongSidesPassed_Throws()
        {
            Assert.Throws<WrongShapeParameterException>(() => new Triangle(10, 1, 1));
        }

        [Test]
        public void When_GetSquareHasVariableOverflow_Throws()
        {
            var circle = new Triangle(double.MaxValue, double.MaxValue, double.MaxValue);

            Assert.Throws<VariableOverflowException>(() => circle.GetSquare());
        }

        [Test]
        public void GetSquare_CalculatesCorrectly()
        {
            var triangle = new Triangle(5, 5, 5);

            Assert.IsTrue(Math.Abs(10.825317547305 - triangle.GetSquare()) < TestConsts.Epsilon); //значение для сравнение берем из какого-нибудь авторитетного источника. Например, посчитаем на бумажке :)
        }
    }
}
