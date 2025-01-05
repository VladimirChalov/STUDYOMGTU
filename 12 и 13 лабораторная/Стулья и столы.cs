using System;
using System.Collections.Generic;

class Furniture
{
    public string Name { get; set; }
    public string ManufacturerCity { get; set; }
    public decimal Price { get; set; }

    public Furniture(string name, string manufacturerCity, decimal price)
    {
        Name = name;
        ManufacturerCity = manufacturerCity;
        Price = price;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Наименование: {Name}, Город производитель: {ManufacturerCity}, Стоимость: {Price}");
    }
}

class Chair : Furniture
{
    public bool IsSoft { get; set; }
    public int LegCount { get; set; }

    public Chair(string name, string manufacturerCity, decimal price, bool isSoft, int legCount)
        : base(name, manufacturerCity, price)
    {
        IsSoft = isSoft;
        LegCount = legCount;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Мягкий: {IsSoft}, Кол-во ножек: {LegCount}");
    }
}

class Table : Furniture
{
    public int LegCount { get; set; }
    public string TableTopType { get; set; }

    public Table(string name, string manufacturerCity, decimal price, int legCount, string tableTopType)
        : base(name, manufacturerCity, price)
    {
        LegCount = legCount;
        TableTopType = tableTopType;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Кол-во ножек: {LegCount}, Тип столешницы: {TableTopType}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Furniture> furnitureList = new List<Furniture>();
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Заполнение (мебель, стулья)");
            Console.WriteLine("2. Выборка по городу производителю");
            Console.WriteLine("3. Выборка по количеству ножек столов");
            Console.WriteLine("4. Выборка по количеству ножек стульев");
            Console.WriteLine("5. Выход");
            Console.Write("Выберите пункт меню: ");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.WriteLine("Добавление новой мебели:");
                    Console.Write("Введите тип мебели (Стул/Стол): ");
                    string furnitureType = Console.ReadLine().ToLower();

                    Console.Write("Наименование: ");
                    string name = Console.ReadLine();
                    Console.Write("Город производитель: ");
                    string city = Console.ReadLine();
                    Console.Write("Стоимость: ");
                    decimal price;
                    while (!decimal.TryParse(Console.ReadLine(), out price) || price < 0)
                    {
                        Console.Write("Введите корректную стоимость: ");
                    }

                    if (furnitureType == "стул")
                    {
                        Console.Write("Мягкий (да/нет): ");
                        bool isSoft = Console.ReadLine().ToLower() == "да";
                        Console.Write("Количество ножек: ");
                        int legCount;
                        while (!int.TryParse(Console.ReadLine(), out legCount) || legCount <= 0)
                        {
                            Console.Write("Введите корректное количество ножек: ");
                        }

                        Chair chair = new Chair(name, city, price, isSoft, legCount);
                        furnitureList.Add(chair);
                    }
                    else if (furnitureType == "стол")
                    {
                        Console.Write("Количество ножек: ");
                        int legCount;
                        while (!int.TryParse(Console.ReadLine(), out legCount) || legCount <= 0)
                        {
                            Console.Write("Введите корректное количество ножек: ");
                        }

                        Console.Write("Тип столешницы: ");
                        string tableTopType = Console.ReadLine();
                        Table table = new Table(name, city, price, legCount, tableTopType);
                        furnitureList.Add(table);
                    }
                    else
                    {
                        Console.WriteLine("Неверный тип мебели.");
                    }

                    Console.WriteLine("Данные успешно добавлены.");
                    break;

                case "2":
                    Console.Write("Введите город производителя: ");
                    string searchCity = Console.ReadLine();
                    bool foundCity = false;

                    foreach (var furniture in furnitureList)
                    {
                        if (furniture.ManufacturerCity.Equals(searchCity, StringComparison.OrdinalIgnoreCase))
                        {
                            furniture.DisplayInfo();
                            foundCity = true;
                        }
                    }

                    if (!foundCity)
                    {
                        Console.WriteLine("Мебель не найдена для указанного города.");
                    }
                    break;

                case "3":
                    Console.Write("Введите количество ножек столов: ");
                    int searchLegCountTable;
                    while (!int.TryParse(Console.ReadLine(), out searchLegCountTable) || searchLegCountTable <= 0)
                    {
                        Console.Write("Введите корректное количество ножек: ");
                    }

                    bool foundTable = false;
                    foreach (var furniture in furnitureList)
                    {
                        if (furniture is Table table && table.LegCount == searchLegCountTable)
                        {
                            table.DisplayInfo();
                            foundTable = true;
                        }
                    }

                    if (!foundTable)
                    {
                        Console.WriteLine("Столы с указанным количеством ножек не найдены.");
                    }
                    break;

                case "4":
                    Console.Write("Введите количество ножек стульев: ");
                    int searchLegCountChair;
                    while (!int.TryParse(Console.ReadLine(), out searchLegCountChair) || searchLegCountChair <= 0)
                    {
                        Console.Write("Введите корректное количество ножек: ");
                    }

                    bool foundChair = false;
                    foreach (var furniture in furnitureList)
                    {
                        if (furniture is Chair chair && chair.LegCount == searchLegCountChair)
                        {
                            chair.DisplayInfo();
                            foundChair = true;
                        }
                    }

                    if (!foundChair)
                    {
                        Console.WriteLine("Стулья с указанным количеством ножек не найдены.");
                    }
                    break;

                case "5":
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