using System;
using System.Collections.Generic;
using System.Text;

namespace Karak
{
    internal class PathNSEW : Plate
    {
        public PathNSEW()
        {
            n = true;
            e = true;
            s = true;
            w = true;
            output = "Znalazłeś skrzyżowanie.";
            outputVisited = "Zawitałeś ponownie na skrzyżowaniu.";
        }
    }
}
