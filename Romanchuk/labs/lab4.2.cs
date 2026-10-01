using System;
class Program {
	class Student
	{
		protected string Surname { get; set; }
		protected int Kurs { get; set; }
		protected string Id { get; set; }

		public Student(string surname, int kurs, string id)
		{
		    this.Surname = surname;
		    this.Kurs = kurs;
		    this.Id = id;
		}
		
		public void Print(){
		    Console.WriteLine($"Прізвище студента: {this.Surname}\n Курс: {this.Kurs}\n Номер залікової книжки: {this.Id}\n");
		}
	}
	
	class Aspirant: Student
	{
		public Aspirant(string surname, int kurs, string id): base(surname, kurs, id)
		{
			this.Surname = surname;
		    this.Kurs = kurs;
		    this.Id = id;				
		}
		
		public void Print(){
		    Console.WriteLine($"Прізвище аспіранта: {this.Surname}\n Курс: {this.Kurs}\n Номер залікової книжки: {this.Id}\n");
		}
	}

	static void Main() {
	    
	    var student = new Student("Romanchuk", 2, "1234");
	    var aspirant = new Aspirant("Romanchuk", 2, "1234");
	    
	    student.Print();
	    aspirant.Print();
	}
}
