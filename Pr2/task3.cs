using System;

class Program
{
    static void Main()
    {
        // Запитуємо останню цифру порядкового номера у списку групи
        Console.WriteLine("Введіть останню цифру порядкового номеру у списку групи:");
        int lastDigit = int.Parse(Console.ReadLine());

        // Визначаємо довжину масиву
        int arrayLength = 10 + lastDigit;

        // Ініціалізація масиву
        int[] array = new int[arrayLength];

        // Заповнення масиву випадковими числами
        Random random = new Random();
        for (int i = 0; i < arrayLength; i++)
        {
            array[i] = random.Next(1, 101); // Заповнюємо числами від 1 до 100
        }

        // Знаходження мінімального та максимального значення в масиві
        int minValue = array[0];
        int maxValue = array[0];

        foreach (int number in array)
        {
            if (number < minValue)
                minValue = number;

            if (number > maxValue)
                maxValue = number;
        }

        // Виведення масиву
        Console.WriteLine("Масив:");
        Console.WriteLine(string.Join(", ", array));

        // Виведення мінімального та максимального значення
        Console.WriteLine($"Мінімальне значення: {minValue}");
        Console.WriteLine($"Максимальне значення: {maxValue}");
    }
}
