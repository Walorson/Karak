using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Karak
{
    internal class Champion
    {
        public string klasa;
        public byte hp;
        public Weapon bron1;
        public Weapon bron2;
        public Weapon czar1;
        public Weapon czar2;
        public Weapon czar3;
        public string klucz;
        public int x;
        public int y;
        public char lastMove;
        public void wallOutput() { Program.output2 = "Nie da się iść dalej! W tą stronę jest ściana!"; }
        protected Champion()
        {
            klasa = "Champion";
            hp = 5;
            bron1 = new Brak();
            bron2 = new Brak();
            czar1 = new Brak();
            czar2 = new Brak();
            czar3 = new Brak();
            klucz = "Klucz";
            x = 4;
            y = 4;
            lastMove = 'e';
        }
        public void goe()
        {
            if (x < 8)
            {
                x += 1; Program.output2 = "";
                Program.output = MapGenerator.generate(this);
                lastMove = 'e';
            }
            else wallOutput();
        }
        public void gow()
        {
            if (x > 0)
            {
                x -= 1; Program.output2 = "";
                Program.output = MapGenerator.generate(this);
                lastMove = 'w';
            }
            else wallOutput();
        }
        public void gon()
        {
            if (y < 8)
            {
                y += 1; Program.output2 = "";
                Program.output = MapGenerator.generate(this);
                lastMove = 'n';
            }
            else wallOutput();
        }
        public void gos()
        {
            if (y > 0)
            {
                y -= 1; Program.output2 = "";
                Program.output = MapGenerator.generate(this);
                lastMove = 's';
            }
            else wallOutput();
        }
        public string heal()
        {
            if (Program.map[x, y] == Program.map[4, 4])
            {
                hp = 5;
                return "Zostałeś w pełni uleczony!";
            }
            else return "Nie możesz się uleczyć poza depo.";
            
        }
        public void show()
        {
            Console.Clear();
            Console.WriteLine($"===| Klasa: {klasa} |===| Zdrowie: {hp} |===");
            Console.WriteLine($"===| Broń 1: {bron1.name} |===| Broń 2: {bron2.name} |===| Klucz: {klucz} |===");
            Console.WriteLine($"===| Czar 1: {czar1.name} |===| Czar 2: {czar2.name} |===| Czar 3: {czar3.name} |===");
            Console.WriteLine($"===| X: {x + 1}, Y: {y + 1} |===|\n");
        }
        public string pickUp()
        {
            var item = Program.map[x, y].isItem;
            if (item != null)
            {
                if (bron1.name == "brak") bron1 = item;
                else if (bron2.name == "brak") bron2 = item;
                else
                {
                    Console.WriteLine($"\nNie masz już miejsca w Ekwipunku, żeby przechować {item.name}! Co robisz? (Zastąpienie broni spowoduje jej wyrzucenie na ziemie)");
                    Console.WriteLine($"1. Zastąp {item.name} bronią 1");
                    Console.WriteLine($"2. Zastąp {item.name} bronią 2");
                    Console.WriteLine($"3. Zostaw {item.name} na ziemii");
                    char key = Console.ReadKey().KeyChar;
                    while (true)
                    {
                        switch (key)
                        {
                            case '1': { Program.map[x, y].isItem = bron1; bron1 = item; return "Broń 1 została zastąpiona."; }
                            case '2': { Program.map[x, y].isItem = bron2; bron2 = item; return "Broń 2 została zastąpiona."; }
                            case '3': { return $"Zostawiono {item.name} na ziemii."; }
                            default: key = Console.ReadKey().KeyChar; break;
                        }
                    }
                }
                return $"{item} został dodany do twojego ekwipunku.";
            }
            else return "Nie ma tutaj żadnego przedmiotu.";
        }
        public bool fullInventoryWeapons(Enemy enemy)
        {
            Console.WriteLine($"\nNie masz już miejsca w Ekwipunku, żeby przechować {enemy.drop.name}! Co robisz? (Zastąpienie broni spowoduje jej wyrzucenie na ziemie)");
            Console.WriteLine($"1. Zastąp {enemy.drop.name} bronią 1");
            Console.WriteLine($"2. Zastąp {enemy.drop.name} bronią 2");
            Console.WriteLine($"3. Wyrzuć {enemy.drop.name} na ziemię");
            char key = Console.ReadKey().KeyChar;
            while (true)
            {
                switch (key)
                {
                    case '1': { bron1 = enemy.drop; return true; }
                    case '2': { bron2 = enemy.drop; return true; }
                    case '3': { Program.map[x, y].isItem = enemy.drop; 

                                if(Program.map[x,y].isItem.name == "sztylety")
                                    Program.map[x, y].outputItem = $"Na ziemii leżą {Program.map[x, y].isItem.name}";
                                else
                                    Program.map[x, y].outputItem = $"Na ziemii leży {Program.map[x, y].isItem.name}";

                                Program.map[x, y].updateOutputVisited(enemy);
                                return true; 
                        }
                    default: key = Console.ReadKey().KeyChar; break;
                }
            }
        }
        public bool fullInventorySpells(Enemy enemy)
        {
            Console.WriteLine($"\nNie masz już miejsca w Ekwipunku, żeby przechować {enemy.drop.name}! Co robisz? (Zastąpienie czaru spowoduje jej spalenie)");
            Console.WriteLine($"1. Zastąp {enemy.drop.name} czarem 1");
            Console.WriteLine($"2. Zastąp {enemy.drop.name} czarem 2");
            Console.WriteLine($"3. Zastąp {enemy.drop.name} czarem 3");
            Console.WriteLine($"4. Spal {enemy.drop.name}");
            char key = Console.ReadKey().KeyChar;
            while (true)
            {
                switch (key)
                {
                    case '1': { czar1 = enemy.drop; Console.WriteLine("\nCzar1 został zastąpiony."); return true; }
                    case '2': { czar2 = enemy.drop; Console.WriteLine("\nCzar2 został zastąpiony.");  return true; }
                    case '3': { czar3 = enemy.drop; Console.WriteLine("\nCzar3 został zastąpiony."); return true; }
                    case '4':
                        {
                            Console.WriteLine($"{enemy.drop.name} została bezpowrotnie spalona.");
                            return true;
                        }
                    default: key = Console.ReadKey().KeyChar; break;
                }
            }
        }
        public bool spellSelect(Enemy enemy, int trueDmg)
        {
            Console.WriteLine("\nCzy chcesz użyć swojego czaru?\nY/N");
            var key = Console.ReadKey().Key;
            while (true)
            {
                if (key == ConsoleKey.N) break;
                else if (key == ConsoleKey.Y)
                {
                    Console.WriteLine("\nKtóry czar zatem wybierasz?");
                    Console.WriteLine($"1. {czar1.name} (+{czar1.damage} dmg)");
                    if (czar2.name != "brak") Console.WriteLine($"2. {czar2.name} (+{czar2.damage} dmg)");
                    if (czar3.name != "brak") Console.WriteLine($"3. {czar3.name} (+{czar3.damage} dmg)");
                    Console.WriteLine("*. Nic nie używaj");
                    var choice = Console.ReadKey().KeyChar;
                    switch (choice)
                    {
                        case '1': { trueDmg += czar1.damage; czar1 = new Brak(); } break;
                        case '2': { trueDmg += czar2.damage; czar2 = new Brak(); } break;
                        case '3': { trueDmg += czar3.damage; czar3 = new Brak(); } break;
                        default: { Console.WriteLine("\nWerdykt walki pozostał bez zmian. Kliknij 'Enter', aby kontynuować..."); return false; }
                    }
                    if (trueDmg > enemy.hp) { win(enemy); return true; }
                    else
                    {
                        Console.WriteLine("\nWerdykt walki pozostał bez zmian.");
                        return false;
                    }
                }
                else key = Console.ReadKey().Key;
            }
            return false;
        }
        public void win(Enemy enemy)
        {
            var map = Program.map[x, y];
            map.isEnemy = null;
            Program.output = map.outputVisited;

            /////////PRINT WIN//////////
            Console.WriteLine("\nWygrałeś!\n" + enemy.name + " wyrzucił " + enemy.drop.name + ".");

            if(enemy.drop.type == "key")
            {
                klucz = "Klucz";
            }

            if(enemy.drop.type == "weapon")
            {
                if (bron1.name == "brak") bron1 = enemy.drop;
                else if (bron2.name == "brak") bron2 = enemy.drop;
                else
                {
                    bool endFunction = fullInventoryWeapons(enemy);
                    Program.output = Program.map[x, y].outputVisited;
                    Program.walka = false;
                    if (endFunction) return;
                }
            }
            else
            {
                if (czar1.name == "brak") czar1 = enemy.drop;
                else if (czar2.name == "brak") czar2 = enemy.drop;
                else if (czar3.name == "brak") czar3 = enemy.drop;
                else
                {
                    bool endFunction = fullInventorySpells(enemy);
                    Program.output = Program.map[x, y].outputVisited;
                    Program.walka = false;
                    if (endFunction) return;
                }
            }
        }
        public void goBack()
        {
            switch (lastMove)
            {
                case 'e': gow(); break;
                case 'w': goe(); break;
                case 'n': gos(); break;
                case 's': gon(); break;
            }
        }
    }
}
