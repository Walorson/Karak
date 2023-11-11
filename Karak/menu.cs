using System;
using System.Collections.Generic;
using System.Text;

namespace Karak
{
    static class Menu
    {
        public static void mainMenu()
        {
            Console.WriteLine("===| Karak |=== \n");
            Console.WriteLine("1. Graj");
            Console.WriteLine("2. Wyjdź");
            var choice = Console.ReadKey().KeyChar;
            switch (choice)
            {
                case '1': championSelect(); break;
                case '2': Environment.Exit(0); break;
            }
        }
        public static void championSelect()
        {
            Console.Clear();
            Console.WriteLine("===| Wybierz Bohatera |=== \n");
            Console.WriteLine("1. Sylas");
            Console.WriteLine("2. Zilean");
            Console.WriteLine("3. Mordekaiser");
            Console.WriteLine("4. Akali");
            Console.WriteLine("5. Panteon");
            Console.WriteLine("6. Sivir");
        }
    }
}
