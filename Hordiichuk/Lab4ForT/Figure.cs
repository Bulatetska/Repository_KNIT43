// Lab4ForT/Figure.cs
namespace Lab4ForT
{
    public abstract class Figure
    {
        public string Name { get; private set; }

        protected Figure(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name не може бути порожнім.", nameof(name));

            Name = name;
        }

        public abstract int Area();
    }
}
