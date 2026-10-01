using System;
class Program {
  static void Main() {
    //1
    string s1 = Console.ReadLine();
    double N1 = double.Parse(s1);
    string s2 = Console.ReadLine();
    double N2 = double.Parse(s2);
    Console.WriteLine("Avarage of " + N1 + " and " + N2 + " is " + (N1+N2)/2 + "\n");
    
    //2
    Console.WriteLine("To be or not to be \n " + @"\" + " Shakespeare " + @"\" + "\n");
    
    //3 
    int even1 = Int32.Parse(Console.ReadLine());
    if (even1 % 2 == 0) {
        Console.WriteLine(even1 + " is even\n");
    } else {
        Console.WriteLine(even1 + " is odd\n");
    };
    
    //4
    string sep1 = Console.ReadLine();
    if (Int32.Parse(sep1) >= 100){
        Console.WriteLine("Number is bigger than 100\n");
    } else {
        int sum = 0;
    
        foreach (char c in sep1)
            sum += (c - '0');
        
        Console.WriteLine("Number of digits in " + sep1 + "is " + sep1.Length + " and sum of them is " + sum + "\n");
    }
    
    //5
    string inv1 = Console.ReadLine();
    string inv2 = "";
    for (int i = inv1.Length - 1 ; i >= 0; i--)
        inv2 += inv1[i];
    Console.WriteLine("The reverse of " + inv1 + " is " + inv2 + "\n");
    
    //6
    string add1 = Console.ReadLine();
    int sum2 = 0;
    
    foreach (char c in add1)
        sum2 += (c - '0');
    
    Console.WriteLine("Sum of digits in " + add1 + " is " + sum2 + "\n");
  }
}
