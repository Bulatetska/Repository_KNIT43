using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Kontrolna_robota
{
    public class Program
    {
        //Zad2
        public class Rectangle
        {
            public int x;
            public int y;
            public int width;
            public int height;
            public Rectangle(int x, int y, int width, int height)
            {
                this.x = x;
                this.y = y;
                this.width = width;
                this.height = height;
            }
            public Rectangle()
            {
                this.x = 0;
                this.y = 0;
                this.width = 1;
                this.height = 1;
            }
            public void IncreaseSides(int width = 0, int height = 0)
            {
                this.width += width;
                this.height += height;
            }
            public double Area()
            {
                return this.width * this.height;
            }
            public bool Check_Area(Rectangle r)
            {
                if(r.Area() == this.Area())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
       
        static void Main()
        {
            //Zad1
            string text = "Hello  world!   I'm Oksana!  ";
            string trimmedText = Regex.Replace(text.Trim(), @"\s+", " " );
            Console.WriteLine(trimmedText);
            //Zad2
            Rectangle r1 = new Rectangle();
            Rectangle r2 = new Rectangle(0,0,4,5);
            r1.IncreaseSides(9,1);
            bool check = r1.Check_Area(r2);
            Console.WriteLine(check);
        }
    } 
    
}