using System;
    class Yuzva_Anna{
        //23
        public static void Main()
        {
            int A;  
            float C;   
            double I;  
            bool L;  
            string N_name; 
            Console.WriteLine("Введіть ім'я: "); 
            N_name = Console.ReadLine(); 
            Console.WriteLine("Введіть I");
            A = Convert.ToInt32(Console.ReadLine()); 
            Console.WriteLine("Введіть C");
            C = Convert.ToSingle(Console.ReadLine()); 
            Console.WriteLine("Введіть A");
            I = Convert.ToDouble(Console.ReadLine()); 
            Console.WriteLine("Введіть L");
            L = Convert.ToBoolean(Console.ReadLine());
            System.Console.WriteLine(" Результат: \n Імʼя = {0, 6}, L = {1, 4}", N_name,L);
            System.Console.WriteLine("I ={0, 4}, C = {1,10:f5}, A = {2,20:e8}", A,C,I);
            System.Console.WriteLine(" "); 
            System.Console.ReadLine();
        }
}