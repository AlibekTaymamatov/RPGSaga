namespace RpgSagaLib
{
    using System;
    using System.Collections.Generic;
    using RpgSagaLib.Heros;
    using RpgSagaLib.InputOutput;

    public class Game
    {
        public Game()
        {
        }

        public void RunGame(int countHero)
        {
            if (ThisNumberIsPowerOf2(countHero))
            {
                Logger logger = new Logger();
                Tourney tourney = new Tourney(logger, countHero);
                tourney.Start();
            }
            else
            {
                throw new Exception("Не коректный ввод");
            }
        }

        public void RunGame(string patch)
        {
            try
            {
                IReader file = new FileIO(patch);

                string line = string.Empty;
                string lineBuf;
                while ((lineBuf = file.ReadLine()) != string.Empty)
                {
                    line += lineBuf;
                }

                Logger logger = new Logger();
                HeroCollectorFromFile collector = new HeroCollectorFromFile(logger);
                List<IHero> heros = collector.GetHerosJson(line);

                if (ThisNumberIsPowerOf2(heros.Count))
                {
                    Tourney tourney = new Tourney(logger, heros);
                    tourney.Start();
                }
                else
                {
                    throw new Exception("Не коректный ввод");
                }
            }
            catch
            {
                throw new Exception("Не коректный ввод");
            }
        }

        // Checking that the number is a power of two and greater than 1.
        private bool ThisNumberIsPowerOf2(int n)
        {
            return (n & (n - 1)) == 0 && n > 1;
        }
    }
}