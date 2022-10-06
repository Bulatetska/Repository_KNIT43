Console.Write("double A - ");
double A = Convert.ToDouble(Console.ReadLine());
Console.Write("double I - ");
double I = Convert.ToDouble(Console.ReadLine());
Console.Write("double C - ");
double C = Convert.ToDouble(Console.ReadLine());
Console.Write("boolean L - ");
bool L = Convert.ToBoolean(Console.ReadLine());
Console.Write("string N - ");
string N = Console.ReadLine();

Console.WriteLine("A = {0,4:f2}, I = {1,6}, C = {2,5:f3}, L = {3,5}, N = {4,4}", A,I,C,L,N);

double y(double x)
{
    return x*(1+Math.Cos(Math.PI*x));
}
string s;
double x;
StreamReader rd = new StreamReader("lab2.txt");
StreamWriter wr = new StreamWriter("lab2.res");
wr.WriteLine("I-----------------------------I");
wr.WriteLine("I     x       I       y       I");
wr.WriteLine("I-----------------------------I");
while ((s=rd.ReadLine())!=null)
{
    x = Convert.ToDouble(s);
    wr.WriteLine("I   {0,6}    I   {1,9:f6}   I",x,y(x));
}
wr.WriteLine("I-----------------------------I");
wr.WriteLine("Pelekh");
rd.Close();
wr.Close();