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
