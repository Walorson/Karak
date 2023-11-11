using System;
using System.Collections.Generic;
using System.Text;

namespace Karak
{
    internal static class MapGenerator
    {
        public static string generate(Champion player)
        {
            if (Program.map[player.x, player.y] == null)
            {
                var random = new Random();
                int rand = random.Next(0, 2);
                switch (rand)
                {
                    case 1:
                        {
                            Program.map[player.x, player.y] = new PathNSEW();
                            return Program.map[player.x, player.y].output;
                        }
                    default:
                        {
                            Program.map[player.x, player.y] = new Room();
                            Program.walka = true;
                            return Program.map[player.x, player.y].output;
                        }
                }
            }
            else
            {
                if (Program.map[player.x, player.y].isEnemy != null)
                {
                    Program.walka = true;
                    return "";
                }
                else return Program.map[player.x, player.y].outputVisited;
            }
        }
    }
}
