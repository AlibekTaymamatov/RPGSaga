namespace RpgSaga
{
    using RpgSaga.Heros;

    public class Battle : LoggerConnect, IBattle // битва 1 на 1
    {
        private IHero hero1;
        private IHero hero2;
        private int hod = 0;

        public Battle(IHero hero1, IHero hero2, ILogger logger)
            : base(logger)
        {
            this.hero1 = hero1;
            this.hero2 = hero2;
        }

        public IHero StartBattle()
        {
            while (hero1.IsLive() && hero2.IsLive())
            {
                Logger.Log($"Ход: {hod}");
                if (hod % 2 == 0)
                {
                   hero1.HodEffects();
                   if (!(hero1.IsLive() && hero2.IsLive()))
                    {
                        break;
                    }

                   hero1.Hod(this);
                }
                else
                {
                    hero2.HodEffects();
                    if (!(hero1.IsLive() && hero2.IsLive()))
                    {
                        break;
                    }

                    hero2.Hod(this);
                }

                hod++;
            }

            if (hero1.IsLive())
            {
                Logger.Log($"{hero1.Name} победил!");
                return hero1;
            }
            else
            {
                Logger.Log($"{hero2.Name} победил!");
                return hero2;
            }
        }

        public IHero GetOpponent()
        {
            return hod % 2 == 1 ? hero1 : hero2;
        }
    }
}
