using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Запитуємо останню цифру порядкового номера у списку групи
        Console.Write("Введіть останню цифру порядкового номеру у списку групи: ");
        int lastDigit = int.Parse(Console.ReadLine());

        // Визначаємо межі інтервалу
        int lowerBound = 1;
        int upperBound = 10 + lastDigit;

        // Введення трьох цілих чисел
        Console.WriteLine("Введіть три цілі числа, розділяючи їх пробілом:");
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        // Фільтрація чисел, що належать інтервалу [1, 10 + lastDigit]
        var filteredNumbers = numbers.Where(n => n >= lowerBound && n <= upperBound);

        // Виведення результатів
        Console.WriteLine($"Числа, які належать інтервалу [{lowerBound}, {upperBound}]:");

        foreach (var number in filteredNumbers)
        {
            Console.WriteLine(number);
        }
    }
}
