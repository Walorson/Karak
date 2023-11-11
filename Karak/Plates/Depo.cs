using System;
using System.Collections.Generic;
using System.Text;

namespace Karak
{
    internal class Depo : Plate
    {
        public Depo()
        {
            n = true;
            e = true;
            s = true;
            w = true;
            outputVisited = "Witaj w depo! Możesz się tu uleczyć za pomocą komendy 'ulecz'.";
        }
    }
}
