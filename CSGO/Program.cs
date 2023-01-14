
namespace CSGO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var match = new Match();
            var cts = match.counterTerrorists;
            var terrorists = match.terrorists;
            int round = 1;

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Turn {round} \n" +
                                  $"Terrorists eliminated: {match.TerroristsDead} / 5\n" +
                                  $"CTs eliminated: {match.CTsDead} / 5 \n");

                if (match.bombFound)
                {
                    match.DecreaseCounter("bomb");
                    Console.WriteLine($"Bomb detonates in {match.bombCounter}");
                    if (match.TerroristsDead == 5)
                    {
                        match.DecreaseCounter("defuse");
                        Console.WriteLine($"Bomb will be defused in {match.bombDefuseCounter}\n");
                    }
                }
                Console.WriteLine("*************************\n" +
                                  "terrorist's turn:");

                int i = 0;
                foreach (var terrorist 
                         in terrorists)
                {
                    if(terrorist.isDead) continue;
                    match.CheckDeaths();

                    if (!match.bombFound && i % 2 != 0)
                    {
                        Console.WriteLine("terrorist is attempting to plant the bomb...");
                        match.bombFound = terrorist.findBombSite();
                        Console.WriteLine($"terrorist has {(match.bombFound ? "succeeded, bomb has been planted" : "failed, better luck next time")}");
                    }

                    else
                    { ;
                        if (match.CTsDead == 5) break;

                        var target = cts[getRandomPlayerIndex()];
                        while(target.isDead) target = cts[getRandomPlayerIndex()];
                        Console.WriteLine("terrorist is attempting to kill CT");
                        terrorist.KillCounterTerrorist(target);
                        Console.WriteLine($"Terrorist {(target.isDead? "succeeded, CT is dead" : "failed, CT got away")}");
                    }

                    i++;
                }

                Console.WriteLine("*************************\n" +
                                  "counter terrorist's turn");
                foreach (var ct in cts)
                {
                    if(ct.isDead) continue;

                    match.CheckDeaths();
                    if (match.TerroristsDead != 5)
                    {
                        var target = terrorists[getRandomPlayerIndex()];
                        while (target.isDead) target = terrorists[getRandomPlayerIndex()];
                        Console.WriteLine("CT is attempting to kill Terrorist");
                        ct.killTerrorist(target, match.bombFound);
                        Console.WriteLine($"CT {(target.isDead ? "succeeded, terrorist is dead" : "failed, terrorist got away")}");
                    }

                    
                }

                match.checkWin();
                if(match.winner != null) break;
                round++;
                Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine($"Game Over. Winners are {match.winner}");
        }


        public static bool isSuccessful(int maxValue)
        {
            Random rand = new Random();

            return rand.Next(0, maxValue) == 2;
        }

        public static int getRandomPlayerIndex()
        {
            Random rand = new Random();

            return rand.Next(0, 5);
        }



    }
}