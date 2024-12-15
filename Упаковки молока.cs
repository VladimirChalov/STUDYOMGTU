using System;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
namespace Omgtu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количесвто компаний:");
            int  n = Convert.ToInt32(Console.ReadLine());
            double min_milk_price = Int32.MaxValue;
            int CompanyIndex = 0;
            for (int i = 0; i < n; i++)
            {
                //Вводим значения для 2 упаковок
                string[] inputs = Console.ReadLine().Split(' ');
                double x1 = Convert.ToDouble(inputs[0]);
                double y1 = Convert.ToDouble(inputs[1]);
                double z1 = Convert.ToDouble(inputs[2]);
                double x2 = Convert.ToDouble(inputs[3]);
                double y2 = Convert.ToDouble(inputs[4]);
                double z2 = Convert.ToDouble(inputs[5]);
                double c1 = Convert.ToDouble(inputs[6]);
                double c2 = Convert.ToDouble(inputs[7]);

                double v1 = x1 * y1 * z1;//Объём 1 упоковки
                double v2 = x2 * y2 * z2;//Объём 2 упоковки

                double s1 = (x1 * y1 + y1 * z1 + x1 * z1) * 2;//Площадь 1 упаковки
                double s2 = (x2 * y2 + y2 * z2 + x2 * z2) * 2;//Площадь 2 упаковки

                double milk_price_litr = (s1 * c2 - s2 * c1) / (v2 * s1 - s2 * v1)*1000;//Определяем минимальную стоимость упаковки молока
                if (milk_price_litr < min_milk_price)
                {
                    min_milk_price= milk_price_litr;
                    CompanyIndex= i+1;
                }
            }
            Console.WriteLine($"{CompanyIndex} { Math.Round(min_milk_price, 2)}");
        } 
    }
}