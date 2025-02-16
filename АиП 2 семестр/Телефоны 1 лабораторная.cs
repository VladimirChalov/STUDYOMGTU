using System;

namespace Omgtu
{
    class Phone
    {
        public string Surname { get; set; }
        public int[] Numbers { get; set; }
        public string[] Operators { get; set; }
        public int Year { get; set; }

        

        public Phone(string surname, int[] numbers, string[] operators, int year)
        {
            Surname = surname;
            Numbers = numbers;
            Operators = operators;
            Year = year;
        }

        public override string ToString()
        {
            string numbers = string.Join(", ", Numbers);
            string operators = string.Join(", ", Operators);
            return $"Фамилия: {Surname}, Номера телефонов: {numbers}, Операторы: {operators}, Год подключения: {Year}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество пользователей:");
            int count = Convert.ToInt32(Console.ReadLine());

            Phone[] phones = new Phone[count];
            int index = 0;
            Console.WriteLine("Введите количество номеров телефона для пользователей:");
            int MaxNumbers = Convert.ToInt32(Console.ReadLine()); 

            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Внести пользователя");
                Console.WriteLine("2. Сортировка по фамилии пользователя");
                Console.WriteLine("3. Сортировка по номеру телефона");
                Console.WriteLine("4. Сортировка по сотовому оператору");
                Console.WriteLine("5. Сортировка по году подключения");
                Console.WriteLine("6. Выход");

                int n = Convert.ToInt32(Console.ReadLine());

                switch (n)
                {
                    case 1:
                        if (index < count)
                        {
                            Console.WriteLine("Введите фамилию:");
                            string surname = Console.ReadLine();
                            Console.WriteLine("Введите год подключения:");
                            int year = Convert.ToInt32(Console.ReadLine());
                            int[] numbers = new int[MaxNumbers];
                            string[] operators = new string[MaxNumbers];



                            for (int i = 0; i < MaxNumbers; i++)
                            {
                                Console.WriteLine($"Введите номер телефона {i + 1}:");
                                string input = Console.ReadLine();

                                numbers[i] = Convert.ToInt32(input);

                                Console.WriteLine("Введите оператор сотовой связи:");
                                operators[i] = Console.ReadLine();
                            }


                            phones[index] = new Phone(surname, numbers, operators, year);
                            index++;
                        }
                        break;

                    case 2:
                        if (index > 0)
                        {
                            Console.WriteLine("Введите фамилию для выборки:");
                            string surnameToFilter = Console.ReadLine();

                            for (int i = 0; i < index; i++)
                            {
                                if (phones[i].Surname==surnameToFilter)
                                {
                                    Console.WriteLine(phones[i]);
                                }
                            }
                        }
                        break;

                    case 3:
                        if (index > 0)
                        {
                            Console.WriteLine("Введите номер для выборки:");
                            int numberToFilter = Convert.ToInt32(Console.ReadLine());

                            for (int i = 0; i < index; i++)
                            {
                                for (int j = 0; j < MaxNumbers; j++)
                                {
                                    if (phones[i].Numbers[j] == numberToFilter)
                                    {
                                        Console.WriteLine(phones[i]);
                                    }
                                }
                            }
                        }
                        break;

                    case 4:
                        if (index > 0)
                        {
                            Console.WriteLine("Введите оператор для выборки:");
                            string operToFilter = Console.ReadLine();

                            for (int i = 0; i < index; i++)
                            {
                                for (int j = 0; j < MaxNumbers; j++)
                                {
                                    if (phones[i].Operators[j]==operToFilter )
                                    {
                                        Console.WriteLine(phones[i]);
                                    }
                                }
                            }

                        }
                        break;

                    case 5:
                        if (index > 0)
                        {
                            Console.WriteLine("Введите год для выборки:");
                            int yearToFilter = Convert.ToInt32(Console.ReadLine());

                            for (int i = 0; i < index; i++)
                            {
                                if (phones[i].Year == yearToFilter)
                                {
                                    Console.WriteLine(phones[i]);
                                }
                            }
                        }
                        break;

                    case 6:
                        Console.WriteLine("Выход из программы");
                        return;


                }
            }
        }
    }
}

