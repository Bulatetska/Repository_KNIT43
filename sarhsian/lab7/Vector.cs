
namespace Lab7Operators;

public sealed class Vector : IEquatable<Vector>
{
    public double X { get; }
    public double Y { get; }

    public Vector(double x, double y)
    {
        X = x;
        Y = y;
    }

    public static Vector operator -(Vector v) => new(-v.X, -v.Y);

    public static Vector operator +(Vector a, Vector b) =>
        new(a.X + b.X, a.Y + b.Y);

    public static Vector operator *(Vector v, double k) =>
        new(v.X * k, v.Y * k);

    public static Vector operator *(double k, Vector v) => v * k;

    public static bool operator ==(Vector? a, Vector? b) =>
        ReferenceEquals(a, b) || (a is not null && a.Equals(b));

    public static bool operator !=(Vector? a, Vector? b) => !(a == b);

    public bool Equals(Vector? other) =>
        other is not null && X.Equals(other.X) && Y.Equals(other.Y);

    public override bool Equals(object? obj) =>
        obj is Vector other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(X, Y);

    public double Length() => Math.Sqrt(X * X + Y * Y);

    public override string ToString() =>
        FormattableString.Invariant($"({X:G}, {Y:G})");

    public void Print() => Console.WriteLine(this);
}
