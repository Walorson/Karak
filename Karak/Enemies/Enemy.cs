using System;
using System.Collections.Generic;
using System.Text;

namespace Karak
{
    internal class Enemy
    {
        public byte hp;
        public string name;
        public Weapon drop;
        public bool isChest = false;
        public Enemy(string name, byte hp, Weapon drop, bool isChest=false)
        {
            this.name = name;
            this.hp = hp;
            this.drop = drop;
            this.isChest = isChest;
        }
    }
}
