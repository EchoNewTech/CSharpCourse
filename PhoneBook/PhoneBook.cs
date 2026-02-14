using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PhoneContactsApp
{
    // 1. Model kontaktu
    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }

    // 2. Zarządca kontaktów (Logika)
    public class ContactManager
    {
        private List<Contact> _contacts = new List<Contact>();

        public void AddContact(string name, string number)
        {
            // 1. Tworzymy nowy obiekt typu Contact (naszą "kopertę" na dane)
            Contact newContact = new Contact();

            // 2. Przypisujemy dane z parametrów metody do właściwości obiektu
            newContact.Name = name;
            newContact.PhoneNumber = number;

            // 3. Dodajemy gotowy obiekt do naszej prywatnej listy
            _contacts.Add(newContact);

            Console.WriteLine("Kontakt został dodany pomyślnie!");
        }

        public void DisplayByNumber(string number)
        {
            // TODO: Znajdź kontakt o tym numerze i wyświetl go
            // 1. Zakładamy na początku, że nie znaleźliśmy kontaktu
            bool found = false;

            // 2. Przeszukujemy listę kontakt po kontakcie
            foreach (Contact contact in _contacts)
            {
                if (contact.PhoneNumber == number)
                {
                    Console.WriteLine($"Znaleziono kontakt: {contact.Name}, Numer: {contact.PhoneNumber}");
                    found = true;
                    break; // Przerywamy pętlę, bo znaleźliśmy to, czego szukaliśmy
                }
            }

            // 4. Jeśli po sprawdzeniu całej listy nic nie znaleźliśmy
            if (!found)
            {
                Console.WriteLine($"Nie znaleziono kontaktu o numerze: {number}");
            }

        }

        public void DisplayAll()
        {
            // TODO: Przejdź pętlą przez listę i wypisz wszystko
            // 1. Sprawdzamy czy mamy jakieś kontakty
            if (_contacts.Count == 0)
            {
                Console.WriteLine("Brak kontaktów");
            }
            else
            {
                Console.WriteLine("Lista kontaktów");
                foreach (Contact contact in _contacts)
                {
                    Console.WriteLine("Kontakt" + contact.Name + ", Numer: " + contact.PhoneNumber);
                }
            }
        }

        public void SearchByName(string name)
        {
            // TODO: Znajdź wszystkie kontakty zawierające daną frazę
            // 1. Zakładamy na początku, że nie znaleźliśmy kontaktu
            bool found = false;

            // 2. Przeszukujemy listę kontakt po kontakcie
            foreach (Contact contact in _contacts)
            {
                if (contact.Name == name)
                {
                    Console.WriteLine($"Znaleziono kontakt: {contact.Name}, Numer: {contact.PhoneNumber}");
                    found = true;
                    break; // Przerywamy pętlę, bo znaleźliśmy to, czego szukaliśmy
                }
            }

            // 4. Jeśli po sprawdzeniu całej listy nic nie znaleźliśmy
            if (!found)
            {
                Console.WriteLine($"Nie znaleziono kontaktu o numerze: {name}");
            }
        }
    }

    // 3. Interfejs użytkownika (Menu)
    class Program
    {
        static void Main(string[] args)
        {
            ContactManager manager = new ContactManager();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- MOJE KONTAKTY ---");
                Console.WriteLine("1. Dodaj kontakt");
                Console.WriteLine("2. Wyświetl po numerze");
                Console.WriteLine("3. Wyświetl wszystko");
                Console.WriteLine("4. Szukaj po nazwie");
                Console.WriteLine("5. Wyjście");
                Console.Write("Wybierz opcję: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Podaj nazwę kontaktu: ");
                        string name = Console.ReadLine();

                        Console.Write("Podaj numer telefonu: ");
                        string number = Console.ReadLine();

                        // Przy wywołaniu NIE piszemy 'string', tylko podajemy same nazwy zmiennych
                        manager.AddContact(name, number);
                        break;
                    case "2":
                        // Wywołaj manager.DisplayByNumber(...)
                        Console.Write("Podaj numer telefonu: ");
                        string PhoneNumber = Console.ReadLine();

                        manager.DisplayByNumber(PhoneNumber);
                        break;
                    case "3":
                        // Wywołaj manager.DisplayAll()
                        Console.WriteLine("Zawartość listy:");
                        manager.DisplayAll();
                        break;
                    case "4":
                        // Wywołaj manager.SearchByName(...)
                        Console.Write("Podaj nazwę kontaktu: ");
                        string Name = Console.ReadLine();
                        manager.SearchByName(Name);
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór.");
                        break;
                }
            }
        }
    }
}