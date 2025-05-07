using System;
using System.Collections.Generic;
using System.Linq;

public class Tovar
{
    public int NomerTovara { get; set; }
    public string NazvanieTovara { get; set; }
}

public class Poastavschik
{
    public int Poastavschik_Nomer { get; set; }
    public string Poastavschik_Name { get; set; }
    public string Poastavschik_Phone { get; set; }
}

public class DvizhenieTovara
{
    public int NomerTovara { get; set; }
    public int Poastavschik_Nomer { get; set; }
    public string DataPostup { get; set; }
    public int Kolvo { get; set; }
    public int Price { get; set; }
}

class Program
{
    static void Main()
    {
        var tovar = new List<Tovar>
        {
            new Tovar { NomerTovara = 1, NazvanieTovara = "Лаваш" },
            new Tovar { NomerTovara = 2, NazvanieTovara = "Шашлык" }
        };

        var postavshik = new List<Poastavschik>
        {
            new Poastavschik { Poastavschik_Nomer = 1, Poastavschik_Name = "Армен", Poastavschik_Phone = "89990461111" },
            new Poastavschik { Poastavschik_Nomer = 2, Poastavschik_Name = "Брат армена", Poastavschik_Phone = "89990465670" }
        };

        var dvizhenieTovara = new List<DvizhenieTovara>
        {
            new DvizhenieTovara { NomerTovara = 1, Poastavschik_Nomer = 1, DataPostup = "20.03.2021", Kolvo = 10, Price = 1000 },
            new DvizhenieTovara { NomerTovara = 1, Poastavschik_Nomer = 2, DataPostup = "21.03.2021", Kolvo = 50, Price = 600 },
            new DvizhenieTovara { NomerTovara = 2, Poastavschik_Nomer = 1, DataPostup = "22.03.2021", Kolvo = 20, Price = 208 }
        };

        var Sort_Po_Postavschikam =
            from dt in dvizhenieTovara
            join t in tovar on dt.NomerTovara equals t.NomerTovara
            join p in postavshik on dt.Poastavschik_Nomer equals p.Poastavschik_Nomer
            group dt by new
            {
                Pnumber = p.Poastavschik_Nomer,
                Pname = p.Poastavschik_Name,
                Tnumber = dt.NomerTovara,
                Tname = t.NazvanieTovara
            } into g
            select new
            {
                Poastavschik = g.Key.Pname,
                Tovar = g.Key.Tname,
                ObshiyPrice = g.Sum(x => x.Kolvo * x.Price)
            };

        Console.WriteLine("Товары по поставщикам:");
        foreach (var i in Sort_Po_Postavschikam)
        {
            Console.WriteLine($"Поставщик: {i.Poastavschik}, Товар: {i.Tovar}, Сумма: {i.ObshiyPrice}");
        }

        var SummaPoDate =
            from dt in dvizhenieTovara
            group dt by dt.DataPostup into g
            select new
            {
                DataPostup = g.Key,
                ObshiyPrice = g.Sum(x => x.Kolvo * x.Price)
            };

        Console.WriteLine("Суммарная стоимость товаров по дате поставки:");
        foreach (var x in SummaPoDate)
        {
            Console.WriteLine($"Дата: {x.DataPostup}, Сумма: {x.ObshiyPrice}");
        }

        var PostavschikMaxSum = from dt in dvizhenieTovara
                                join p in postavshik on dt.Poastavschik_Nomer equals p.Poastavschik_Nomer
                                group dt by new { p.Poastavschik_Nomer, p.Poastavschik_Name } into g
                                select new
                                {
                                    Postavschik = g.Key.Poastavschik_Name,
                                    ObshiyPrice = g.Sum(x => x.Kolvo * x.Price)
                                } into g
                                orderby g.ObshiyPrice descending
                                select g;

        var maxPostavschik = PostavschikMaxSum.FirstOrDefault();

        if (maxPostavschik != null)
        {
            Console.WriteLine($"Поставщик с наибольшей суммой товаров: {maxPostavschik.Postavschik}, Сумма: {maxPostavschik.ObshiyPrice}");
        }
    }
}