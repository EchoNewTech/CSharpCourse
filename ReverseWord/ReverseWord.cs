using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

// "this is a test" -> "test a is this"
// 1. "this is a test" -> ["this", "is", "a", "test"] SPLIT
// 2. ["this", "is", "a", "test"] -> ["tets", "a", "is", "this"] REVERSE
// 3. ["tets", "a", "is", "this"] -> "test a is this" JOIN

public class ReverseWord
{
    public static string Join(List<string> list, char separator)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < list.Count; i++)
        {
            sb.Append(list[i]);
            if (i != list.Count - 1)
            {
                sb.Append(separator);
            }
        }
        return sb.ToString();
    }
    
    public static List<string> Reverse(List<string> list)
    {
        var result = new List<string>();
        for (int i = list.Count -1; i >= 0; i--)
        {
            result.Add(list[i]);
        }
        return result;
    }

    public static List<string> Split(string input, char separator)
    {
        var result = new List<string>();
        var currentIndex = 0;
        for (int i = 0; i <input.Length; i++)
        {
            if (input[i] == separator)
            {
                var word = input.Substring(currentIndex, i - currentIndex);
                result.Add(word);
                currentIndex = i + 1;
            }
            else if (i == input.Length - 1)
            {
                var word = input.Substring(currentIndex, input.Length - currentIndex);
                result.Add(word);
            }
        }
        return result;
    }
    public static string ReverseWords(string str)
    {
        var splitWords = Split(str, ' ');
        var reversedWords = Reverse(splitWords);
        var result = Join(reversedWords, ' ');
        return result;
    }
}

public class Program
{
    public static void Main()
    {
        string wejscie = "this is a test";

        // Wywołujemy Twoją metodę
        string wynik = ReverseWord.ReverseWords(wejscie);

        // Wypisujemy wynik w konsoli
        Console.WriteLine("Oryginał: " + wejscie);
        Console.WriteLine("Wynik:    " + wynik);
    }
}