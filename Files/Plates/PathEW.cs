using System;
using System.Collections.Generic;
using System.Text;

namespace Karak
{
    internal class PathEW : Plate
    {
        public PathEW()
        {
            n = false;
            e = true;
            s = false;
            w = true;
            output = "Znalazłeś drogę na Wschód/Zachód";
            outputVisited = "Zawitałeś ponownie na drodze Wchód/Zachód";
        }
    }
}
