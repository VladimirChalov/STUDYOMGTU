using System;

namespace Omgtu
{
    class Shape
    {
        public string Name { get; set; }

        public Shape(string name)
        {
            Name = name;
        }
    }

    interface Shape1
    {
        double Area();
        double Perimeter();
    }

    class Circle : Shape, Shape1
    {
        public double Radius { get; set; }

        public Circle(double radius) : base("Окружность")
        {
            Radius = radius;
        }

        public double Area()
        {
            return Math.PI * Radius * Radius;
        }

        public double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }

    class Square : Shape, Shape1
    {
        public double Side { get; set; }

        public Square(double side) : base("Квадрат")
        {
            Side = side;
        }

        public double Area()
        {
            return Side * Side;
        }

        public double Perimeter()
        {
            return 4 * Side;
        }
    }

    class Triangle : Shape, Shape1
    {
        public double Side { get; set; }

        public Triangle(double side) : base("Равносторонний треугольник")
        {
            Side = side;
        }

        public double Area()
        {
            return (Math.Sqrt(3) / 4) * Side * Side;
        }

        public double Perimeter()
        {
            return 3 * Side;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите радиус окружности: ");
            double radius = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите сторону квадрата: ");
            double squareSide = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите сторону равностороннего треугольника: ");
            double triangleSide = Convert.ToDouble(Console.ReadLine());

            Circle circle = new Circle(radius);
            Square square = new Square(squareSide);
            Triangle triangle = new Triangle(triangleSide);

            Console.WriteLine("Окружность");
            Console.WriteLine($"Площадь: {circle.Area()}");
            Console.WriteLine($"Периметр: {circle.Perimeter()}");

            Console.WriteLine("Квадрат");
            Console.WriteLine($"Площадь: {square.Area()}");
            Console.WriteLine($"Периметр: {square.Perimeter()}");

            Console.WriteLine("Равносторонний треугольник");
            Console.WriteLine($"Площадь: {triangle.Area()}");
            Console.WriteLine($"Периметр: {triangle.Perimeter()}");
        }
    }
}

