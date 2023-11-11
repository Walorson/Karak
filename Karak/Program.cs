using System;

namespace Karak
{
    internal class Program
    {
        static public string output = "";
        static public string output2 = "=> Witaj w Karak! Wpisz 'help', żeby dowiedzieć się o komendach.";
        static public bool walka = false;
        static public Plate[,] map = new Plate[9, 9];
        static void Main(string[] args)
        {
            Menu.mainMenu();
            var championChoice = Console.ReadKey().KeyChar;

            switch(championChoice)
            {
                case '1': game(new Sylas()); break;
            }
        }
        static void game(Champion player)
        {
            map[4, 4] = new Depo();
            output = map[player.x, player.y].outputVisited;
            bool isDragodDead = false;
            string choice;
            while (!isDragodDead && player.hp > 0)
            {
                player.show();
                if (walka) { Karak.battle(Karak.randEnemy(player), player); continue; }
                else {
                    Console.WriteLine("=> " + output);
                    if (output2 != "") Console.WriteLine("#> " + output2 + "\n");
                    else Console.WriteLine("\n");
                }

                choice = Console.ReadLine();
                switch (choice)
                {
                    case "help": output2 = Output.help(); break;
                    case "go e": player.goe(); break;
                    case "go w": player.gow(); break;
                    case "go n": player.gon(); break;
                    case "go s": player.gos(); break;
                    case "ulecz": output2 = player.heal(); break;
                    case "info bron1": output2 = player.bron1.showInfo(); break;
                    case "info bron2": output2 = player.bron2.showInfo(); break;
                    case "info czar1": output2 = player.czar1.showInfo(); break;
                    case "info czar2": output2 = player.czar2.showInfo(); break;
                    case "info czar3": output2 = player.czar3.showInfo(); break;
                    case "podnies": output2 = player.pickUp(); break;
                    case "iminvincibleman": output2 = Output.invincible(); break;
                    default: output2 = Output.unknown(); break;
                }
            }
            if(player.hp <= 0)
            {
                Console.WriteLine("Umarłeś! Nie żyjesz! To twój koniec!");
            }
        }
    }
}