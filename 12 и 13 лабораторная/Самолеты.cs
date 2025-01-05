using System;
namespace Omgtu
{
    class Airplane
    {
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public TimeSpan FlightDuration { get; set; }
        public string AirplaneName { get; set; }

        public Airplane(string departureCity, string arrivalCity, TimeSpan flightDuration, string airplaneName)
        {
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
            FlightDuration = flightDuration;
            AirplaneName = airplaneName;
        }

        public override string ToString()
        {
            return $"Самолёт: {AirplaneName}, Город отправления: {DepartureCity}, Город назначения: {ArrivalCity}, Время в пути: {FlightDuration}";
        }
    }

    class Airport
    {
        public string City { get; set; }
        public Airplane[] Airplanes { get; set; }

        public Airport(string city, int capacity)
        {
            City = city;
            Airplanes = new Airplane[capacity];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество самолетов:");
            int MAX_AIRPLANES = Convert.ToInt32(Console.ReadLine());
            Airport[] airports = new Airport[10]; // Массив объектов класса Airport
            int airportCount = 0;

            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Заполнение данных о городе и самолётах");
                Console.WriteLine("2. Выборка по городу назначения / типу самолёта");
                Console.WriteLine("3. Выход");
                Console.Write("Выберите пункт меню: ");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        // Заполнение данных о городе и самолётах
                        if (airportCount < airports.Length)
                        {
                            Console.Write("Введите название города: ");
                            string city = Console.ReadLine();
                            Airport airport = new Airport(city, MAX_AIRPLANES);

                            for (int i = 0; i < MAX_AIRPLANES; i++)
                            {
                                Console.WriteLine($"Введите данные о самолёте {i + 1}:");
                                Console.Write("Город отправления: ");
                                string departureCity = Console.ReadLine();
                                Console.Write("Город назначения: ");
                                string arrivalCity = Console.ReadLine();
                                Console.Write("Время в пути (часы:минуты): ");
                                string[] timeParts = Console.ReadLine().Split(':');
                                TimeSpan flightDuration = new TimeSpan(int.Parse(timeParts[0]), int.Parse(timeParts[1]), 0);
                                Console.Write("Наименование самолёта: ");
                                string airplaneName = Console.ReadLine();

                                airport.Airplanes[i] = new Airplane(departureCity, arrivalCity, flightDuration, airplaneName);
                            }
                            airports[airportCount++] = airport;
                            Console.WriteLine("Данные успешно добавлены.");
                        }
                        else
                        {
                            Console.WriteLine("Достигнуто максимальное количество городов.");
                        }
                        break;

                    case "2":// Выборка по городу назначения / типу самолёта
                        Console.Write("Введите название города назначения или тип самолёта для поиска: ");
                        string searchQuery = Console.ReadLine();
                        bool found = false;

                        foreach (var airport in airports)
                        {
                            if (airport != null)
                            {
                                foreach (var airplane in airport.Airplanes)
                                {
                                    if (airplane != null && (airplane.ArrivalCity.Contains(searchQuery) || airplane.AirplaneName.Contains(searchQuery)))
                                    {
                                        Console.WriteLine(airplane);
                                        found = true;
                                    }
                                }
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Самолёты не найдены.");
                        }
                        break;

                    case "3":
                        // Выход
                        Console.WriteLine("Выход из программы.");
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, выберите снова.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
