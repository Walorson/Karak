using System;
using System.Collections.Generic;
using System.Text;

namespace Karak
{
    internal class Medkit : Weapon
    {
        public Medkit()
        {
            name = "Apteczka";
            damage = 0;
            type = "spell";
            specialInfo = "Jest to apteczka, możesz jej użyć gdziekolwiek chcesz. Dodaje ci 3 punkty zdrowia, po użyciu, apteczka znika.";
        }
    }
}
