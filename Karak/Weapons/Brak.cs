using System;
using System.Collections.Generic;
using System.Text;

namespace Karak
{
    internal class Brak : Weapon
    {
        public Brak()
        {
            name = "brak";
            damage = 0;
        }
        new public string showInfo()
        {
            return "Brak broni, znajdź zabijając przeciwników.";
        }
    }
}
