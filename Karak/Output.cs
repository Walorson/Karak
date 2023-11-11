using System;
using System.Collections.Generic;
using System.Text;

namespace Karak
{
    static class Output
    {
        public static bool invincibleMode = false;
        public static string help()
        {
            return "go <kierunek> - porusza gracza w danym kierunku (n, s, e, w) np. go n\ninfo <broń lub czar> - pokazuje informacje na temat danego przedmiotu.\nulecz - jeśli znajdujesz się w depo, możesz się uleczyć do 5 punktów zdrowia\nuzyj <czar> - uzywa czaru";
        }
        public static string invincible()
        {
            if (invincibleMode == false) { invincibleMode = true; return "Włączono tryb nieprzezzwyciężonego."; }
            else { invincibleMode = false; return "Wyłączono tryb nieprzezzwyciężonego."; }
        }
        public static string unknown()
        {
            return "Nieznana komenda. Wpisz 'help', aby dowiedzieć się o prawidłowych komendach.";
        }
    }
}
