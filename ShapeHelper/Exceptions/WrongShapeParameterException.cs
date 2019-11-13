using System;

namespace ShapeHelper.Exceptions
{
    public class WrongShapeParameterException : Exception
    {
        public WrongShapeParameterException(Type shapeType, string param, string reason) : base(
            $"Неверно указан параметр {param} для формы типа {shapeType.Name}: {reason}")
        {

        }
    }
}