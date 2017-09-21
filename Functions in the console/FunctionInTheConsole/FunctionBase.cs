namespace FunctionInTheConsole
{
    public abstract class FunctionBase
    {
        public abstract FunctionBase GetDerivative();

        public abstract double Calculate(double value);
    }
}
