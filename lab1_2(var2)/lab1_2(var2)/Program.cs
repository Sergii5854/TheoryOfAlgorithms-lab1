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
public class MazeSolver
{
    private char[,] maze;
    private int rows;
    private int columns;
    private int startX;
    private int startY;
    private int endX;
    private int endY;
    private Stack<Position> stack;

    public MazeSolver(char[,] maze, int startX, int startY, int endX, int endY)
    {
        this.maze = maze;
        this.rows = maze.GetLength(0);
        this.columns = maze.GetLength(1);
        this.startX = startX;
        this.startY = startY;
        this.endX = endX;
        this.endY = endY;
        this.stack = new Stack<Position>();
    }

    public void SolveMaze()
    {
        stack.Push(new Position(startX, startY));

        while (stack.Size() > 0)
        {
            Position currentPosition = stack.Pop();
            int x = currentPosition.X;
            int y = currentPosition.Y;

            if (IsValidMove(x, y))
            {
                maze[x, y] = 'x';

                if (x == endX && y == endY)
                    break;

                if (IsValidMove(x - 1, y))
                    stack.Push(new Position(x - 1, y));

                if (IsValidMove(x + 1, y))
                    stack.Push(new Position(x + 1, y));

                if (IsValidMove(x, y - 1))
                    stack.Push(new Position(x, y - 1));

                if (IsValidMove(x, y + 1))
                    stack.Push(new Position(x, y + 1));
            }
        }
    }

    private bool IsValidMove(int x, int y)
    {
        return x >= 0 && x < rows && y >= 0 && y < columns && maze[x, y] != '#' && maze[x, y] != 'x';
    }

    public void PrintMaze()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (i == startX && j == startY)
                    Console.Write("S ");
                else if (i == endX && j == endY)
                    Console.Write("F ");
                else
                    Console.Write(maze[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

public class Position
{
    public int X { get; set; }
    public int Y { get; set; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        char[,] maze = {
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', '.', '.', '.', '#', '.', '.', '.', '.', '#' },
            { '#', '.', '#', '.', '#', '.', '#', '#', '.', '#' },
            { '#', '.', '#', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '.', '.', '#' },
            { '#', '#', '#', '#', '.', '#', '#', '#', '#', '#' },
            { '#', '.', '.', '#', '.', '#', '.', '.', '.', '#' },
            { '#', '#', '.', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
        };

        int startX = 1;
        int startY = 1;
        int endX = 8;
        int endY = 8;

        MazeSolver solver = new MazeSolver(maze, startX, startY, endX, endY);
        solver.SolveMaze();
        solver.PrintMaze();
    }
}
