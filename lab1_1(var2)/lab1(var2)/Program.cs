using System;
using System.Collections.Generic;

public class Stack<T>
{
    private List<T> items;

    public Stack()
    {
        items = new List<T>();
    }

    public void Push(T item)
    {
        items.Add(item);
    }

    public T Pop()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        int lastIndex = items.Count - 1;
        T lastItem = items[lastIndex];
        items.RemoveAt(lastIndex);
        return lastItem;
    }

    public int Size()
    {
        return items.Count;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        TestFunctions();
        Console.WriteLine("\n------------------------------\n");
        TestStackInt();
        Console.WriteLine("\n------------------------------\n");
        TestStackString();
    }
    public static void TestFunctions()
    {
        Stack<int> stack = new Stack<int>();

        // Тестовий сценарій 1: Перевірка додавання елементів до стеку
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Console.WriteLine("Stack size: " + stack.Size()); // Очікуваний результат: 3

        // Тестовий сценарій 2: Перевірка вилучення елементів зі стеку
        int poppedItem1 = stack.Pop();
        Console.WriteLine("Popped item: " + poppedItem1); // Очікуваний результат: 3
        Console.WriteLine("Stack size: " + stack.Size()); // Очікуваний результат: 2

        int poppedItem2 = stack.Pop();
        Console.WriteLine("Popped item: " + poppedItem2); // Очікуваний результат: 2
        Console.WriteLine("Stack size: " + stack.Size()); // Очікуваний результат: 1

        // Тестовий сценарій 3: Перевірка поведінки при спробі вилучення з пустого стеку
        int poppedItem3;
        try
        {
            poppedItem3 = stack.Pop();
            Console.WriteLine("Popped item: " + poppedItem3);
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine("Error: " + e.Message); // Очікуваний результат: "Stack is empty"
        }

        Console.WriteLine("Stack size: " + stack.Size()); // Очікуваний результат: 0
    }
    public static void TestStackInt()
    {
        Console.WriteLine("Testing Stack<int>");

        Stack<int> stack = new Stack<int>();

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Console.WriteLine("Stack size: " + stack.Size()); // Очікуваний результат: 3

        int poppedItem = stack.Pop();
        Console.WriteLine("Popped item: " + poppedItem); // Очікуваний результат: 3
        Console.WriteLine("Stack size: " + stack.Size()); // Очікуваний результат: 2

        Console.WriteLine();
    }

    public static void TestStackString()
    {
        Console.WriteLine("Testing Stack<string>");

        Stack<string> stack = new Stack<string>();

        stack.Push("Hello");
        stack.Push("World");
        stack.Push("!");

        Console.WriteLine("Stack size: " + stack.Size()); // Очікуваний результат: 3

        string poppedItem = stack.Pop();
        Console.WriteLine("Popped item: " + poppedItem); // Очікуваний результат: "!"
        Console.WriteLine("Stack size: " + stack.Size()); // Очікуваний результат: 2

        Console.WriteLine();
    }
}