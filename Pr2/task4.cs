using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Запитуємо останню цифру порядкового номера у списку групи
        Console.Write("Введіть останню цифру порядкового номеру у списку групи: ");
        int lastDigit = int.Parse(Console.ReadLine());

        // Визначаємо довжину масиву
        int arrayLength = 10 + lastDigit;

        // Ініціалізація масиву X
        int[] X = new int[arrayLength];

        // Заповнення масиву X випадковими числами (як позитивними, так і негативними)
        Random random = new Random();
        for (int i = 0; i < arrayLength; i++)
        {
            X[i] = random.Next(-100, 101); // Заповнюємо числами від -100 до 100
        }

        // Введення числа M
        Console.Write("Введіть число M: ");
        int M = int.Parse(Console.ReadLine());

        // Формування масиву Y: елементи з X, модуль яких більше M
        int[] Y = X.Where(x => Math.Abs(x) > M).ToArray();

        // Виведення результатів
        Console.WriteLine($"\nЧисло M: {M}");
        Console.WriteLine("Масив X:");
        Console.WriteLine(string.Join(", ", X));

        Console.WriteLine("Масив Y (елементи з X, які за модулем більше M):");
        Console.WriteLine(Y.Length > 0 ? string.Join(", ", Y) : "Відповідних елементів немає.");
    }
}
