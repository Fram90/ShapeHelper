using System;

namespace ShapeHelper.Exceptions
{
    public class VariableOverflowException : Exception
    {
        public VariableOverflowException() : base($"Произошло переполнение переменной. Данные потеряны.")
        {

        }
    }
}