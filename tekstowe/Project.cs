using System;
using System.IO;

class Program
{
    static void ReadFiles() // metoda do odczytu plików
    {
        // Wczytuje całą zawartość pliku jako jeden długi ciąg znaków (string)
        var document1 = File.ReadAllText(@"D:\GIT\Projekty\tekstowe\CSharpCourse\document1.txt"); 
        // Wczytuje plik i dzieli go na tablicę stringów, gdzie każdy element to jedna linia
        var document2 = File.ReadAllLines(@"D:\GIT\Projekty\tekstowe\CSharpCourse\document1.txt");
        // Łączy elementy tablicy w jeden string, rozdzielając je znakiem nowej linii (np. \n)
        var document25String = string.Join(Environment.NewLine, document2); // Zwraca cały tekst

        // Wypisuje zawartość document1 (czysty tekst)
        Console.WriteLine("document1");
        Console.WriteLine(document1);
        // To wypisze "System.String[]", ponieważ document2 to tablica nie tekst
        Console.WriteLine("document2");
        Console.WriteLine(document2);
        // Wypisuje tekst stworzony z tablicy (document25String), który wygląda już poprawnie
        Console.WriteLine("document2");
        Console.WriteLine(document25String);
    }
    static void GenerateDoc() // Metoda odpowiedzialna za generowanie nowego dokumentu na podstawie szablonu
    {
        // Prośba o wpisanie imienia
        Console.WriteLine("insert name");
        var name = Console.ReadLine();
        // Prośba o wpisanie numeru zamówienia
        Console.WriteLine("insert orderNumber");
        var orderNumber = Console.ReadLine();

        // Wczytuje szablon dokumentu z pliku tekstowego
        var template = File.ReadAllText(@"D:\GIT\Projekty\FirstProject\document2.txt");
        //Tworzy nową treść dokumentu
        var document = template.Replace("{name}", name)
            .Replace("{orderNumber}", orderNumber)
            .Replace("{dateTime}", DateTime.Now.ToString());

        // Tworzy nowy plik tekstowy
        File.WriteAllText($"D:/GIT/Projekty/FirstProject/document-{name}.txt", document); //zapisanie pliku
    }
    static void Main(string[] args)
    {
        ReadFiles();
        GenerateDoc();
    }
}
