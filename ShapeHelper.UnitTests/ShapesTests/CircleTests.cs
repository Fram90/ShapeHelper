using System;
using NUnit.Framework;
using ShapeHelper.Exceptions;
using ShapeHelper.Shapes;

namespace ShapeHelper.UnitTests.ShapesTests
{
    public class CircleTests
    {
        [Test]
        public void WhenRadius_IsGreaterThanZero_CreatesSuccessfully()
        {
            Assert.DoesNotThrow(() => new Circle(1));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(double.PositiveInfinity)]
        [TestCase(double.NegativeInfinity)]
        public void WhenRadius_IsLowerOrEqualsZeroOrInfinity_Throws(double r)
        {
            Assert.Throws<WrongShapeParameterException>(() => new Circle(r));
        }

        [Test]
        public void GetSquare_CalculatesCorrectly()
        {
            var circle = new Circle(5);

            Assert.IsTrue(Math.Abs(78.53981 - circle.GetSquare()) < TestConsts.Epsilon);
        }

        [Test]
        public void WhenGetSquare_HasVariableOverflow_Throws()
        {
            var circle = new Circle(double.MaxValue);

            Assert.Throws<VariableOverflowException>(() => circle.GetSquare());
        }
    }
}