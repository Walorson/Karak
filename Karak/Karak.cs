using System;
using System.Collections.Generic;
using System.Text;

namespace Karak
{
    internal static class Karak
    {
        static public void battle(Enemy enemy, Champion player)
        {
            var map = Program.map[player.x, player.y];
            map.isEnemy = enemy;
            map.updateOutputVisited(enemy);

            if (enemy.isChest)
            {
                string youHaveKey;
                if (player.klucz == "Klucz") youHaveKey = "Możesz ją teraz otworzyć i zgarnąć punkt! Chcesz ją otworzyć?\nY/N";
                else youHaveKey = "Niestety nie możesz jej otworzyć, gdyż nie posiadasz klucza. Jeśli go znajdziesz możesz tu wrócić!";
                Console.WriteLine("=> Znalazłeś skrzynkę! " + youHaveKey);

                if(player.klucz == "Klucz")
                {
                    var key = Console.ReadKey().Key;
                    while (true)
                    {
                        if (key == ConsoleKey.N) break;
                        else if (key == ConsoleKey.Y)
                        {
                            Console.WriteLine("Otworzyłeś skrzynkę i zdobywasz 1 punkt zwycięstwa!");
                            break;
                        }
                    }
                }
                else
                {
                    player.goBack();
                }
                getKey(ConsoleKey.Enter);
                Program.walka = false;
                return;
            }
            /////////////OBSŁUGA KLAWISZA/////////////////
            if (!map.visited)
            {
                Console.WriteLine("=> Znalazłeś komnatę, w której napotkałeś na " + enemy.name + ", Zdrowie: " + enemy.hp + ". Naciśnij 'Enter', aby rzucić koścmi");
                getKey(ConsoleKey.Enter);
                map.visited = true;
            }
            else 
            { 
                Console.WriteLine("=> Ponownie zawitałeś w komnacie, w której aktualnie jest " + enemy.name + ", Zdrowie: " + enemy.hp + ". Czy na pewno chcesz się z nim bić?\nY/N");
                var key = Console.ReadKey().Key;
                while (true)
                {
                    if (key == ConsoleKey.N)
                    {
                        player.goBack();
                        Program.walka = false;
                        return;
                    }
                    else if (key == ConsoleKey.Y) break;
                    else key = Console.ReadKey().Key;
                }
            }

            /////////////RZUT KOŚCIĄ///////////////
            var random = new Random();
            var dice1 = random.Next(1, 7);
            var dice2 = random.Next(1, 7);
            var dice = dice1 + dice2;
            ////////////DODATKOWY DAMAGE///////////
            var addDmg = player.bron1.damage + player.bron2.damage;
            var trueDmg = dice + addDmg;
            if (Output.invincibleMode) trueDmg = enemy.hp + 1;

            var result = false;

            Console.WriteLine("\nWyrzucono: " + dice1 + " i " + dice2 + ". Dodatkowy damage z broni: " + addDmg + " W sumie: " + trueDmg + ".\n");
            ////////////WYGRANA CZY NIE?/////////////
            if (trueDmg > enemy.hp)
            {
                player.win(enemy);
            }
            else if (trueDmg == enemy.hp)
            {
                Console.WriteLine("Zremisowałeś!");
                if(player.czar1.name != "brak")
                {
                    result = player.spellSelect(enemy, trueDmg);
                }
                if (result == false)
                {
                    player.goBack();
                }
            }
            else
            {
                Console.WriteLine("Przegrałeś! Tracisz 1 punkt zdrowia.");  
                if(player.czar1.name != "brak")
                {
                    result = player.spellSelect(enemy, trueDmg);
                }
                if (result == false)
                {
                    player.hp -= 1;
                    player.goBack();
                }
            }
            Program.walka = false;
            getKey(ConsoleKey.Enter);
        }
        static public Enemy randEnemy(Champion player)
        {
            if(Program.map[player.x, player.y].isEnemy == null)
            {
                var random = new Random();
                int rand = random.Next(6, 8);
                switch (rand)
                {
                    case 1: return new Enemy("Szkielet Miecznik", 7, new Miecz());
                    case 2: return new Enemy("Szkielet Topornik", 10, new Topor());
                    case 3: return new Enemy("Mumia", 6, new FireBlow());
                    case 4: return new Enemy("Szkielet Mag", 11, new PowerfulFist());
                    case 5: return new Enemy("Pająk", 6, new Medkit());
                    case 6: return new Enemy("Szkielet Klucznik", 8, new Key()) ;
                    case 7: return new Enemy("Skrzynka", 0, new Key(), true); //W tym przypadku do żadnego dropu przedmiotu nie dojdzie, został tam wpisany losowy drop xD
                    default: return new Enemy("Szczur", 5, new Sztylety());
                }
            }
            else
            {
                return Program.map[player.x, player.y].isEnemy;
            }
        }
        
        static public void getKey(ConsoleKey theKey)
        {
            var key = Console.ReadKey().Key;
            while (key != theKey)
                key = Console.ReadKey().Key;
        }
    }
}
