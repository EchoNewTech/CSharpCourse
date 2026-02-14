using System;

namespace Coding.Exercise
{
    public class GradeCalculator
    {
        public static string CalculateGrade(double percentage)
        {
            if (percentage >= 90) return "A";
            else if (percentage >= 80) return "B";
            else if (percentage >= 70) return "C";
            else if (percentage >= 60) return "D";
            else return "F";
        }

        public static void Main(string[] args)
        {
            Console.Write("Wpisz wynik procentowy: ");
            
            // 1. Pobieramy tekst z konsoli
            string wejscie = Console.ReadLine();

            // 2. Zamieniamy tekst na liczbę double
            double percentage = double.Parse(wejscie);

            // 3. WYWOŁANIE: Przekazujemy zmienną percentage do metody CalculateGrade
            string ocena = CalculateGrade(percentage);

            // 4. Wyświetlamy wynik
            Console.WriteLine($"Dla wyniku {percentage}% ocena to: {ocena}");

            Console.ReadKey();
        }
    }
}
