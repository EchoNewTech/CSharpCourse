using System;
using System.Collections.Generic;

// Klasa Book
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public bool IsBorrowed { get; set; }

    // Konstruktor
    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
        IsBorrowed = false; // domyślnie książka nie jest wypożyczona
    }

    // Wyświetla informacje o książce
    public void BookInfo()
    {
        Console.WriteLine($"{Title} - {Author} ({Year}) - {(IsBorrowed ? "Wypożyczona" : "Dostępna")}");
    }

    // Zmienia stan wypożyczenia
    public void BorrowInfo()
    {
        IsBorrowed = !IsBorrowed;
    }
}

// Klasa Library
public class Library
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine($"Dodano książkę: {book.Title}");
    }

    public void ShowAllBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Brak książek w bibliotece.");
            return;
        }

        foreach (var book in books)
        {
            book.BookInfo();
        }
    }

    public void BorrowBook(string title)
    {
        var book = books.Find(b => b.Title == title);
        if (book != null)
        {
            if (!book.IsBorrowed)
            {
                book.BorrowInfo();
                Console.WriteLine($"Wypożyczono: {title}");
            }
            else
            {
                Console.WriteLine($"Książka {title} jest już wypożyczona.");
            }
        }
        else
        {
            Console.WriteLine($"Nie znaleziono książki: {title}");
        }
    }

    public void ReturnBook(string title)
    {
        var book = books.Find(b => b.Title == title);
        if (book != null && book.IsBorrowed)
        {
            book.BorrowInfo();
            Console.WriteLine($"Zwrócono: {title}");
        }
        else
        {
            Console.WriteLine($"Nie znaleziono wypożyczonej książki: {title}");
        }
    }

    public void RemoveBook(string title)
    {
        var book = books.Find(b => b.Title == title);
        if (book != null)
        {
            books.Remove(book);
            Console.WriteLine($"Usunięto książkę: {title}");
        }
        else
        {
            Console.WriteLine($"Nie znaleziono książki: {title}");
        }
    }
    static void Main(string[] args)
    {
        Library library = new Library();

        while (true)
        {
            Console.WriteLine("\n===== Biblioteka =====");
            Console.WriteLine("1 - Dodaj książkę");
            Console.WriteLine("2 - Wyświetl wszystkie książki");
            Console.WriteLine("3 - Wypożycz książkę");
            Console.WriteLine("4 - Zwróć książkę");
            Console.WriteLine("5 - Usuń książkę");
            Console.WriteLine("0 - Wyjście");
            Console.Write("Wybierz opcję: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Tytuł: ");
                    string title = Console.ReadLine();
                    Console.Write("Autor: ");
                    string author = Console.ReadLine();
                    Console.Write("Rok wydania: ");
                    int year = int.Parse(Console.ReadLine());
                    Book book = new Book(title, author, year);
                    library.AddBook(book);
                    break;

                case "2":
                    library.ShowAllBooks();
                    break;

                case "3":
                    Console.Write("Tytuł książki do wypożyczenia: ");
                    string borrowTitle = Console.ReadLine();
                    library.BorrowBook(borrowTitle);
                    break;

                case "4":
                    Console.Write("Tytuł książki do zwrotu: ");
                    string returnTitle = Console.ReadLine();
                    library.ReturnBook(returnTitle);
                    break;

                case "5":
                    Console.Write("Tytuł książki do usunięcia: ");
                    string removeTitle = Console.ReadLine();
                    library.RemoveBook(removeTitle);
                    break;

                case "0":
                    return; // wyjście z programu

                default:
                    Console.WriteLine("Niepoprawna opcja.");
                    break;
            }
        }
    }
}
