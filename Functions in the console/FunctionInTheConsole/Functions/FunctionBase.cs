namespace FunctionInTheConsole.Functions
{
    public abstract class FunctionBase
    {
        public abstract double Calculate(double value);

        public abstract FunctionBase GetDerivative();
    }
}