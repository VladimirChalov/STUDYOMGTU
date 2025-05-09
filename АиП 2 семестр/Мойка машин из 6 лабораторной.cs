using System;
using System.Collections.Generic;

class Car
{
    public int Year { get; }
    public string Make { get; }
    public string Driver { get; }
    public bool Mut_or_net { get; set; }

    public Car(int year, string make, string driver, bool mut_or_net)
    {
        Year = year;
        Make = make;
        Driver = driver;
        Mut_or_net = mut_or_net;
    }
}

class Lot
{
    public List<Car> Cars { get; } = new List<Car>();

    public void Sozdanie(Car taz)
    {
        Cars.Add(taz);
    }
}

class Moika
{
    public void Clean(Car vehicle)
    {
        if (vehicle.Mut_or_net)
        {
            vehicle.Mut_or_net = false;
            Console.WriteLine($"Постирана {vehicle.Make} {vehicle.Year} года ({vehicle.Driver})");
        }
        else
        {
            Console.WriteLine($"{vehicle.Make} уже чистая");
        }
    }
}

class Program
{
    delegate void WashDelegate(Car taz);

    static void Main()
    {
        Lot p = new Lot();

        p.Sozdanie(new Car(2012, "Самоделка", "Леша", true));
        p.Sozdanie(new Car(2019, "Жига", "Вадим", false));
        p.Sozdanie(new Car(2016, "Hyundai", "Саня", true));

        Moika washer = new Moika();

        WashDelegate washAction = washer.Clean;

        Console.WriteLine("Начало мойки");

        foreach (Car v in p.Cars)
        {
            if (v.Mut_or_net)
            {
                washAction(v);
            }
        }

        Console.WriteLine("Мойка завершена");
    }
}










