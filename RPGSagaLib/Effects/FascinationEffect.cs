namespace RpgSagaLib.Effects
{
    using RpgSagaLib.Heros;

    public class FascinationEffect : Effect
    {
        private int time = 1;

        public FascinationEffect(ILogger logger)
            : base(logger)
        {
        }

        public override bool IsEnded()
        {
            return time <= 0;
        }

        public override void Use(IHero hero)
        {
            time--;
            Status status = hero.StatusUnderEffects;
            status.Skills.Clear();
        }
    }
}
