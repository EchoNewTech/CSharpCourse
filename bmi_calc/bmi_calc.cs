﻿using System;

namespace FirstProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Podaj mase ciała w (kg): ");
            string masaString = Console.ReadLine();
            double masa = double.Parse(masaString);
            
            Console.Write("Podaj wzrost (m): ");
            string wzrostString = Console.ReadLine();
            double wzrost = double.Parse(wzrostString);

            double bmi_calc = masa / (wzrost * wzrost);
            Console.WriteLine("Twój wynik bmi to: " + bmi_calc);


            if (bmi_calc < 18.5)
            {
                Console.WriteLine("Niedowaga");
            } else if (bmi_calc >= 18.5 && bmi_calc < 25)
            {
                Console.WriteLine("Waga normalna");
            } else if (bmi_calc >= 25 && bmi_calc < 30)
            {
                Console.WriteLine("Nadwaga");
            } else if (bmi_calc >= 30 && bmi_calc < 35)
            {
                Console.WriteLine("Otyłość");
            } else
            {
                Console.WriteLine("Otyłość olbrzymia");
            }
        }
    }
}
    
