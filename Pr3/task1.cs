using System;

class Program
{
    static void Main()
    {
        // Створюємо книгу і встановлюємо значення
        Book myBook = new Book("The Great Gatsby");
        myBook.Author = new Author("F. Scott Fitzgerald");
        myBook.Content = new Content("In my younger and more vulnerable years...");

        // Виводимо інформацію про книгу
        myBook.Show();
    }
}

class Book
{
    public Title BookTitle { get; }
    public Author Author { get; set; }
    public Content Content { get; set; }

    // Конструктор приймає назву книги і задає її через Title
    public Book(string title)
    {
        BookTitle = new Title(title);
        Author = new Author("Unknown");
        Content = new Content("No content");
    }

    // Метод для виведення всієї інформації про книгу
    public void Show()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        BookTitle.Show();
        
        Console.ForegroundColor = ConsoleColor.Green;
        Author.Show();
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Content.Show();
        
        Console.ResetColor();
    }
}

class Title
{
    public string Value { get; }

    public Title(string value)
    {
        Value = value;
    }

    public void Show()
    {
        Console.WriteLine($"Title: {Value}");
    }
}

class Author
{
    public string Name { get; set; }

    public Author(string name)
    {
        Name = name;
    }

    public void Show()
    {
        Console.WriteLine($"Author: {Name}");
    }
}

class Content
{
    public string Text { get; set; }

    public Content(string text)
    {
        Text = text;
    }

    public void Show()
    {
        Console.WriteLine($"Content: {Text}");
    }
}
