using System;
namespace Omgtu
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Введите количество действий:");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Способ ввода: (MIX,WATER,DUST,FIRE-на выбор) 'пробел' ingridient");
            var result = "";
            for (int i = 0; i < n; i++)
            {
                var input = Convert.ToString(Console.ReadLine());
                if (input.Substring(0, 3) == "MIX")
                {
                    //обработка ингридиента если применино заклинание MIX
                    var ingridient = input.Substring(4);
                    ingridient = ingridient.Replace(" ", "");//убираем пробелы

                    //запись результата с учетом изменения
                    result = result + ingridient;
                    result = "MX" + result + "XM";
                }
                if (input.Substring(0, 5) == "WATER")
                {
                    //обработка ингридиента если применино заклинание WATER
                    var ingridient = input.Substring(7);
                    ingridient = ingridient.Replace(" ", "");//убираем пробелы

                    //запись результата с учетом изменения
                    result = result + ingridient;
                    result = "WT" + result + "TW";
                }
                if (input.Substring(0, 4) == "DUST")
                {
                    //обработка ингридиента если применино заклинание DUST
                    var ingridient = input.Substring(5);
                    ingridient = ingridient.Replace(" ", "");//убираем пробелы

                    //запись результата с учетом изменения
                    result = result + ingridient;
                    result = "DT" + result + "TD";
                }
                if (input.Substring(0, 4) == "FIRE")
                {
                    //обработка ингридиента если применино заклинание FIRE
                    var ingridient = input.Substring(5);
                    ingridient = ingridient.Replace(" ", "");//убираем пробелы
                    result = result + ingridient;
                    result = "FR" + result + "RF";
                }

            }
            Console.WriteLine("Сформированное заклинание:" + result);
        }
    }
}