using DataAccess;
using DataAccess.Models;

var carManager = new CarManager();

ConsoleKey key = ConsoleKey.Enter;

while (key != ConsoleKey.Escape)
{
    Console.WriteLine("Enter make and model seperated by a space:");
    var makeModel = Console.ReadLine().Split(' ');
    var horsePower = 0;
    bool notInt = false;
    while (!notInt)
    {

        Console.WriteLine("Enter horsepower:");
        if (int.TryParse(Console.ReadLine(), out horsePower))
        {
            notInt = true;
        }
        else
        {
            Console.WriteLine("Input is not a number!");
        }
        
    }

    Console.WriteLine("Enter color:");
    var color = (Console.ReadLine());
    Console.WriteLine("Press escape to stop entering cars.");
    key = Console.ReadKey().Key;
    var newCar = new Car() { HorsePower = horsePower, Make = makeModel[0], Model = makeModel[1], Color = color };

    carManager.Add(newCar);
}

var all = carManager.GetAll();
Console.WriteLine("==========================================");

foreach (var car in all)
{
    Console.WriteLine();
    Console.WriteLine($"Id: {car.Id}");
    Console.WriteLine($"Make: {car.Make}");
    Console.WriteLine($"Model: {car.Model}");
    Console.WriteLine($"Color: {car.Color}");
    Console.WriteLine($"Horsepower: {car.HorsePower}");
    Console.WriteLine();
}
