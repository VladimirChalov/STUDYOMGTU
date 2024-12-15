using System;

namespace Omgtu
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Введите количество операций:");
            int operationCount = Convert.ToInt32(Console.ReadLine());

            // Массив для хранения операций
            string[] operations = new string[operationCount];
            // Массив для хранения числовых значений
            int[] constants = new int[operationCount];
            // Массив для определения, используется ли X
            bool[] isXVariable = new bool[operationCount];

            //Сбор операций и их переменных
            for (int i = 0; i < operationCount; i++)
            {
                Console.WriteLine("Введите арифметическую операцию (+, -, *) и число (или 'x'):");
                string operation = Console.ReadLine(); //Ввод операции
                string operand = Console.ReadLine();// Ввод числа или переменной x

               // Если переменная равна 'x'(по нижнему регистру), мы отмечаем это в массиве isXVariable и сохраняем операцию.
                if (operand.ToLower() == "x") 
                {
                    isXVariable[i] = true; 
                    operations[i] = operation; 
                }
                // В противном случае, мы сохраняем значение в массиве constants, конвертируя  в целое число.
                else
                {
                    isXVariable[i] = false;
                    operations[i] = operation;
                    constants[i] = int.Parse(operand);
                }
            }
            //Инициализация переменных для вычисления
            double xCoefficient = 1; // коэффицент для X
            double constantSum = 0;   // сумма всех констант

            //Обработка операций
            //Цикл проходит по всем введенным операциям, получая текущую операцию, константу и информацию о том, используется ли x.
            for (int i = 0; i < operations.Length; i++)
            {
                string currentOperation = operations[i];
                int currentConstant = constants[i];
                bool usingX = isXVariable[i];

                if (!usingX) // Если операция с константой
                {
                    switch (currentOperation)
                    {
                        case "+":
                            constantSum += currentConstant;
                            break;
                        case "-":
                            constantSum -= currentConstant;
                            break;
                        case "*":
                            constantSum *= currentConstant;
                            xCoefficient *= currentConstant;
                            break;
                    }
                }
                else // Если операция с X
                {
                    switch (currentOperation)
                    {
                        case "+":
                            xCoefficient += 1; // добавление коэффицента для x
                            break;
                        case "-":
                            xCoefficient -= 1; // вычитание коэффицента для x
                            break;
                    }
                }
            }

            // Запрашиваем у пользователя целевое значение
            Console.WriteLine("Введите желаемое значение:");
            int targetValue = Convert.ToInt32(Console.ReadLine());

            // Проверяем возможные случаи для решения
            if (xCoefficient == 0)
            {
                if (constantSum != targetValue)
                {
                    Console.WriteLine("Нет решения: желаемое значение недостижимо.");
                }
                else
                {
                    Console.WriteLine("Значение X может быть любым, так как уравнение выполняется:"+targetValue);
                }
            }
            else
            {
                double resultX = (targetValue - constantSum) / xCoefficient;
                Console.WriteLine("Значение X равно:"+ resultX);
            }
        }
    }
}
