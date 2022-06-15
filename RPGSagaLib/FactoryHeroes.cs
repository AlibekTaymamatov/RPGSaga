namespace RpgSagaLib
{
    using System;
    using System.Linq;
    using RpgSagaLib.Heros;

    public class FactoryHeroes : LoggerConnect
    {
        private Random rnd = new Random();
        private HeroType[] heroTypeArray = Enum.GetValues(typeof(HeroType)).Cast<HeroType>().ToArray();
        private string[] names = { "Артур", "Максим", "Александр", "Егор", "Илья", "Евгений", "Дмитрий" };

        public FactoryHeroes(ILogger logger)
            : base(logger)
        {
        }

        public IHero CreateRandomHero()
        {
            HeroType heroType = heroTypeArray[rnd.Next(heroTypeArray.Length)];
            return CreateRandomHeroByType(heroType);
        }

        public IHero CreateRandomHeroByType(HeroType type)
        {
            int nameIndex = rnd.Next() % names.Length;
            string name = names[nameIndex];
            int health = rnd.Next(80, 120);
            int strength = rnd.Next(8, 15);
            int armor = rnd.Next(8, 15);
            int intelligence = rnd.Next(8, 15);
            int speed = rnd.Next(5, 10);
            return CreateHero(type, name, health, strength, armor, intelligence, speed);
        }

        public IHero CreateHero(HeroType type, string name, int health, int strength, int armor, int intelligence, int speed)
        {
            switch (type)
            {
                case HeroType.Mage:
                    {
                        return new Mage(health, strength, name, armor, intelligence, speed, Logger);
                    }

                case HeroType.Archer:
                    {
                        return new Archer(health, strength, name, armor, intelligence, speed, Logger);
                    }

                case HeroType.Knight:
                    {
                        return new Knight(health, strength, name, armor, intelligence, speed, Logger);
                    }

                default:
                    {
                        return null;
                    }
            }
        }
    }
}
