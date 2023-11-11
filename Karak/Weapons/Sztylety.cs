using System;
using System.Collections.Generic;
using System.Text;

namespace Karak
{
    internal class Sztylety : Weapon
    {
        public Sztylety()
        {
            name = "sztylety";
            damage = 1;
        }
        new public string showInfo()
        {
            return $"Są to {name}, zadają łącznie {damage} obrażeń.";
        }
    }
}
