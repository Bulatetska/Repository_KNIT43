System.Console.WriteLine("Hello world!");
System.Console.ReadLine();
{
    string stringToShow1, stringToShow2;
    string surname = "Johnson";
    string name = "Joe";
    string secondname = "Yu";

    int age = 40;
    double weight = 88.73;
    stringToShow1 = surname + " " + name + " " + secondname + ", age + " + age + ", weight " + weight;
    surname = "Marcus";
    name = "Alex";
    secondname = "Fu";
    age = 23;
    weight = 66;
    stringToShow2 = surname + " " + name + " " + secondname + ", age + " + age + ", weight " + weight;
    System.Console.WriteLine(stringToShow1);
    System.Console.WriteLine(stringToShow2);
    System.Console.ReadLine();
}

{
    int a = 5;
    int b = 2;
    System.Console.WriteLine("a = " + a + ", b = "+ b);
    int result = a + b;
    System.Console.WriteLine("Додавання, a + b = " + result);
    int result2 = a * b;
    System.Console.WriteLine("Множення, a * b = " + result2);
    int result3 = a / b;
    System.Console.WriteLine("Ділення, a / b = " + result3 + " a та b - цілі числа, результат - теж");
    double resultDouble = a / b;
    System.Console.WriteLine("Ділення, a / b = " + resultDouble + " помилка...");
    double aDouble = 5;
    resultDouble = aDouble / b;
    System.Console.WriteLine("Ділення, a / b = " + resultDouble);
    System.Console.ReadLine();

}