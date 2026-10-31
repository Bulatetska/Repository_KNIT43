using ClassesLab;
Figure first = new Rectangle("Прямокутник", 0, 0, 4, 3);
Figure second = new RectangleColor("Кольоровий прямокутник", 1, 1, 5, 4, "Синій");
first.Display();
second.Display();
// Area() не визначений у Figure, тому потрібне приведення типу.
if (first is Rectangle rect) Console.WriteLine($"Площа першого: {rect.Area()}");
if (second is RectangleColor colored) Console.WriteLine($"Площа другого: {colored.Area()}");
