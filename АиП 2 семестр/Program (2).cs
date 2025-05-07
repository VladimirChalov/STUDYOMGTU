using System;
using System.Collections.Generic;
using System.Linq;

namespace Omgtu
{
    public class Car
    {
        public int Year { get; set; }
        public string Make { get; set; }
        public string City { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Car> cars = new List<Car>
            {
                new Car { Year = 2018, Make = "Toyota", City = "Москва" },
                new Car { Year = 2018, Make = "Toyota", City = "Омск" },
                new Car { Year = 2018, Make = "Ford", City = "Москва" },
                new Car { Year = 2019, Make = "Toyota", City = "Лузино" },
                new Car { Year = 2018, Make = "Ford", City = "Лузино" },
                new Car { Year = 2018, Make = "BMW", City = "Москва" },
                new Car { Year = 2019, Make = "BMW", City = "Омск" }
            };

            int Sort_Year = 2018;

            var ByYear = cars.Where(c => c.Year == Sort_Year);

            var ByMake = ByYear
                .GroupBy(car => car.Make)
                .Select(makeGroup => new
                {
                    Make = makeGroup.Key,
                    ByCity = makeGroup
                        .GroupBy(car => car.City)
                        .Select(cityGroup => new
                        {
                            City = cityGroup.Key,
                            Count = cityGroup.Count(),
                            Cars = cityGroup.ToList()
                        })
                        .ToList()
                })
                .ToList();

            foreach (var makeGroup in ByMake)
            {
                Console.WriteLine($"Марка: {makeGroup.Make}");
                foreach (var cityGroup in makeGroup.ByCity)
                {
                    Console.WriteLine($"\tГород: {cityGroup.City}, Количество: {cityGroup.Count}");
                    foreach (var car in cityGroup.Cars)
                    {
                        Console.WriteLine($"\t\tГод выпуска: {car.Year}, Марка: {car.Make}, Город: {car.City}");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
