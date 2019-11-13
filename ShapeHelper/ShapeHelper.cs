using ShapeHelper.Shapes;

namespace ShapeHelper
{
    public class ShapeHelper
    {
        public TShape For<TShape>(TShape shape) where TShape : IShape
        {
            return shape;
        }

        //есть вариант вынести эти методы ForTriangle и ForCircle в экстеншн класс, и так было бы, пожалуй, концептуально правильнее,
        //но оставил тут, т.к. в требованиях эти 2 типа фигур указаны как основные. + есть трудности с тестированием экстеншн методов
        public ITriangle ForTriangle(double a, double b, double c)
        {
            return new Triangle(a, b, c);
        }

        public ICircle ForCircle(double r)
        {
            return new Circle(r);
        }
    }
}