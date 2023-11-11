using System;
using System.Collections.Generic;
using System.Text;

namespace Karak
{
    internal abstract class Weapon
    {
        public string name;
        public int damage=0;
        public string type="weapon";
        public string specialInfo;
        public string showInfo()
        {
            if (specialInfo == null) return $"Jest to {name}, zadaje {damage} obrażeń.";
            else return specialInfo;
        }
    }
}
