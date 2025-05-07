using System;
using System.Collections.Generic;

public class Mobile
{
    public string Number { get; set; }
    public string Provider { get; set; }

    public Mobile(string number, string provider)
    {
        Number = number;
        Provider = provider;
    }
}

class Program
{
    public static void Main()
    {
        List<Mobile> dev = new List<Mobile>
        {
            new Mobile("987-654-3210", "Beeline"),
            new Mobile("876-543-2109", "MTS"),
            new Mobile("765-432-1098", "Yota"),
            new Mobile("654-321-0987", "Beeline"),
            new Mobile("543-210-9876", "Yota"),
            new Mobile("432-109-8765", "MTS")
        };

        Dictionary<string, int> Counts = new Dictionary<string, int>();

        foreach (var device in dev)
        {
            if (Counts.ContainsKey(device.Provider))
                Counts[device.Provider]++;
            else
                Counts[device.Provider] = 1;
        }

        foreach (var k in Counts)
        {
            Console.WriteLine($"Оператор: {k.Key}, Количесвто устройств: {k.Value}");
        }
    }
}

