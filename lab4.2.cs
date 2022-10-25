using System;
class Program
{
  static void Main(){
  Console.Write("Size: ");
 int s = Int32.Parse(Console.ReadLine());
 int[,] array = new int[s, s];
  for(int i = 0;i<s;i++){
  	for(int j = 0;j<s;j++){
  		array[i,j] = Int32.Parse(Console.ReadLine());
  	}
  }	
  
  
  int maxEl = array[0,0];
  for(int i = 0;i<s;i++){
  	for(int j = 0;j<s;j++){
  		Console.Write(array[i,j] + " ");
  	if (maxEl < array[i,j])
        {
         maxEl = array[i,j];
        }
  	}
  	Console.Write("\n");
  }
  Console.Write("\n");
  for(int i = 0;i<s;i++){
  	for(int j = 0;j<s;j++){
  	if (array[i,j] == maxEl)
        {
        	array[i,j] = 0;
        }
        Console.Write(array[i,j] + " ");
  	}
  	Console.Write("\n");
  }
}
}
