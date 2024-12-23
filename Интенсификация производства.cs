using System;
using System.Data;
namespace Omgtu
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите дату начала производства (День, Месяц, Год):");
            Console.Write("День: ");
            int day1 = int.Parse(Console.ReadLine());
            Console.Write("Месяц:");
            int month1 = int.Parse(Console.ReadLine());
            Console.Write("Год: ");
            int year1 = int.Parse(Console.ReadLine());
            DateTime dt = new DateTime(year1, month1, day1);//Формируем дату начала производтва на основе DateTime

            Console.WriteLine("Введите дату конца  производства (День, Месяц, Год):");
            Console.Write("День: ");
            int day2 = int.Parse(Console.ReadLine());
            Console.Write("Месяц:");
            int month2 = int.Parse(Console.ReadLine());
            Console.Write("Год: ");
            int year2 = int.Parse(Console.ReadLine());

            DateTime endDt = new DateTime(year2, month2, day2);//Формируем дату конца производтва на основе DateTime


            Console.WriteLine("Введите начальный выпуск продукции:");
            int initialWorkNumber = Convert.ToInt32(Console.ReadLine());

            int totalDays = (endDt - dt).Days;//Находим разницу между концом и началом производтсва (в днях)
                                              // Подсчёт результата
            int totalProduction = 0;
            for (int day = 0; day <= totalDays; day++)
            {
                totalProduction += initialWorkNumber++;
            }

            Console.WriteLine("Суммарный объём продукции:" + totalProduction);
        }


    }
}
