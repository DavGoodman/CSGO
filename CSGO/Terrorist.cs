using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO
{
    internal class Terrorist : Player
    {


        public void KillCounterTerrorist(CounterTerrorist ct)
        {
            if (Program.isSuccessful(7))
            {
                ct.isDead = true;
            }
        }
        public bool findBombSite()
        {
            if (Program.isSuccessful(10)) return true;
            return false;
        }


    }
}
