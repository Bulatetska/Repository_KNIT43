using System;

namespace LabEightDelegates;

public class MathOperations
{
    public event EventHandler<OperationPerformedEventArgs>? OnOperationPerformed;

    public double Add(double a, double b)
    {
        double result = a + b;
        Notify("Додавання", a, b, result);
        return result;
    }

    public double Multiply(double a, double b)
    {
        double result = a * b;
        Notify("Множення", a, b, result);
        return result;
    }

    public double PerformCustom(string operationName, OperationDelegate operation, double a, double b)
    {
        double result = operation(a, b);
        Notify(operationName, a, b, result);
        return result;
    }

    private void Notify(string operationName, double a, double b, double result)
    {
        var eventArgs = new OperationPerformedEventArgs(operationName, a, b, result);
        OnOperationPerformed?.Invoke(this, eventArgs);
    }
}
