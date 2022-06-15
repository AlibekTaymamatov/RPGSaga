namespace RpgSagaLib
{
    using System;
    using System.Collections.Generic;
    using RpgSagaLib.Heros;

    public class Tourney : LoggerConnect
    {
        private List<IHero> heros = new List<IHero>();
        private Random rnd = new Random();

        public Tourney(ILogger logger, int countHero)
            : base(logger)
        {
            FillHero(countHero);
        }

        public Tourney(ILogger logger, List<IHero> heros)
            : base(logger)
        {
            this.heros = heros;
        }

        public void Start()
        {
            if (ThisNumberIsPowerOf2(heros.Count) && heros.Count > 1)
            {
                int stage = 1;
                List<IHero> nextHeros = new List<IHero>();
                while (heros.Count > 1)
                {
                    Logger.Log($"\nКон {stage}");

                    int count = heros.Count;
                    IHero hero1 = heros[rnd.Next() % count];
                    heros.Remove(hero1);

                    count = heros.Count;
                    IHero hero2 = heros[rnd.Next() % count];
                    heros.Remove(hero2);

                    Logger.Log($"{hero1.Name} vs {hero2.Name}");
                    Battle battle = new Battle(hero1, hero2, Logger);
                    IHero hero = battle.StartBattle();

                    nextHeros.Add(hero);
                    hero.RestartHero();
                    if (heros.Count == 0 && nextHeros.Count != 0)
                    {
                        heros = new List<IHero>(nextHeros);
                        nextHeros.Clear();
                        stage++;
                    }
                }

                if (heros.Count > 0)
                {
                    Logger.Log($"Единственный выживший {heros[0].Name}");
                }
            }
            else
            {
                Logger.Log($"Неверный ввод");
            }
        }

        private void FillHero(int countHero)
        {
            for (int i = 0; i < countHero; i++)
            {
                FactoryHeroes factory = new FactoryHeroes(Logger);

                heros.Add(factory.CreateRandomHero());
            }
        }

        // Checking that the number is a power of two and greater than 1.
        private bool ThisNumberIsPowerOf2(int n)
        {
            return (n & (n - 1)) == 0;
        }
    }
}
