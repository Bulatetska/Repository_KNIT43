using System.Text;
using CarShowroom.ConsoleApp;

Console.OutputEncoding = Encoding.UTF8;

var cars = new List<Car>
{
    new Car { Model = "Toyota Corolla", Price = 22000m, Year = 2021 },
    new Car { Model = "Volkswagen Golf", Price = 19500m, Year = 2020 },
    new Car { Model = "Skoda Octavia", Price = 23800m, Year = 2022 },
    new Car { Model = "Honda Civic", Price = 21000m, Year = 2019 }
};

Console.WriteLine("Автомобілі автосалону:");
foreach (Car car in cars)
    Console.WriteLine($"{car.Model}, {car.Year}, ціна: {car.Price:0.00}");

Car cheapest = cars.OrderBy(car => car.Price).First();
decimal averagePrice = cars.Average(car => car.Price);
Console.WriteLine($"Найдешевший: {cheapest.Model}, {cheapest.Year}, {cheapest.Price:0.00}");
Console.WriteLine($"Середня вартість: {averagePrice:0.00}");
