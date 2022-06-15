namespace RpgSagaLib.Effects
{
    using RpgSagaLib.Heros;

    public abstract class Effect : LoggerConnect
    {
        public Effect(ILogger logger)
            : base(logger)
        {
        }

        public abstract void Use(IHero hero);

        public abstract bool IsEnded();
    }
}
