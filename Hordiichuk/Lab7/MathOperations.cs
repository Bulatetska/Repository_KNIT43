using System;
public delegate double OperationDelegate(double a, double b);

public class MathOperations
{
    public event EventHandler<OperationEventArgs> OnOperationPerformed;

    public double Add(double a, double b)
    {
        double result = a + b;
        RaiseOperationPerformed(result, "Addition");
        return result;
    }
    public double Multiply(double a, double b)
    {
        double result = a * b;
        RaiseOperationPerformed(result, "Multiplication");
        return result;
    }
    public double PerformOperation(double a, double b, OperationDelegate operation, string operationName)
    {
        double result = operation(a, b);
        RaiseOperationPerformed(result, operationName);
        return result;
    }

    protected virtual void RaiseOperationPerformed(double result, string operationName)
    {
        OnOperationPerformed?.Invoke(this, new OperationEventArgs(result, operationName));
    }
}