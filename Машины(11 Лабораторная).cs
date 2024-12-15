using System;

namespace Omgtu
{
    class Car
    {
        public string Brand { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string Country { get; set; }

        public Car(string brand, int year, string color, string country)
        {
            Brand = brand;
            Year = year;
            Color = color;
            Country = country;
        }

        public override string ToString()
        {
            return $"Марка: {Brand}, Год: {Year}, Чвет: {Color}, Страна: {Country}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество машин:");
            int count = Convert.ToInt32(Console.ReadLine());

            Car[] cars = new Car[count]; 
            int index = 0;

            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Создать машину");
                Console.WriteLine("2. Сортировка по году выпуска");
                Console.WriteLine("3. Сортировка по стране-изготовителе");
                Console.WriteLine("4. Выход");

                int n = Convert.ToInt32(Console.ReadLine());

                switch (n)
                {
                    case 1:
                        if (index < count)
                        {
                            Console.WriteLine("Введите марку машины:");
                            string brand = Console.ReadLine();

                            Console.WriteLine("Введите год машины:");
                            int year = Convert.ToInt32(Console.ReadLine()); 

                            Console.WriteLine("Введите цвет:");
                            string color = Console.ReadLine();

                            Console.WriteLine("Введит страну-производитель:");
                            string country = Console.ReadLine();

                            cars[index] = new Car(brand, year, color, country);
                            index++;
                            
                        }
                    
                        break;

                    case 2:
                        if (index > 0)
                        {
                            Console.WriteLine("Введите год для выборки:");
                            int yearToFilter = Convert.ToInt32(Console.ReadLine());

                            bool result = false;
                            for (int i = 0; i < index; i++)
                            {
                                if (cars[i].Year == yearToFilter)
                                {
                                    Console.WriteLine(cars[i]);
                                    result = true;
                                }
                            }
                            if (!result)
                            {
                                Console.WriteLine("Данные не найдены");
                            }
                        }
                        break;


                    case 3:
                        if (index > 0)
                        {
                                    Console.WriteLine("Введите страну для выборки:");
                                    string countryToFilter = Console.ReadLine();

                                    bool found = false;
                                    for (int i = 0; i < index; i++)
                                    {
                                        if (cars[i].Country==countryToFilter)
                                        {
                                            Console.WriteLine(cars[i]);
                                            found = true;
                                        }
                                    }
                                    if (!found)
                                    {
                                        Console.WriteLine("Не найдено");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Дата не найдена");
                                }
                                break;

                            case 4:
                                Console.WriteLine("Выход из программы");
                                return;


                            }
                        }
                }
            }
        }