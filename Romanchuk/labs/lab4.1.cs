using System;
class Program {
	class Person
	{
		private string name { get; set; }
		private int age { get; set; }
		private string gender { get; set; }
		private string phone { get; set; }
	
		public Person(string name, int age, string gender, string phone)
		{
		    this.name = name;
		    this.age = age;
		    this.gender = gender;
		    this.phone = phone;
		}
		public void Print(){
		    Console.WriteLine("Ім'я: " + this.name + "\n Вік: " + this.age + 
			"\n Стать: " + this.gender + "\n Номер телефону: " + this.phone + "\n");
		}
	}

	static void Main() {
			
		Person person1 = new Person("John", 25, "Male", "123-456-7890");
		person1.Print();
		
		person1.SetName("Jane");
		person1.SetAge(30);
		person1.SetGender("Female");
		person1.SetPhone("987-654-3210");
		
		person1.Print();
	}
}
