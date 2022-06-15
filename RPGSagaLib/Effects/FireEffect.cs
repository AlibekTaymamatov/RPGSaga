namespace RpgSagaLib.Effects
{
    using RpgSagaLib.Heros;

    public class FireEffect : Effect
    {
        private int damage;

        public FireEffect(int damage, ILogger logger)
            : base(logger)
        {
            this.damage = damage;
        }

        public override bool IsEnded()
        {
            return false;
        }

        public override void Use(IHero hero)
        {
            Logger.Log($"{hero.Name} горит и получает урон {damage}");
            Status status = hero.StatusUnderEffects;
            status.HealthPoints -= damage;
        }
    }
}
