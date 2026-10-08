using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCalender
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime oggi = DateTime.Today;
            Menu(oggi, "CALENDARIO SCOLASTICO VACANZE");
        }


        /*
         * Chiedere quale evento maggiore si desidera calcolare e stampare il numero di giorni mancanti a tale evento.
         * Altrimenti stampare la data della vacanza più recente e eventualmente la durata della vacanza.
         */
        private static void Menu(DateTime oggi, string titolo)
        {
            string scelta = " ";
            do
            {
                Console.WriteLine($"--- {titolo} ---");
                DisegnaLinea(titolo.Length + 8);
                Console.WriteLine("a) Quanti giorni mancano a Natale?: ");
                Console.WriteLine("b) ");
                Console.WriteLine("q) Esci");
                DisegnaLinea(titolo.Length + 8);
                Console.WriteLine("Scegli un'opzione:");
                scelta = Console.ReadLine();
                switch (scelta.ToLower())
                {
                    case "a":
                        Natale(oggi);
                        AttesaTasto();
                        break;
                    case "b":
                        break;
                    case "q":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        Console.Clear();
                        Menu(oggi, titolo);
                        break;
                }   
            } while (scelta.ToLower() != "q");
        }

        private static void DisegnaLinea(int lunghezza)
        {
            Console.WriteLine("".PadLeft(lunghezza, '-'));
        }
        private static void Natale(DateTime oggi)
        {

            Console.Clear();
            DateTime natale = new DateTime(oggi.Year, 12, 23);
            if (oggi > natale)
            {
                natale = natale.AddYears(1);
            }

            int giorniMancanti = (natale - oggi).Days;

            if (giorniMancanti == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Buon Natale! Oggi è il 25 dicembre.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Mancano {giorniMancanti} giorno{(giorniMancanti == 1 ? "" : "i")} a Natale ({natale:dd/MM/yyyy}).\n");
                Console.ResetColor();
            }

            Console.WriteLine("--- ALBERO DI NATALE ---\n");
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6 - i; j++)
                {
                    Console.Write(" ");

                }
                for (int k = 0; k < 2 * i + 1; k++)
                {

                    if (k % 2 == 0)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < 6; i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j < 6 - i; j++)
                    {
                        Console.Write(" ");

                    }
                    for (int k = 0; k < 2 * i + 1; k++)
                    {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("|");
                    }
                }
            }
            Console.WriteLine();
            Console.ResetColor();
            
        }

        private static void AttesaTasto()
        {
            Console.WriteLine("\nPremi un tasto per tornare al menu...");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
