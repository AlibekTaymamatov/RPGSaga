namespace RpgSaga.Skills
{
    using RpgSaga.Heros;

    public abstract class Skill : LoggerConnect // скиллы
    {
        public Skill(ILogger logger, IHero hero)
            : base(logger)
        {
            Owner = hero;
        }

        protected IHero Owner { get; private set; }

        public abstract void Use(IHero hero);

        public virtual void Restart()
        {
        }

        public virtual bool IsReady()
        {
            return true;
        }
    }
}
