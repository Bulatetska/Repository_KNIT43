using System;
class Program {
	public class Figure
    {
        public string Name { get; set; }

        public Figure(string name)
        {
            this.Name = name;
        }

        public virtual void Display()
        {
            Console.WriteLine($"\nНазва фігури: {this.Name}");
        }
    }

    class Rectangle : Figure
    {
        public int Upper_left_x { get; set; }
        public int Upper_left_y { get; set; }
        public int Lower_right_x { get; set; }
        public int Lower_right_y { get; set; }

        public Rectangle(string name, int upper_left_x, int upper_left_y, int lower_right_x, int lower_right_y) : base(name)
        {
            this.Upper_left_x = upper_left_x;
            this.Upper_left_y = upper_left_y;
            this.Lower_right_x = lower_right_x;
            this.Lower_right_y = lower_right_y;
        }

        public Rectangle() : base("Rectangle")
        {
            this.Upper_left_x = 0;
            this.Upper_left_y = 0;
            this.Lower_right_x = 1;
            this.Lower_right_y = 1;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Координати верхнього лівого кута: ({this.Upper_left_x}, {this.Upper_left_y})");
            Console.WriteLine($"Координати нижнього правого кута: ({this.Lower_right_x}, {this.Lower_right_y})");
        }

        public int Area()
        {
            return (this.Lower_right_x - this.Upper_left_x) * (this.Lower_right_y - this.Upper_left_y);
        }
    }
    
    class RectangleColor : Rectangle
    {
        public string Color { get; set; }

        public RectangleColor(string name, int upper_left_x, int upper_left_y, int lower_right_x, int lower_right_y, string color) : base(name, upper_left_x, upper_left_y, lower_right_x, lower_right_y)
        {
            this.Color = color;
        }

        public RectangleColor() : base()
        {
            this.Color = "Red";
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Колір: {this.Color}");
        }
    }

    public static void DemoPolymorphism(Figure figure)
    {
        figure.Display();
    }

	static void Main() {

        Figure objFg = new Figure("Figure");
        Rectangle figure1 = new Rectangle("Rectangle", 0, 0, 5, 5);
        figure1.Display();
        RectangleColor figure2 = new RectangleColor("RectangleColor", 0, 0, 5, 5, "Blue");
        figure2.Display();

        Figure refFg;
        refFg = objFg;
        refFg.Display(); 

        refFg = figure1;
        refFg.Display(); 
        
        refFg = figure2;
        refFg.Display(); 
       
        refFg = figure1;
        Program.DemoPolymorphism(refFg); 
        
        refFg = figure2;
        Program.DemoPolymorphism(refFg);
        
	}
}
