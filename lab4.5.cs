using System;
class Program
{
  static void Main(){
  Random rand = new Random();
  int[,] array = new int[6, 9];
  int sum = 0;
  for (int i = 0; i < 6; i++) {
    for (int j = 0; j < 9; j++) {
    if(i ==5 && j==8){
    array[i,j] = 101;
    }
    else{
      array[i, j] = rand.Next(0, 100);
      }
      if(i==5){
      sum = sum + array[i,j];
      }
    }
  }
  for (int i = 0; i < 6; i++) {
    for (int j = 0; j < 9; j++) {
      Console.Write(array[i, j] + " ");
    }
    Console.Write("\n");
  }
  Console.Write("\nСума рядка з найб. елементом = " + sum);
  
  }
}  
