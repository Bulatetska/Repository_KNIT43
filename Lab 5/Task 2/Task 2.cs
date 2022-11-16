using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

{
	string word;
	double x, y;
	StreamWriter f = new StreamWriter("Lab5_Writer.txt");
	StreamReader f1 = new StreamReader("Lab5_Reader.txt");
	f.WriteLine("Отримано:\n");
mitkaStart: word = f1.ReadLine();
	if (word == null) {goto mitkaEnd;}
	x = Convert.ToDouble(word);
	y = Math.Sqrt(Math.PI) * x * Math.Atan(x);
	f.WriteLine($"Для заданої функцiї Y({x,2:0.###}) = {y:0.#}");
	goto mitkaStart;
mitkaEnd: f.WriteLine("Склав: Юхимук С.В.");
	f.Close();
	f1.Close();
}