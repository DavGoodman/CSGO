using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CSGO
{
    internal class CounterTerrorist : Player
    {

        public void killTerrorist(Terrorist terrorist, bool bombPlanted)
        {
            if (bombPlanted)
            {
                if(Program.isSuccessful(5)) terrorist.isDead = true;
            }
            else { if (Program.isSuccessful(3)) terrorist.isDead = true; }
        }
        public bool defuseBomb(Terrorist[] terrorists, bool bombPlanted)
        {
            bool terroristsDead = true;
            foreach (var terrorist in terrorists)
            {
                if(!terrorist.isDead) terroristsDead = false;
            }

            if (bombPlanted && terroristsDead) return true;
            return false;
        }
    }
}
