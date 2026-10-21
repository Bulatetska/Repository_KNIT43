using System;

namespace LabEightDelegates;

public sealed class OperationPerformedEventArgs : EventArgs
{
    public string OperationName { get; }
    public double A { get; }
    public double B { get; }
    public double Result { get; }

    public OperationPerformedEventArgs(string operationName, double a, double b, double result)
    {
        OperationName = operationName;
        A = a;
        B = b;
        Result = result;
    }
}
