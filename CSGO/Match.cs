using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO
{

    internal class Match
    {
        public bool bombFound = false;
        public int bombCounter { get; private set; }
        public int bombDefuseCounter { get; private set; }
        public int TerroristsDead { get; private set; }
        public int CTsDead { get; private set; }

        public string winner { get; private set; }

        public Terrorist[] terrorists = new Terrorist[5];
        public CounterTerrorist[] counterTerrorists = new CounterTerrorist[5];

        public Match()
        {
            bombCounter = 10;
            bombDefuseCounter = 5;

            for (int i = 0; i < 5; i++) 
            {
                terrorists[i] = new Terrorist();
                counterTerrorists[i] = new CounterTerrorist();
            }
        }

        public void DecreaseCounter(string type)
        {
            if(type == "bomb") { bombCounter--; }
            else { bombDefuseCounter--; }
        }

        public void CheckDeaths()
        {
            TerroristsDead = 0;
            CTsDead = 0;
            foreach (var terrorist in terrorists) { if (terrorist.isDead) TerroristsDead++; }
            foreach (var ct in counterTerrorists) { if (ct.isDead) CTsDead++; }
        }

        public void checkWin()
        {
            if(bombDefuseCounter == 0 || !bombFound && TerroristsDead == 5)  winner = "CounterTerrorists"; 
            if (CTsDead == 5 || bombCounter == 0) winner = "Terrorists";
        }

    }
}
