
using System;
class Program {
  static void Main() {
    //1

    int[] nats = {1, 4, -6, 2, 0, 0, -1, 0, -3, 1, 4, 0};
    int n = nats.Length;
    for (int i = 1; i <= n; i++){
        nats[i-1] = i;
    };
    
    int max = nats[0];
    int score = 0;
    int maxindex = 0;
    for (int i = 1; i < n; i++)
    {
        if(nats[i] > max)
        {
            max = nats[i];
            score = 1;
            maxindex = i;
        } else if (nats[i] == max) {
            score++;
        };
    };
    Console.WriteLine("1.The max number is " + max + " and it appears " + score + " times and first appears on index " + maxindex +  "\n2.");
    
    
    //2
    int[,] matr = new int[4, 4]{{5, 1, 6, 2}, {3, 4, 5, 6}, {1, 3, 4, 2}, {6, 4, 1, 3}};

    
    for (int i = 0; i < 4; i++){ 
        for (int j = 0; j < 4; j++)
        {
            Console.Write(matr[i, j] + " ");
        };
        Console.Write("\n");
    };
    Console.Write("\n");
    
    max = matr[0, 0];
    
    for (int i = 0; i < 4; i++){
        for (int j = 0; j < 4; j++){
            if(matr[i, j] > max)
            {
                max = matr[i, j];
            } 
        };
    };
    
    for (int i = 0; i < 4; i++){
        for (int j = 0; j < 4; j++){
            if(matr[i, j] == max)
            {
                matr[i, j] = 0;
            } 
        };
    };
    
    for (int i = 0; i < 4; i++){ 
        for (int j = 0; j < 4; j++){
            Console.Write(matr[i, j] + " ");
        };
        Console.Write("\n");
    };
    Console.Write("\n3.\n");
    
    //3
    int[] nats2 = {1, 4, -6, 2, 0, 0, -1, 0, -3, 1, 4, 0};
    
    int pospairs = 0;
    int zeropairs = 0;
    
    Console.Write(nats2[0] + " ");
    for (int i = 1; i < nats2.Length; i++) {
        Console.Write(nats2[i] + " ");
        if(nats2[i] > 0 && nats2[i-1] > 0) {
            pospairs++;
        } else if(nats2[i] == 0 && nats2[i-1] == 0) {
            zeropairs++;
        };
    };
    Console.Write("3.Pairs of positive numbers: " + pospairs + "; Pairs of zeros: " + zeropairs + "\n\n4.\n");
    
    //4
    matr = new int[3, 4]{{5, 1, 6, 2}, {3, 4, 5, 6}, {1, 3, 4, 2}};
    
    int sum = 0;
    
    for (int i = 0; i < 3; i++){
        for (int j = 0; j < 4; j++){
            sum += matr[i, j];
            Console.Write(matr[i, j] + " ");
        };
        Console.Write("\n");
    };
    Console.Write("\n");
    
    int aver = sum / 12;
    
    Console.Write("Avarage is " + aver + "\n");
    
    for (int i = 0; i < 3; i++){
        for (int j = 0; j < 4; j++){
            if (aver > matr[i, j]){
                matr[i, j] = -1;
            } else {
                matr[i, j] = 1;
            }
            Console.Write(matr[i, j] + " ");
        };
        Console.Write("\n");
    };
    Console.Write("\n5.\n");
    
    //5
    matr = new int[6, 9]{{76, 10, 65, 78, 79, 22, 19, 20, 92}, 
                        {59, 19, 43, 37, 77, 99, 98, 56, 48}, 
                        {47, 59, 65, 27, 51, 72, 35, 51, 90}, 
                        {11, 67, 29, 24, 63, 60, 75, 60, 91}, 
                        {53, 26, 28, 42, 82, 43, 92, 54, 92}, 
                        {66, 42, 84, 90, 23, 88, 92, 65, 43}};
    
    max = matr[0, 0];
    int row = 0;
    
    for (int i = 0; i < 6; i++){
        for (int j = 0; j < 9; j++){
            Console.Write(matr[i, j] + " ");
            if(matr[i, j] > max)
            {
                max = matr[i, j];
                row = i;
            };
        };
        Console.Write("\n");
    };
    
    sum = 0;
    
    for (int i = 0; i < 9; i++){
        sum += matr[row, i];
    };
    
    Console.WriteLine("\nThe max number is " + max + " in row [" + row + "] and the sum is " + sum + "\n6.");
    
    //6
    int[] nats3 = {1, 4, 6, 2, 6, 7, 1, 9, 3, 1, 4, 7};
    sum = 0;
    Console.Write(nats3[0] + " ");
    for (int i = 1; i < nats3.Length; i++) {
        Console.Write(nats3[i] + " ");
        sum += nats3[i];
    };
    Console.WriteLine("\nThe sum is " + sum);
  }
}
