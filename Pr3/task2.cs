using System;

public class Point
{
    private int x;
    private int y;
    private string name;

    // Властивості
    public int X
    {
        get { return x; }
    }

    public int Y
    {
        get { return y; }
    }

    public string Name
    {
        get { return name; }
    }

    // Конструктор
    public Point(int x, int y, string name)
    {
        this.x = x;
        this.y = y;
        this.name = name;
    }
}

public class Figure
{
    private Point[] points;

    // Конструктор, що приймає від 3 до 5 точок
    public Figure(params Point[] points)
    {
        if (points.Length < 3 || points.Length > 5)
        {
            throw new ArgumentException("A figure must have between 3 and 5 points.");
        }
        this.points = points;
    }

    // Метод для обчислення довжини сторони між двома точками
    public double LengthSide(Point A, Point B)
    {
        return Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
    }

    // Метод для обчислення периметра багатокутника
    public void PerimeterCalculator()
    {
        double perimeter = 0;
        for (int i = 0; i < points.Length; i++)
        {
            Point current = points[i];
            Point next = points[(i + 1) % points.Length];
            perimeter += LengthSide(current, next);
        }
        Console.WriteLine($"Perimeter of the figure: {perimeter}");
    }

    // Метод для виведення інформації про фігуру
    public void ShowFigure()
    {
        Console.WriteLine("Figure Points:");
        foreach (var point in points)
        {
            Console.WriteLine($"{point.Name}: ({point.X}, {point.Y})");
        }
    }
}

class Program
{
    static void Main()
    {
        // Створюємо точки
        Point A = new Point(0, 0, "A");
        Point B = new Point(4, 0, "B");
        Point C = new Point(4, 3, "C");
        Point D = new Point(0, 3, "D");

        // Створюємо фігуру (прямокутник) з точок
        Figure rectangle = new Figure(A, B, C, D);

        // Виводимо інформацію про точки фігури
        rectangle.ShowFigure();

        // Обчислюємо та виводимо периметр
        rectangle.PerimeterCalculator();
    }
}