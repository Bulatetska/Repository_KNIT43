using System;
class Program
{
  static void Main(){
  Console.Write("Size[n,m]: ");
 int n = Int32.Parse(Console.ReadLine());
 int m = Int32.Parse(Console.ReadLine());
 double[,] array = new double[n, m];
  for(int i = 0;i<n;i++){
  	for(int j = 0;j<m;j++){
  		array[i,j] = Int32.Parse(Console.ReadLine());
  	}
  }
  double sum = 0;
  for(int i = 0;i<n;i++){
  	for(int j = 0;j<m;j++){
  		sum += array[i,j];
  	}
  }
   for(int i = 0;i<n;i++){
  	for(int j = 0;j<m;j++){
  	    if(array[i,j] < (double)(sum/(n*m))){
  		array[i,j] = -1;
  		}
  		else if(array[i,j] > (double)(sum/(n*m))){
  			array[i,j] = 1;
  		}
  	}
  }
  for(int i = 0;i<n;i++){
  	for(int j = 0;j<m;j++){
  		Console.Write(array[i,j] + " ");
  	}
  	Console.Write("\n");
  }
  
  	Console.Write(sum + " i ");
  }
}  
