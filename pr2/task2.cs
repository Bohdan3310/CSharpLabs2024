using System;

class Program
{
    static void Main()
    {
        try
        {
            // Введення трьох сторін трикутника
            Console.WriteLine("Введіть три сторони трикутника:");
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            // Перевірка, чи можуть ці сторони утворити трикутник
            if (IsTriangle(a, b, c))
            {
                // Обчислення периметра
                double perimeter = a + b + c;
                Console.WriteLine($"Периметр трикутника: {perimeter}");

                // Обчислення площі за формулою Герона
                double semiPerimeter = perimeter / 2;
                double area = Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));
                Console.WriteLine($"Площа трикутника: {area}");

                // Визначення типу трикутника
                DetermineTriangleType(a, b, c);
            }
            else
            {
                Console.WriteLine("Ці сторони не можуть утворити трикутник.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Введено некоректні дані. Будь ласка, введіть числові значення.");
        }
    }

    // Метод для перевірки дійсності трикутника
    static bool IsTriangle(double a, double b, double c)
    {
        return (a + b > c) && (a + c > b) && (b + c > a);
    }

    // Метод для визначення типу трикутника
    static void DetermineTriangleType(double a, double b, double c)
    {
        if (a == b && b == c)
        {
            Console.WriteLine("Трикутник рівносторонній.");
        }
        else if (a == b || a == c || b == c)
        {
            Console.WriteLine("Трикутник рівнобедрений.");
        }
        else
        {
            Console.WriteLine("Трикутник різносторонній.");
        }
    }
}
