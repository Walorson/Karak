using System;
using System.Collections.Generic;
using System.Text;

namespace Karak
{
    internal class PathNS : Plate
    {
        public PathNS()
        {
            n = true;
            e = false;
            s = true;
            w = false;
            output = "Znalazłeś drogę na Północ/Południe";
            outputVisited = "Zawitałeś ponownie na drodze Północ/Południe";
        }
    }
}
