using System;
using System.Collections.Generic;
using System.Text;

namespace Karak
{
    internal class Room : Plate
    {
        public Room()
        {
            n = true;
            e = true;
            s = true;
            w = true;
            isEnemy = null;
            wasEnemy = null;
            visited = false;
            output = "Znalazłeś komnatę.";
            outputVisited = "";
            outputItem = "";
            isItem = null;
        }
    }
}