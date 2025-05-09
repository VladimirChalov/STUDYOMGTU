using System;
using System.Collections.Generic;

class MyList<T>
{
    private List<T> elements = new List<T>();

    public void Add(T element)
    {
        elements.Add(element);
        Console.WriteLine($"Добавлен: {element}");
    }

    public void Remove(int index)
    {
        if (index >= 0 && index < elements.Count)
        {
            Console.WriteLine($"Удалён элемент [{index}]");
            elements.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Неверный индекс");
        }
    }

    public T Get(int index)
    {
        return elements[index];
    }

    public void ShowAll()
    {
        Console.WriteLine("\nВсе элементы:");
        for (int i = 0; i < elements.Count; i++)
        {
            Console.WriteLine($"[{i}]: {elements[i]}");
        }
    }
}

class Program
{
    static void Main()
    {
        MyList<int> numbers = new MyList<int>();
        numbers.Add(100);
        numbers.Add(200);
        numbers.Add(300);
        numbers.ShowAll();

        numbers.Remove(1);
        numbers.ShowAll();

        Console.WriteLine($"Первый элемент: {numbers.Get(0)}");

        MyList<string> texts = new MyList<string>();
        texts.Add("Элемент 1");
        texts.Add("Элемент 2");
        texts.ShowAll();
    }
}











