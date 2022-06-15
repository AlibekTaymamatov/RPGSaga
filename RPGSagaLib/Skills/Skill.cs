namespace RpgSagaLib.Skills
{
    using RpgSagaLib.Heros;

    public abstract class Skill : LoggerConnect
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
