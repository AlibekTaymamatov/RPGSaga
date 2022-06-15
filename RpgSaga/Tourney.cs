namespace RpgSaga
{
    using System;
    using System.Collections.Generic;
    using RpgSaga.Heros;

    public class Tourney : LoggerConnect
    {
        private Random rnd = new Random();
        private string[] names = { "Артур", "Максим", "Александр", "Егор", "Илья", "Евгений", "Дмитрий" };
        private List<IHero> heros = new List<IHero>();

        public Tourney(ILogger logger, int countHero)
            : base(logger)
        {
            FillHero(countHero);
        }

        public void Start()
        {
            int kon = 1;
            List<IHero> nextHeros = new List<IHero>();
            while (heros.Count > 1)
            {
                Logger.Log($"\nКон {kon}");

                int count = heros.Count;
                IHero hero1 = heros[rnd.Next() % count];
                heros.Remove(hero1);

                count = heros.Count;
                IHero hero2 = heros[rnd.Next() % count];
                heros.Remove(hero2);

                Logger.Log($"{hero1.Name} vs {hero2.Name}");
                Battle game = new Battle(hero1, hero2, Logger);
                IHero hero = game.StartBattle();

                nextHeros.Add(hero);
                hero.RestartHero();
                if (heros.Count == 0 && nextHeros.Count != 0)
                {
                    heros = new List<IHero>(nextHeros);
                    nextHeros.Clear();
                    kon++;
                }
            }

            Logger.Log($"Единственный выживший {heros[0].Name}");
        }

        private void FillHero(int countHero)
        {
            for (int i = 0; i < countHero; i++)
            {
                int heroType = rnd.Next() % 3;
                int nameIndex = rnd.Next() % names.Length;
                string name = names[nameIndex];
                int health = (rnd.Next() % 20) + 100;
                int damage = (rnd.Next() % 2) + 20;

                switch (heroType)
                {
                    case 0:
                        {
                            heros.Add(new Mage(health, damage, name, this.Logger));
                            break;
                        }

                    case 1:
                        {
                            heros.Add(new Archer(health, damage, name, Logger));
                            break;
                        }

                    case 2:
                        {
                            heros.Add(new Knight(health, damage, name, Logger));
                            break;
                        }
                }
            }
        }
    }
}
