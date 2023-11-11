using System;
using System.Collections.Generic;
using System.Text;

namespace Karak
{
    internal class Plate
    {
        public bool n, e, s, w; //north, east, south, west
        public string output;
        public string outputVisited;
        public string outputItem;
        public bool visited;
        public Enemy isEnemy;
        public Enemy wasEnemy;
        public Weapon isItem;

        public void updateOutputVisited(Enemy enemy)
        {
            wasEnemy = enemy;
            outputVisited = $"Zawitałeś ponownie w komnacie! Znajduje się w niej martwy {wasEnemy.name}. {outputItem}";
        }
    }
}
