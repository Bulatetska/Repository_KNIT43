using System;
public class OperationEventArgs : EventArgs
{
    public double Result { get; }
    public string OperationName { get; }

    public OperationEventArgs(double result, string operationName)
    {
        Result = result;
        OperationName = operationName;
    }
}