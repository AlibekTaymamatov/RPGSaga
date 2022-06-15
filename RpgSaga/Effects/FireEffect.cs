namespace RpgSaga.Effects
{
    using RpgSaga.Heros;

    public class FireEffect : Effect // эффект огнz
    {
        private int damage = 2;

        public FireEffect(ILogger logger)
            : base(logger)
        {
        }

        public override bool IsEnded()
        {
            return false;
        }

        public override void Use(IHero hero)
        {
            Logger.Log($"{hero.Name} горит и получает урон {damage}");
            hero.DealDamage(damage);
        }
    }
}
