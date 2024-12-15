using System;
namespace Omgtu {
class Program
{
    public static void Main()
    {
   
            
        
        Construct i = new Construct(); 
        i.Results();

        Construct j = new Construct(1); 
        j.Results();
        
        
        Construct p = new Construct(1, 5); 
        p.Results();
    }
}

    class Construct
    {
        public double x;
        public double y;


        public Construct()
        {
            x = 0;
            y = 0;
        }


        public Construct(double xValue)
        {
            x = xValue;
            y = 0;
        }


        public Construct(double xValue, double yValue)
        {
            x = xValue;
            y = yValue;
        }

        public double Plus()
        {
             return x + y;
        }


        public double Minus()
        {
            return x - y;
        }


        public double Umn()
        {
            return x * y;
        }


        public double Del()
        {
            if (y != 0)
            {
                return x / y;
            }
            else
            {
                Console.WriteLine("Деление на ноль невозможно!");
                return double.NaN;
            }
        }
        public void Results()
        {
            Console.WriteLine($"x: {x}, y: {y}");
            Console.WriteLine($"Сложение: {Plus()}");
            Console.WriteLine($"Вычитание: {Minus()}");
            Console.WriteLine($"Умножение: {Umn()}");
            Console.WriteLine($"Деление: {Del()}\n");
        }
    }
}

