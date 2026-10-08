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
                Console.WriteLine("a) Natale");
                Console.WriteLine("b) Carnevale");
                Console.WriteLine("c) Pasqua");
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
                        Carnevale(oggi);
                        AttesaTasto();
                        break;
                    case "c":
                        Pasqua(oggi);
                        AttesaTasto();
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

        /*
        * - Vacanze pasquali: dal 25/03/2027 al 30/03/2027
        */
        private static void Pasqua(DateTime oggi)
        {
            Console.Clear();
            Console.WriteLine("--- PASQUA ---");
            DateTime pasqua = new DateTime(2027, 03, 25);
            int giorniMancanti = (pasqua - oggi).Days;
            Console.ForegroundColor = ConsoleColor.Green;
            if (oggi == pasqua)
                Console.WriteLine("Oggi è pasqua\nLe vacanze terminano il 30");
            Console.ForegroundColor= ConsoleColor.Magenta;
            Console.WriteLine($"Mancano {giorniMancanti} giorno{(giorniMancanti == 1 ? "" : "i")} a pasqua ({pasqua:dd/MM/yyyy}).\n");
            Console.ResetColor();
        }

        /*
        * - Vacanze per Carnevale: dal 6/02/2027 al 10/02/2027
        */
        private static void Carnevale(DateTime oggi)
        {
            Console.Clear();
            Console.WriteLine("--- CARNEVALE ---");
            DateTime carnevale = new DateTime(2027, 2, 6);
            int giorniMancanti = (carnevale - oggi).Days;
            Console.ForegroundColor = ConsoleColor.Green;
            if (carnevale == oggi)
                Console.WriteLine("Oggi è carnevale.\nLa vacanza termina il 10");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Mancano {giorniMancanti} giorno{(giorniMancanti == 1 ? "" : "i")} a carnevale ({carnevale:dd/MM/yyyy}).\n");
            Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.Magenta;
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
            Console.WriteLine("\nDurerà dal 23 al 6 gennaio.");
            Console.WriteLine();
            Console.ResetColor();
            
        }
        
        private static void DisegnaLinea(int lunghezza)
        {
            Console.WriteLine("".PadLeft(lunghezza, '-'));
        }

        private static void AttesaTasto()
        {
            Console.WriteLine("\nPremi un tasto per tornare al menu...");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
